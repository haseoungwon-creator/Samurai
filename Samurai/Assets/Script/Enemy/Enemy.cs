using UnityEngine;
using System.Collections;

public class Enemy : EnemyBase
{
    private Rigidbody2D rb;
    private Transform player;

    private EnemyManager enemyManager;

    private EnemyState currentState;

    private float detectRange;
    private float attackRange;
    private float moveSpeed;

    private float pressurDistance;
    private float pressureSpeed;

    private float minAttackCooldown;
    private float maxAttackCooldown;

    private float recoverTiem;

    private float attackPrepareTiem;

    private float attackLungeSpeed;
    private float attackLungeTime;

    private float attackTimer;
    private float recoverTimer;
    private bool hasAttackSlot;
    private bool isPreparingAttack;
    private float prepareTimer;
    private GameObject currentHitbox;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
        enemyManager = FindAnyObjectByType<EnemyManager>();
    }

    private void Start()
    {
        enemyManager?.Register(this);

        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        if (obj != null)
        {
            player = obj.transform;
        }
    }

    public override void Initialize(EnemyData data)
    {
        base.Initialize(data);

        detectRange = data.detectRange;
        attackRange = data.attackRange;

        moveSpeed = data.moveSpeed;

        pressurDistance = data.pressureDistance;
        pressureSpeed = data.pressureSpeed;

        minAttackCooldown = data.minAttackCooldown;
        maxAttackCooldown = data.maxAttackCooldown;

        recoverTiem = data.recoverTime;

        attackPrepareTiem = data.attackPrepareTime;

        attackLungeSpeed = data.attackLungeSpeed;
        attackLungeTime = data.attackLungeTime;

        currentState = EnemyState.Idle;
    }

    protected override void Update()
    {
        base.Update();

        if (isDead) return;

        if (!CanUpdateAi) return;

        if (player == null) return;

        attackTimer -= Time.deltaTime;

        switch (currentState)
        {
            case EnemyState.Idle: UpdateIdle(); break;
            case EnemyState.Chase: UpdateChase(); break;
            case EnemyState.Pressure: UpdatePressure(); break;
            case EnemyState.Attack: UpdateAttack(); break;
            case EnemyState.Recover: UpdateRecover(); break;
        }
        LookAtPlayer();
    }

    private void UpdateIdle()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectRange)
        {
            currentState = EnemyState.Chase;
        }
    }

    private void UpdateChase()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > detectRange)
        {
            EnterIdle();
            return;
        }

        if (distance <= attackRange)
        {
            EnterPressure();
            return;
        }

        Vector2 dir = (player.position - transform.position).normalized;

        rb.linearVelocity = dir * moveSpeed;
        animator.SetBool("run", true);
    }

    private void EnterIdle()
    {
        currentState = EnemyState.Idle;
        rb.linearVelocity = Vector2.zero;
        animator.SetBool("run", false);
        ExitAttackSlot();
    }

    private void EnterPressure()
    {
        currentState = EnemyState.Pressure;
        animator.SetBool("run", true);
        attackTimer = Random.Range(0.15f, 0.45f);
    }

    private void UpdatePressure()
    {
        float distance = Vector2.Distance(transform.position, player.position);

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

        if (!hasAttackSlot)
        {
            hasAttackSlot = enemyManager == null || enemyManager.RequesAttack(this);
        }

        if (!hasAttackSlot)
        {
            PressureMove(distance);
            return;
        }

        if (attackTimer > 0)
        {
            PressureMove(distance);
            return;
        }

        EnterAttack();
    }

    private void PressureMove(float distance)
    {
        float dir = player.position.x > transform.position.x ? 1f : -1f;

        float diff = distance - pressurDistance;

        Vector2 velocity = Vector2.zero;

        if (diff > 0.15f)
        {
            velocity.x = dir * pressureSpeed;
        }

        else if (diff < -0.15f)
        {
            velocity.x = -dir * pressureSpeed;
        }
        else
        {
            velocity.x = Mathf.Sin(Time.time * 6f) * 0.5f;
        }

        rb.linearVelocity = velocity;

        animator.SetBool("run", Mathf.Abs(rb.linearVelocity.x) > 0.05f);
    }

    private void EnterAttack()
    {
        currentState = EnemyState.Attack;
        animator.SetBool("run", false);
        rb.linearVelocity = Vector2.zero;
        prepareTimer = attackPrepareTiem;
        isPreparingAttack = true;
    }

    private void UpdateAttack()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > attackRange + 0.5f)
        {
            ExitAttackSlot();
            currentState = EnemyState.Chase;
            return;
        }

        if (isPreparingAttack)
        {
            prepareTimer -= Time.deltaTime;

            if (prepareTimer <= 0)
            {
                isPreparingAttack = false;

                int attackIndex = Random.Range(0, enemyData.attackDatas.Length);

                animator.SetInteger("AttackIndex", attackIndex);
                animator.SetTrigger("attack");
                StartCoroutine(Lunge());
            }
            return;
        }
    }

    private IEnumerator Lunge()
    {
        float timer = attackLungeTime;

        float dir = transform.localScale.x > 0 ? 1f : -1f;

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            rb.linearVelocity = new Vector2(dir * attackLungeSpeed, rb.linearVelocity.y);

            yield return null;
        }

        rb.linearVelocity = Vector2.zero;
    }

    private void UpdateRecover()
    {
        recoverTimer -= Time.deltaTime;
        if (recoverTimer <= 0f)
        {
            attackTimer = Random.Range(minAttackCooldown, maxAttackCooldown);
            currentState = EnemyState.Pressure;
        }
    }

    public void SpawnHitbox(int index)
    {
        if (currentHitbox != null)
            Destroy(currentHitbox);

        currentHitbox = Instantiate(enemyData.hitboxPrefab, transform.position, Quaternion.identity);

        EnemyHitbox hitbox = currentHitbox.GetComponent<EnemyHitbox>();

        float dir = transform.localScale.x > 0 ? 1f : -1f;

        hitbox.Init(enemyData.attackDatas[index], enemyData, dir);
    }

    public void DestroyHitbox()
    {
        if (currentHitbox == null) return;

        Destroy(currentHitbox);

        currentHitbox = null;
    }

    public void AttackFinish()
    {
        recoverTimer = recoverTiem;
        currentState = EnemyState.Recover;
    }

    private void ExitAttackSlot()
    {
        if (!hasAttackSlot) return;

        enemyManager?.ReleaseAttack(this);

        hasAttackSlot = false;
    }

    private void LookAtPlayer()
    {
        if(player == null) return;

        Vector3 scale = transform.localScale;

        if(player.position.x < transform.localScale.x)
            scale.x = -Mathf.Abs(scale.x);
        else
            scale.x = Mathf.Abs(scale.x);

        transform.localScale = scale;
    }

    protected override void Die()
    {
        base.Die();
        rb.linearVelocity = Vector2.zero;
        ExitAttackSlot();
        enemyManager?.Unregister(this);
        currentState = EnemyState.Dead;
    }

    private void OnDestroy()
    {
        ExitAttackSlot();
        enemyManager?.Unregister(this);
    }
}