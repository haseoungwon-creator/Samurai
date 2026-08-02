using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected int hp;
    [SerializeField] protected FleshEffect fleshEffect;
    [SerializeField] protected Animator animator;

    protected EnemyData enemyData;

    protected string enemyId;
    protected int rewardGold;

    protected bool isDead;

    public bool CanUpdateAi { get; protected set; }
    

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        fleshEffect = GetComponent<FleshEffect>();
    }

    protected virtual void Update()
    {
        UpdateVisibleState();
    }

    void UpdateVisibleState()
    {
        if (Camera.main == null)
        {
            CanUpdateAi = false;
            return;
        }

        Vector3 view = Camera.main.WorldToViewportPoint(transform.position);

        CanUpdateAi =
            view.z > 0 &&
            view.x >= 0 &&
            view.x <= 1 &&
            view.y >= 0 &&
            view.y <= 1;
    }

    public virtual void Initialize(EnemyData data)
    {
        enemyData = data;

        hp = data.maxHP;
        enemyId = data.enemyID;
        rewardGold = data.rewardGold;
    }

    public virtual void TakeDamage(int damage)
    {
        if (isDead) return;

        animator?.SetTrigger("hurt");
        fleshEffect?.Flash();

        int finalDamage = damage + PlayerStat.Instance.Power;

        hp -= finalDamage;

        if (hp <= 0)
            Die();
    }

    protected virtual void Die()
    {
        if (isDead) return;

        isDead = true;

        animator?.ResetTrigger("hurt");
        animator?.SetTrigger("die");

        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.enabled = false;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.simulated = false;
        }

        if (rewardGold > 0)
            GoldManager.Instance.AddGold(rewardGold);

        QuestManager.Instance?.AddProgress(enemyId);

        EnemySpawnManager.Instance?.RemoveEnemy(this);
    }

    public virtual void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}