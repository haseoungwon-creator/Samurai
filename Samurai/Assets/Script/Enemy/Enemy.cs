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

        if (obj!= null)
        {
            player = obj.transform;
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
    }

    private void Update()
    {
        if(isDead) return;

        if (!CanUpdateAi) return;

        if(player == null) return;

        if(!IsPlayerVisible()) return;

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

    private bool IsPlayerVisible()
    {
        Vector3 viewport = Camera.main.WorldToViewportPoint(player.position);

        return viewport.x > 0 && viewport.x < 1 && viewport.y > 0 && viewport.y < 1;
    }

    private void UpdateIdle()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectRange)
            currentState = EnemyState.Chase;
    }

    private void UpdateChase()
    {
float distance = Vector2.Distance(transform.position,player.position);

        if(distance > detectRange)
        {
            currentState = EnemyState.Idle;

            rb.linearVelocity = Vector2.zero;

            animator.SetBool("run",false);

            return;
        }

        if(distance <= attackRange)
        {
            currentState = EnemyState.Attack;

            rb.linearVelocity = Vector2.zero;

            animator.SetBool("run", false);

            return;
        }

        Vector2 dir = (player.position - transform.position).normalized;

        rb.linearVelocity = dir * moveSpeed;

        animator.SetBool("run",true);
    }

    private void UpdateAttack()
    {
        rb.linearVelocity = Vector2.zero;

        float distance = Vector2.Distance(transform.position, player.position);

        if(distance > attackRange)
        {
            currentState = EnemyState.Chase;
            return;
        }

        if (attackTimer > 0) return;

        attackTimer = attackCooldown;

        animator.SetTrigger("attack");
    }

    private void LookAtPlayer()
    {
        Vector3 scale = transform.localScale;

        scale.x = player.position.x > transform.position.x ? -Mathf.Abs(scale.x) : Mathf.Abs(scale.x);

        transform.localScale = scale;
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
