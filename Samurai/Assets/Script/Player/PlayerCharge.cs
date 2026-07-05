using UnityEngine;

public class PlayerCharge : MonoBehaviour
{
    [SerializeField] float chargeTime;
    [SerializeField] AttackData chargeAttackData;
    public bool isCharging {  get; private set; }
    public bool isCharged {  get; private set; }

    float chargeTimer;

    Animator animator;
    Rigidbody2D rb;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void StartCharge()
    {
        chargeTimer = 0;
        isCharging = false;
        isCharged = false;
    }

    public void Charging()
    {
        if (isCharged) return;

        chargeTimer += Time.deltaTime;
        if(chargeTimer >= chargeTime)
        {
            isCharging = true;
            isCharged = true;

            rb.linearVelocity = Vector2.zero;
            animator.SetTrigger("charge");
        }
    }

    public void EndCharge()
    {
        if (!isCharged) return;

            ReleaseCharge();
    }
    private void ReleaseCharge()
    {
        animator.SetTrigger("chargeattack");
        float direction = transform.localScale.x > 0 ? 1f : -1f;
        GameObject hitbox = Instantiate(chargeAttackData.hitboxPrefab, transform.position, Quaternion.identity);
        hitbox.GetComponent<Hitbox>().Init(chargeAttackData, direction);

        chargeTimer = 0;
        isCharging = false;
        isCharged = false;
    }

    public void CancelCharge()
    {
        isCharged = false;
        isCharging = false;
        chargeTimer = 0;
        animator.ResetTrigger("charge");
    }
}
