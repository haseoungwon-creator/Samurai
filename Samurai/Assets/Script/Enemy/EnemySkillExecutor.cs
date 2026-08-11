using System.Collections;
using UnityEngine;

public class EnemySkillExecutor : MonoBehaviour
{
    private Enemy enemy;
    private Transform player;
    private Coroutine skillCoroutine;

    private float behindAttackCooldownTimer;
    private float dashAttackCooldownTimer;
    private float invisibilityCooldownTimer;

    private bool isUsingSkill;
    private bool isInvisible;
    private bool attackAnimationFinished;

    public bool IsUsingSkill => isUsingSkill;
    public bool IsInvisible => isInvisible;
    public EnemySkillType CurrentSkill { get; private set; } = EnemySkillType.None;

    public void Initialize(Enemy enemy, Transform player)
    {
        this.enemy = enemy;
        this.player = player;
        isUsingSkill = false;
        isInvisible = false;
        attackAnimationFinished = false;
        CurrentSkill = EnemySkillType.None;
        behindAttackCooldownTimer = 0f;
        dashAttackCooldownTimer = 0f;
        invisibilityCooldownTimer = 0f;
    }

    public void UpdateCooldowns()
    {
        if (behindAttackCooldownTimer > 0f)
            behindAttackCooldownTimer -= Time.deltaTime;

        if (dashAttackCooldownTimer > 0f)
            dashAttackCooldownTimer -= Time.deltaTime;

        if (invisibilityCooldownTimer > 0f)
            invisibilityCooldownTimer -= Time.deltaTime;
    }

    public bool TryUseSkill()
    {
        if (enemy == null || player == null || isUsingSkill)
            return false;

        EnemyData data = enemy.Data;

        if (data == null)
            return false;

        bool canBehind = data.useBehindAttack && behindAttackCooldownTimer <= 0f;
        bool canDash = data.useDashAttackCombo && dashAttackCooldownTimer <= 0f;
        bool canInvisible = data.useInvisibility && invisibilityCooldownTimer <= 0f;

        if (!canBehind && !canDash && !canInvisible)
            return false;

        float totalChance = 0f;

        if (canBehind)
            totalChance += data.behindAttackChance;

        if (canDash)
            totalChance += data.dashAttackChance;

        if (canInvisible)
            totalChance += data.invisibilityChance;

        if (totalChance <= 0f)
            return false;

        float randomValue = Random.Range(0f, totalChance);

        if (canBehind)
        {
            if (randomValue < data.behindAttackChance)
            {
                StartBehindAttack();
                return true;
            }

            randomValue -= data.behindAttackChance;
        }

        if (canDash)
        {
            if (randomValue < data.dashAttackChance)
            {
                StartDashAttackCombo();
                return true;
            }

            randomValue -= data.dashAttackChance;
        }

        if (canInvisible && randomValue < data.invisibilityChance)
        {
            StartInvisibility();
            return true;
        }

        return false;
    }

    private void StartBehindAttack()
    {
        if (skillCoroutine != null)
            return;

        skillCoroutine = StartCoroutine(BehindAttackRoutine());
    }

    private IEnumerator BehindAttackRoutine()
    {
        isUsingSkill = true;
        CurrentSkill = EnemySkillType.BehindAttack;

        EnemyData data = enemy.Data;

        if (data == null || player == null)
        {
            FinishSkill();
            yield break;
        }

        float playerDirection = player.localScale.x >= 0f ? 1f : -1f;
        float behindDirection = -playerDirection;

        Vector3 targetPosition = player.position + new Vector3(behindDirection * data.behindAttackDistance, 0f, 0f);

        enemy.transform.position = targetPosition;
        enemy.FacePlayer();

        attackAnimationFinished = false;
        enemy.PlaySkillAttackAnimation();

        yield return new WaitUntil(() => attackAnimationFinished);

        DamagePlayer(data.behindAttackDamage);

        behindAttackCooldownTimer = data.behindAttackCooldown;

        FinishSkill();
    }

    private void StartDashAttackCombo()
    {
        if (skillCoroutine != null)
            return;

        skillCoroutine = StartCoroutine(DashAttackComboRoutine());
    }

    private IEnumerator DashAttackComboRoutine()
    {
        isUsingSkill = true;
        CurrentSkill = EnemySkillType.DashAttackCombo;

        EnemyData data = enemy.Data;

        if (data == null)
        {
            FinishSkill();
            yield break;
        }

        int dashCount = Mathf.Max(1, data.dashHitCount);

        for (int i = 0; i < dashCount; i++)
        {
            if (player == null)
                break;

            float side = i % 2 == 0 ? 1f : -1f;
            float progress = dashCount <= 1 ? 1f : (float)i / (dashCount - 1);
            float edgeX = GetScreenEdgeX(side);

            float targetX = Mathf.Lerp(edgeX, player.position.x + side * data.dashHitDistance, progress);

            TeleportTo(targetX);

            yield return CoroutineManager.Wait(GetDashInterval(i, dashCount));
        }

        if (player == null)
        {
            FinishSkill();
            yield break;
        }

        yield return CoroutineManager.Wait(data.dashPauseTime);

        float finalSide = player.position.x < enemy.transform.position.x ? 1f : -1f;
        float finalEdgeX = GetScreenEdgeX(finalSide);

        TeleportTo(finalEdgeX);

        yield return CoroutineManager.Wait(0.05f);

        attackAnimationFinished = false;
        enemy.PlaySkillAttackAnimation();

        yield return new WaitUntil(() => attackAnimationFinished);

        DamagePlayer(data.dashAttackDamage);

        dashAttackCooldownTimer = data.dashAttackCooldown;

        FinishSkill();
    }

    public void AttackAnimationEnd()
    {
        attackAnimationFinished = true;
    }

    private float GetDashInterval(int step, int totalCount)
    {
        EnemyData data = enemy.Data;

        if (data == null)
            return 0f;

        float progress = totalCount <= 1 ? 1f : (float)step / (totalCount - 1);

        return Mathf.Lerp(data.dashIntervalStart, data.dashIntervalEnd, progress);
    }

    private float GetScreenEdgeX(float side)
    {
        Camera camera = Camera.main;
        EnemyData data = enemy.Data;

        if (camera == null || !camera.orthographic)
            return player.position.x + side * data.dashStartDistance;

        float halfWidth = camera.orthographicSize * camera.aspect;

        return camera.transform.position.x + side * (halfWidth - 0.5f);
    }

    private void TeleportTo(float targetX)
    {
        Vector3 position = enemy.transform.position;
        position.x = targetX;
        enemy.transform.position = position;
        enemy.FacePlayer();
    }

    private void DamagePlayer(float damage)
    {
        if (player == null)
            return;

        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth == null)
            playerHealth = player.GetComponentInParent<PlayerHealth>();

        if (playerHealth == null)
            return;

        playerHealth.TakeDamage(Mathf.RoundToInt(damage), enemy);

        PlayerStun playerStun = player.GetComponent<PlayerStun>();

        if (playerStun == null)
            playerStun = player.GetComponentInParent<PlayerStun>();

        if (playerStun != null)
            playerStun.Stun(1f);
    }

    private void StartInvisibility()
    {
        if (skillCoroutine != null)
            return;

        skillCoroutine = StartCoroutine(InvisibilityRoutine());
    }

    private IEnumerator InvisibilityRoutine()
    {
        isUsingSkill = true;
        CurrentSkill = EnemySkillType.Invisibility;
        isInvisible = true;

        EnemyData data = enemy.Data;

        if (data == null || player == null)
        {
            EndInvisibility();
            FinishSkill();
            yield break;
        }

        SetVisible(false);

        invisibilityCooldownTimer = data.invisibilityCooldown;

        float direction = player.position.x < enemy.transform.position.x ? 1f : -1f;

        Vector3 targetPosition = player.position + new Vector3(direction * data.behindAttackDistance, 0f, 0f);

        enemy.transform.position = targetPosition;
        enemy.FacePlayer();

        attackAnimationFinished = false;
        enemy.PlaySkillAttackAnimation();

        yield return new WaitUntil(() => attackAnimationFinished);

        DamagePlayer(data.behindAttackDamage);

        EndInvisibility();
        FinishSkill();
    }

    public void EndInvisibility()
    {
        if (!isInvisible)
            return;

        isInvisible = false;
        SetVisible(true);
    }

    private void SetVisible(bool visible)
    {
        if (enemy == null)
            return;

        SpriteRenderer[] renderers = enemy.GetComponentsInChildren<SpriteRenderer>(true);

        foreach (SpriteRenderer renderer in renderers)
            renderer.enabled = visible;
    }

    private void FinishSkill()
    {
        isUsingSkill = false;
        CurrentSkill = EnemySkillType.None;
        skillCoroutine = null;
        attackAnimationFinished = false;

        if (enemy != null)
            enemy.SkillFinish();
    }

    public void CancelSkill()
    {
        if (skillCoroutine != null)
        {
            StopCoroutine(skillCoroutine);
            skillCoroutine = null;
        }

        EndInvisibility();

        isUsingSkill = false;
        CurrentSkill = EnemySkillType.None;
        attackAnimationFinished = false;
    }

    private void OnDestroy()
    {
        CancelSkill();
    }
}