using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] FleshEffect fleshEffect;
    [SerializeField] string enemyId;
    [SerializeField] int rewardGold;

    EnemyManager enemyManager;
    Animator animator;

    EnemyData enemyData;

    bool returnVillage;
    bool isDead = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        fleshEffect = GetComponent<FleshEffect>();
        enemyManager = FindAnyObjectByType<EnemyManager>();
    }
    private void Start()
    {
        if(enemyManager != null)
        enemyManager.Register(this);
        
    }


    private void OnDestroy()
    {
        if(enemyManager != null)
        enemyManager.Unregister(this);
    }

    public void Initialize(EnemyData data)
    {
        if (data == null) return;

        hp = data.maxHP;
        enemyId = data.enemyID;
        rewardGold = data.rewardGold;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        if (animator != null)
            animator.SetTrigger("hurt");

        if (fleshEffect != null)
            fleshEffect.Flash();

        hp -= damage;
        Debug.Log(hp);

        if (hp <= 0) Die();
    }

    public void Die()
    {
        if(isDead) return;

        isDead = true;

        if (animator != null)
        {
            animator.ResetTrigger("hurt");
            animator.SetTrigger("die");
        }

        GetComponent<Collider2D>().enabled = false;

        if(enemyManager != null)
        {
            enemyManager.Unregister(this);
        }

        if(rewardGold > 0)
        {
            GoldManager.Instance.AddGold(rewardGold);
        }

        if(QuestManager.Instance!= null)
        {
            QuestManager.Instance.AddProgress(enemyId);
        }

        

        if(EnemySpawnManager.Instance != null)
        {
            EnemySpawnManager.Instance.RemoveEnemy(this);
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
