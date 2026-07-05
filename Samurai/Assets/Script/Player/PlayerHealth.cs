using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] float invincibleTime;

    public bool isDead { get; private set; }
    bool isInvincible;

    Animator animator;
    PlayerCharge playerCharge;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerCharge = GetComponent<PlayerCharge>();
        isDead = false;
    }
    public void TakeDamage(int damage)
    {
        if(isDead||isInvincible) { return; }
        playerCharge.CancelCharge();
        hp -= damage;
        animator.SetTrigger("hurt");

        if(hp <= 0)
        {
            Die();
            return;
        }

        StartCoroutine(InvincibleRoutine());
    }

    private void Die()
    {
        isDead = true;
        animator.SetTrigger("die");
    }

    private void DestroyPlayer()
    {
        Destroy(gameObject);
    }

    public IEnumerator InvincibleRoutine()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }

    public void SetIncincible (bool value)
    {
        isInvincible = value;
    }
}
