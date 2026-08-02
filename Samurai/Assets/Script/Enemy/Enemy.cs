using UnityEngine;

public class Enemy : EnemyBase
{
    private Rigidbody2D rb;
    private Transform player;

    private EnemyManager enemyManager;

    private EnemyState currentState;

    private float detectRange;
    private float attackRange;
    private float attackCooldown;
    private float moveSpeed;

    private float attackTimer;

    GameObject currentHitbox;

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
            Debug.Log($"{name} : 플레이어 찾음");
        }
        else
        {
            Debug.LogError($"{name} : Player 태그를 찾지 못함");
        }
    }

    public override void Initialize(EnemyData data)
    {
        base.Initialize(data);

        detectRange = data.detectRange;
        attackRange = data.attackRange;
        attackCooldown = data.attackCooldown;
        moveSpeed = data.moveSpeed;

        currentState = EnemyState.Idle;

        Debug.Log($"{name} 초기화");
        Debug.Log($"Detect : {detectRange}");
        Debug.Log($"Attack : {attackRange}");
    }

    protected override void Update()
    {
        base.Update();

        if (isDead) return;

        if (!CanUpdateAi)
        {
            return;
        }

        if (player == null)
        {
            Debug.Log($"{name} : player null");
            return;
        }

        attackTimer -= Time.deltaTime;

        switch (currentState)
        {
            case EnemyState.Idle:
                UpdateIdle();
                break;

            case EnemyState.Chase:
                UpdateChase();
                break;

            case EnemyState.Attack:
                UpdateAttack();
                break;
        }

        LookAtPlayer();
    }

    private void UpdateIdle()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        Debug.Log($"{name} 거리 : {distance}");

        if (distance <= detectRange)
        {
            Debug.Log($"{name} 추적 시작");
            currentState = EnemyState.Chase;
        }
    }

    private void UpdateChase()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > detectRange)
        {
            currentState = EnemyState.Idle;

            rb.linearVelocity = Vector2.zero;

            animator.SetBool("run", false);

            return;
        }

        if (distance <= attackRange)
        {
            currentState = EnemyState.Attack;

            rb.linearVelocity = Vector2.zero;

            animator.SetBool("run", false);

            return;
        }

        Vector2 dir = (player.position - transform.position).normalized;

        rb.linearVelocity = dir * moveSpeed;

        animator.SetBool("run", true);
    }

    private void UpdateAttack()
    {
        rb.linearVelocity = Vector2.zero;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > attackRange)
        {
            currentState = EnemyState.Chase;
            return;
        }

        if (attackTimer > 0)
            return;

        attackTimer = attackCooldown;

        int attackIndex = Random.Range(0, enemyData.attackDatas.Length);

        animator.SetInteger("AttackIndex", attackIndex);
        animator.SetTrigger("attack");
    }

    private void LookAtPlayer()
    {
        Vector3 scale = transform.localScale;

        scale.x = player.position.x < transform.position.x
            ? -Mathf.Abs(scale.x)
            : Mathf.Abs(scale.x);

        transform.localScale = scale;
    }

    public void SpawnHitbox(int index)
    {
        if (currentHitbox != null)
            Destroy(currentHitbox);

        currentHitbox = Instantiate(enemyData.hitboxPrefab, transform.position, Quaternion.identity);

        EnemyHitbox hitbox = currentHitbox.GetComponent<EnemyHitbox>();

        float dir = transform.localScale.x < 0 ? -1 : 1;

        hitbox.Init(enemyData.attackDatas[index], enemyData, dir);
    }

    public void DestroyHitbox()
    {
        if (currentHitbox != null)
        {
            Destroy(currentHitbox);
            currentHitbox = null;
        }
    }

    protected override void Die()
    {
        base.Die();

        rb.linearVelocity = Vector2.zero;

        enemyManager?.Unregister(this);

        currentState = EnemyState.Dead;
    }

    private void OnDestroy()
    {
        enemyManager?.Unregister(this);
    }
}