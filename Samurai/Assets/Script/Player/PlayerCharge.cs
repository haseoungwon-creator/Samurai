using UnityEngine;

public class PlayerCharge : MonoBehaviour
{
    [SerializeField] float chargeTime;
    [SerializeField] AttackData chargeAttackData;
    public bool isCharging {  get; private set; }
    public bool isCharged {  get; private set; }

    float chargeTimer;

    PlayerAnimator playerAnimator;
    

    private void Awake()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    public void StartCharge()
    {

        if (!PlayerStateMachine.Instance.CanCharge()) return;
        if(isCharging) return;
        chargeTimer = 0;
        isCharging = true;
        isCharged = false;
    }

    public void Charging()
    {
        if (PlayerStateMachine.Instance.CurrentState != PlayerState.Idle && PlayerStateMachine.Instance.CurrentState != PlayerState.Charge) return;
        
        if(!isCharging || isCharged) return;
        PlayerStateMachine.Instance.ChangeState(PlayerState.Charge);
        chargeTimer += Time.deltaTime;
        if(chargeTimer >= chargeTime)
        {
            isCharged = true;
            PlayerStateMachine.Instance.ChangeState(PlayerState.ChargeFull);
            playerAnimator.TriggerChargeAttack();
        }
    }

    public void ReleaseCharge()
    {
        if(!isCharged) return;
        
        isCharging = false;
        isCharged= false;

        PlayerStateMachine.Instance.ChangeState(PlayerState.ChargeAttack);

        Debug.Log("stateMachine 상태: " + PlayerStateMachine.Instance.CurrentState);
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
        PlayerStateMachine.Instance.ChangeState(PlayerState.Idle);
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
        PlayerStateMachine.Instance.ChangeState(PlayerState.Idle);
    }
}
