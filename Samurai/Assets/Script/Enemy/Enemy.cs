using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hp;
    Animator animator;
    bool isDead = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();    
    }
    private void Start()
    {
        EnemyManager.Instance.Register(this);
        
    }


    private void OnDisable()
    {
        if(EnemyManager.Instance != null)
        EnemyManager.Instance.Unregister(this);
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;
        animator.SetTrigger("hurt");
        hp -= damage;
        Debug.Log(hp);
        if (hp <= 0) Die();
    }

    public void Die()
    {
        isDead = true;
        animator.ResetTrigger("hurt");
        animator.SetTrigger("die");
        EnemyManager.Instance.Unregister(this);
        GetComponent<Collider2D>().enabled = false;
    }

    public void DestoryEnemy()
    {
        Destroy(gameObject);
    }
}
