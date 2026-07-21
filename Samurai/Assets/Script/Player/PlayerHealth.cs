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
    PlayerDefend playerDefend;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerCharge = GetComponent<PlayerCharge>();
        playerDefend = GetComponent<PlayerDefend>();
        isDead = false;
        hp = PlayerStat.Instance.MaxHp;
    }
    public void TakeDamage(int damage, Enemy attacker = null)
    {
        if (playerDefend.isDefending)
        {
            playerDefend.TryGuard(attacker);
            return;
        }
        if(isDead||isInvincible) { return; }
        playerCharge.CancelCharge();
        int finalDamage = Mathf.Max(0, damage - PlayerStat.Instance.Defense);
        hp -= finalDamage;
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
        yield return CoroutineManager.Wait(invincibleTime);
        isInvincible = false;
    }

    public void SetIncincible (bool value)
    {
        isInvincible = value;
    }

    public void Heal(int amount)
    {
        if (isDead) return;

        hp += amount;

        if (hp > PlayerStat.Instance.MaxHp)
        {
            hp = PlayerStat.Instance.MaxHp;
        }
    }
}
