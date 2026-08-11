using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected Animator animator;
    [SerializeField] protected FleshEffect fleshEffect;
    [SerializeField] protected int hp;

    protected EnemyData enemyData;
    protected string enemyId;
    protected int rewardGold;
    protected bool isDead;

    public bool CanUpdateAi { get; protected set; }
    public EnemyData Data => enemyData;
    public int CurrentHP => hp;
    public bool IsDead => isDead;

    protected virtual void Awake()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        if (animator == null)
            animator = GetComponentInChildren<Animator>();

        if (fleshEffect == null)
            fleshEffect = GetComponent<FleshEffect>();
    }

    protected virtual void Update()
    {
        UpdateVisibleState();
    }

    private void UpdateVisibleState()
    {
        Camera mainCamera = Camera.main;

        if (mainCamera == null)
        {
            CanUpdateAi = false;
            return;
        }

        Vector3 view = mainCamera.WorldToViewportPoint(transform.position);

        CanUpdateAi =
            view.z > 0f &&
            view.x >= 0f &&
            view.x <= 1f &&
            view.y >= 0f &&
            view.y <= 1f;
    }

    public virtual void Initialize(EnemyData data)
    {
        if (data == null)
            return;

        enemyData = data;
        hp = data.maxHP;
        enemyId = data.enemyID;
        rewardGold = data.rewardGold;
        isDead = false;
        CanUpdateAi = false;
    }

    public virtual void TakeDamage(int damage)
    {
        if (isDead || damage <= 0)
            return;

        fleshEffect?.Flash();

        int finalDamage = damage;

        if (PlayerStat.Instance != null)
            finalDamage += PlayerStat.Instance.Power;

        hp -= finalDamage;

        if (hp <= 0)
        {
            hp = 0;
            Die();
            return;
        }

        OnHurt();
    }

    protected virtual void OnHurt()
    {
    }

    protected virtual void Die()
    {
        if (isDead)
            return;

        isDead = true;

        if (animator != null)
        {
            animator.ResetTrigger("hurt");

            if (HasAnimatorParameter("run"))
                animator.SetBool("run", false);

            if (HasAnimatorParameter("die"))
                animator.SetTrigger("die");
        }

        Collider2D collider = GetComponent<Collider2D>();

        if (collider != null)
            collider.enabled = false;

        Rigidbody2D body = rb != null ? rb : GetComponent<Rigidbody2D>();

        if (body != null)
        {
            body.linearVelocity = Vector2.zero;
            body.simulated = false;
        }

        if (rewardGold > 0 && GoldManager.Instance != null)
            GoldManager.Instance.AddGold(rewardGold);

        if (!string.IsNullOrEmpty(enemyId))
            QuestManager.Instance?.AddProgress(enemyId);

        EnemySpawnManager.Instance?.RemoveEnemy(this);
    }

    public virtual void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    protected bool HasAnimatorParameter(string parameterName)
    {
        if (animator == null)
            return false;

        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            if (parameter.name == parameterName)
                return true;
        }

        return false;
    }
}
