using UnityEngine;

public class Enemy : EnemyBase
{
    private Transform player;
    private EnemyManager enemyManager;
    private EnemyAttackExecutor attackExecutor;
    private EnemySkillExecutor skillExecutor;

    private EnemyState currentState;

    private float detectRange;
    private float attackRange;
    private float keepDistance;
    private float keepDistanceSpeed;
    private float moveSpeed;

    private float attackPrepareTime;
    private float attackCooldownMin;
    private float attackCooldownMax;

    private float recoverTime;
    private float hurtTime;

    private float stateTimer;
    private float attackCooldownTimer;

    private bool hasAttackSlot;

    public Transform Player => player;

    protected override void Awake()
    {
        base.Awake();

        enemyManager = FindAnyObjectByType<EnemyManager>();
        attackExecutor = GetComponent<EnemyAttackExecutor>();
        skillExecutor = GetComponent<EnemySkillExecutor>();
    }

    private void Start()
    {
        enemyManager?.Register(this);

        GameObject obj = GameObject.FindGameObjectWithTag("Player");

        if (obj != null)
            player = obj.transform;

        attackExecutor?.Initialize(this);
        skillExecutor?.Initialize(this, player);
    }

    public override void Initialize(EnemyData data)
    {
        base.Initialize(data);

        detectRange = data.detectRange;
        attackRange = data.attackRange;
        keepDistance = data.keepDistance;
        keepDistanceSpeed = data.keepDistanceSpeed;
        moveSpeed = data.moveSpeed;

        attackPrepareTime = data.attackPrepareTime;
        attackCooldownMin = data.attackCooldownMin;
        attackCooldownMax = data.attackCooldownMax;

        recoverTime = data.recoverTime;
        hurtTime = data.hurtTime;

        currentState = EnemyState.Idle;
    }

    protected override void Update()
    {
        base.Update();

        if (isDead)
            return;

        if (!CanUpdateAi)
        {
            Stop();
            return;
        }

        if (player == null)
            return;

        skillExecutor?.UpdateCooldowns();

        if (attackCooldownTimer > 0f)
            attackCooldownTimer -= Time.deltaTime;

        if (skillExecutor != null && skillExecutor.IsUsingSkill)
        {
            Stop();
            return;
        }

        switch (currentState)
        {
            case EnemyState.Idle:
                UpdateIdle();
                break;

            case EnemyState.Chase:
                UpdateChase();
                break;

            case EnemyState.KeepDistance:
                UpdateKeepDistance();
                break;

            case EnemyState.AttackPrepare:
                UpdateAttackPrepare();
                break;

            case EnemyState.Attack:
                Stop();
                break;

            case EnemyState.Recover:
                UpdateRecover();
                break;

            case EnemyState.Hurt:
                UpdateHurt();
                break;
        }

        if (currentState != EnemyState.Dead)
            LookAtPlayer();
    }

    public override void TakeDamage(int damage)
    {
        if (skillExecutor != null && skillExecutor.IsInvisible)
            return;

        base.TakeDamage(damage);
    }

    private float DistanceToPlayer()
    {
        return Mathf.Abs(player.position.x - transform.position.x);
    }

    private void UpdateIdle()
    {
        Stop();

        if (DistanceToPlayer() <= detectRange)
            currentState = EnemyState.Chase;
    }

    private void UpdateChase()
    {
        float distance = DistanceToPlayer();

        if (distance > detectRange)
        {
            EnterIdle();
            return;
        }

        if (distance <= attackRange)
        {
            currentState = EnemyState.KeepDistance;
            Stop();
            return;
        }

        float direction = player.position.x < transform.position.x ? -1f : 1f;

        rb.linearVelocity = new Vector2(
            direction * moveSpeed,
            rb.linearVelocity.y
        );

        SetRunAnimation(true);
    }

    private void EnterIdle()
    {
        currentState = EnemyState.Idle;
        Stop();
        ExitAttackSlot();
    }

    private void UpdateKeepDistance()
    {
        float distance = DistanceToPlayer();

        if (distance > detectRange)
        {
            EnterIdle();
            return;
        }

        if (distance > attackRange + 0.3f)
        {
            currentState = EnemyState.Chase;
            return;
        }

        if (skillExecutor != null && skillExecutor.IsUsingSkill)
        {
            Stop();
            return;
        }

        KeepDistanceMove(distance);

        if (!hasAttackSlot)
        {
            hasAttackSlot = enemyManager == null || enemyManager.RequestAttack(this);

            if (!hasAttackSlot)
                return;
        }

        if (skillExecutor != null && skillExecutor.TryUseSkill())
        {
            Stop();
            return;
        }

        if (attackCooldownTimer <= 0f)
            EnterAttackPrepare();
    }

    private void KeepDistanceMove(float distance)
    {
        float direction = player.position.x < transform.position.x ? -1f : 1f;
        float difference = distance - keepDistance;

        Vector2 velocity = Vector2.zero;

        if (difference > 0.15f)
            velocity.x = direction * keepDistanceSpeed;
        else if (difference < -0.15f)
            velocity.x = -direction * keepDistanceSpeed;
        else
            velocity.x = Mathf.Sin(Time.time * 6f) * 0.5f;

        velocity.y = rb.linearVelocity.y;
        rb.linearVelocity = velocity;

        SetRunAnimation(Mathf.Abs(rb.linearVelocity.x) > 0.05f);
    }

    private void EnterAttackPrepare()
    {
        currentState = EnemyState.AttackPrepare;
        Stop();
        stateTimer = attackPrepareTime;
    }

    private void UpdateAttackPrepare()
    {
        Stop();

        stateTimer -= Time.deltaTime;

        if (stateTimer > 0f)
            return;

        EnterAttack();
    }

    private void EnterAttack()
    {
        currentState = EnemyState.Attack;
        Stop();

        if (attackExecutor == null)
        {
            AttackFinish();
            return;
        }

        attackExecutor.StartAttack();
    }

    public void SetAttackIndex(int index)
    {
        if (animator == null)
            return;

        if (!HasAnimatorParameter("AttackIndex"))
            return;

        animator.SetInteger("AttackIndex", index);
    }

    public void PlayAttackAnimation()
    {
        if (animator == null)
            return;

        if (!HasAnimatorParameter("attack"))
            return;

        animator.SetTrigger("attack");
    }

    public void PlaySkillAttackAnimation()
    {
        if (animator == null)
            return;

        if (!HasAnimatorParameter("attack"))
            return;

        animator.SetTrigger("attack");
    }

    public void AttackFinish()
    {
        attackExecutor?.DestroyHitbox();
        EnterRecover();
    }

    public void SkillFinish()
    {
        EnterRecover();
    }

    private void EnterRecover()
    {
        currentState = EnemyState.Recover;
        stateTimer = recoverTime;

        attackCooldownTimer = Random.Range(
            attackCooldownMin,
            attackCooldownMax
        );

        ExitAttackSlot();
        Stop();
    }

    private void UpdateRecover()
    {
        Stop();

        stateTimer -= Time.deltaTime;

        if (stateTimer > 0f)
            return;

        currentState = EnemyState.KeepDistance;
    }

    protected override void OnHurt()
    {
        if (isDead)
            return;

        if (skillExecutor != null && skillExecutor.IsInvisible)
            return;

        if (skillExecutor != null)
            skillExecutor.CancelSkill();

        if (attackExecutor != null)
            attackExecutor.CancelAttack();

        currentState = EnemyState.KeepDistance;
        ExitAttackSlot();
    }

    private void UpdateHurt()
    {
        Stop();

        stateTimer -= Time.deltaTime;

        if (stateTimer > 0f)
            return;

        currentState = DistanceToPlayer() <= detectRange
            ? EnemyState.Chase
            : EnemyState.Idle;
    }

    private void Stop()
    {
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(
                0f,
                rb.linearVelocity.y
            );
        }

        SetRunAnimation(false);
    }

    private void SetRunAnimation(bool value)
    {
        if (animator == null)
            return;

        if (!HasAnimatorParameter("run"))
            return;

        animator.SetBool("run", value);
    }

    private void ExitAttackSlot()
    {
        if (!hasAttackSlot)
            return;

        enemyManager?.ReleaseAttack(this);
        hasAttackSlot = false;
    }

    private void LookAtPlayer()
    {
        if (player == null)
            return;

        float distanceX = player.position.x - transform.position.x;

        if (Mathf.Abs(distanceX) < 0.1f)
            return;

        Vector3 scale = transform.localScale;

        scale.x = distanceX < 0
            ? -Mathf.Abs(scale.x)
            : Mathf.Abs(scale.x);

        transform.localScale = scale;
    }

    public void FacePlayer()
    {
        LookAtPlayer();
    }

    protected override void Die()
    {
        base.Die();

        skillExecutor?.CancelSkill();
        attackExecutor?.CancelAttack();

        Stop();
        ExitAttackSlot();

        enemyManager?.Unregister(this);

        currentState = EnemyState.Dead;
    }

    private void OnDestroy()
    {
        skillExecutor?.CancelSkill();
        attackExecutor?.CancelAttack();

        ExitAttackSlot();

        enemyManager?.Unregister(this);
    }
}