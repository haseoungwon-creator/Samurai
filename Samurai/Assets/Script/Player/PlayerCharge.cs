using UnityEngine;

public class PlayerCharge : MonoBehaviour
{
    [SerializeField] float chargeTime;
    [SerializeField] AttackData chargeAttackData;
    public bool isCharging {  get; private set; }
    public bool isCharged {  get; private set; }

    float chargeTimer;

    PlayerAnimator playerAnimator;
    PlayerStateMachine stateMachine;
    

    private void Awake()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        stateMachine = GetComponent<PlayerStateMachine>();
    }

    public void StartCharge()
    {

        if (!stateMachine.CanCharge()) return;
        if(isCharging) return;
        chargeTimer = 0;
        isCharging = true;
        isCharged = false;
    }

    public void Charging()
    {
        if (stateMachine.CurrentState != PlayerState.Idle && stateMachine.CurrentState != PlayerState.Charge) return;
        
        if(!isCharging || isCharged) return;
        stateMachine.ChangeState(PlayerState.Charge);
        chargeTimer += Time.deltaTime;
        if(chargeTimer >= chargeTime)
        {
            isCharged = true;
            stateMachine.ChangeState(PlayerState.ChargeFull);
            playerAnimator.TriggerChargeAttack();
        }
    }

    public void ReleaseCharge()
    {
        if(!isCharged) return;
        
        isCharging = false;
        isCharged= false;

        stateMachine.ChangeState(PlayerState.ChargeAttack);

        Debug.Log("stateMachine 상태: " + stateMachine.CurrentState);
        Debug.Log("Instance 상태: " + PlayerStateMachine.Instance.CurrentState);
        playerAnimator.TriggerChargeAttack();
    }

    public void PerformChargeAttack()
    {
        float direction = transform.localScale.x > 0 ? 1 : -1;
        GameObject hitbox = Instantiate(chargeAttackData.hitboxPrefab,transform.position, Quaternion.identity);
        hitbox.GetComponent<Hitbox>().Init(chargeAttackData, direction);
    }


    public void EndChargeAttack()
    {
        stateMachine.ChangeState(PlayerState.Idle);
        ResetCharge();
    }
    public void CancelCharge()
    {
        if(!isCharging) return;
        ResetCharge();
    }

    void ResetCharge()
    { 
        isCharged = false;
        isCharging = false;
        chargeTimer = 0;
        playerAnimator.ResetTriggerCharge();
        stateMachine.ChangeState(PlayerState.Idle);
    }
}
