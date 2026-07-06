using UnityEngine;

public class PlayerCharge : MonoBehaviour
{
    [SerializeField] float chargeTime;
    [SerializeField] AttackData chargeAttackData;
    public bool isCharging {  get; private set; }
    public bool isCharged {  get; private set; }

    float chargeTimer;

    Animator animator;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void StartCharge()
    {
        if(isCharging) return;
        chargeTimer = 0;
        isCharging = true;
        isCharged = false;
    }

    public void Charging()
    {
        if(!isCharging) return;
        if (isCharged) return;

        chargeTimer += Time.deltaTime;
        if(chargeTimer >= chargeTime)
        {
            isCharged = true;
            animator.SetTrigger("charge");
        }
    }

    public void ReleaseCharge()
    {
        if(!isCharged) return;
        
        isCharging = false;
        isCharged= false;

        animator.SetTrigger("chargeattack");
    }

    public void PerformChargeAttack()
    {
        if(isCharging) return;
        float direction = transform.localScale.x > 0 ? 1f : -1f;

        GameObject hitbox = Instantiate(chargeAttackData.hitboxPrefab, transform.position, Quaternion.identity);

        hitbox.GetComponent<Hitbox>().Init(chargeAttackData, direction);
    }

    public void EndChargeAttack()
    {
        ResetCharge();
    }
    public void CancelCharge()
    {
        ResetCharge();
    }

    void ResetCharge()
    {
        isCharged = false;
        isCharging = false;
        chargeTimer = 0;
    }
}
