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

    public bool CanUpdateAi {  get; protected set; }

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        fleshEffect = GetComponent<FleshEffect>();
    }

    public virtual void Initialize(EnemyData data)
    {
        enemyData = data;

        hp = data.maxHP;
        enemyId = data.enemyID;
        rewardGold = data.rewardGold;
    }

    public  virtual void TakeDamage(int damage)
    {
        if (isDead) return;

        if (animator != null)
            animator.SetTrigger("hurt");

        if (fleshEffect != null)
            fleshEffect.Flash();

        int finalDamage = damage + PlayerStat.Instance.Power;

        hp -= finalDamage;

        if (hp <= 0)
            Die();
    }

    protected virtual void Die()
    {
        if(isDead) return;

        isDead= true;

        if(animator != null)
        {
            animator.ResetTrigger("hurt");
            animator.SetTrigger("die");
        }

        Collider2D  col = GetComponent<Collider2D>();

        if(col != null)
            col.enabled = false;

        if(rewardGold > 0)
            GoldManager.Instance.AddGold(rewardGold);

        if (QuestManager.Instance != null)
            QuestManager.Instance.AddProgress(enemyId);

        if (EnemySpawnManager.Instance != null)
            EnemySpawnManager.Instance.RemoveEnemy(this);
    }

    public virtual void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnBecameVisible()
    {
        CanUpdateAi = true;
    }

    private void OnBecameInvisible()
    {
        CanUpdateAi = false;
    }
}
