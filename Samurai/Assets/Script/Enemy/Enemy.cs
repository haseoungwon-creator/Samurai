using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] FleshEffect fleshEffect;
    [SerializeField] string enemyId;
    EnemyManager enemyManager;
    Animator animator;
    bool isDead = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();  
        fleshEffect = GetComponent<FleshEffect>();
        enemyManager = FindAnyObjectByType<EnemyManager>();
    }
    private void Start()
    {
        enemyManager.Register(this);
        
    }


    private void OnDestroy()
    {
        if(enemyManager != null)
        enemyManager.Unregister(this);
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;
        animator.SetTrigger("hurt");
        damage += PlayerStat.Instance.Power;
        fleshEffect.Flash();
        hp -= damage;
        Debug.Log(hp);
        if (hp <= 0) Die();
    }

    public void Die()
    {
        isDead = true;
        animator.ResetTrigger("hurt");
        animator.SetTrigger("die");
        enemyManager.Unregister(this);
        GetComponent<Collider2D>().enabled = false;
        QuestManager.Instance.AddProgress(enemyId);
    }

    public void DestoryEnemy()
    {
        Destroy(gameObject);
    }
}
