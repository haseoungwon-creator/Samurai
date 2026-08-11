using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] float invincibleTime;

    public bool isDead { get; private set; }
    bool isInvincible;
    public int CurrentHP => hp;
    public float HpPercent => (float)hp / PlayerStat.Instance.MaxHp;


    Animator animator;
    PlayerCharge playerCharge;
    PlayerAttack playerAttack;
    PlayerDefend playerDefend;
    FleshEffect fleshEffect;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerCharge = GetComponent<PlayerCharge>();
        playerAttack = GetComponent<PlayerAttack>();
        playerDefend = GetComponent<PlayerDefend>();
        fleshEffect = GetComponent<FleshEffect>();
        isDead = false;

        if(GameManager.Instance.PlayerHp <= 0)
        {
            hp = PlayerStat.Instance.MaxHp;
            GameManager.Instance.SetInitialPlauerHp(hp);
        }
        else
        {
            hp = GameManager.Instance.PlayerHp;
        }
        
    }

    private void Start()
    {
        GameManager.Instance.SetPlayer(gameObject);
    }
    public void TakeDamage(int damage, Enemy attacker = null)
    {
        if (playerDefend.isDefending)
        {
            playerDefend.TryGuard(attacker);
            return;
        }
        if(isDead||isInvincible) { return; }
        animator.SetInteger("attackstate", 0);
        playerCharge.CancelCharge();
        playerAttack.CancelAttack();
        int finalDamage = Mathf.Max(0, damage - PlayerStat.Instance.Defense);
        hp -= finalDamage;
        GameManager.Instance.SetPlayerHP(hp);
        Debug.Log(hp);
        CameraStateMachine.Instance.ChangeState(CameraState.TakeDamageMove);
        fleshEffect.Flash();
        animator.SetTrigger("hurt");
        

        if(hp <= 0)
        {
            GameManager.Instance.SetPlayerHP(hp);
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

    public void TriggerGameOver()
    {

        animator.speed = 0f;
        GameOverManager.Instance.ShowGameOver();
    
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

        GameManager.Instance.SetPlayerHP(hp);
    }
}
