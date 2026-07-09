using UnityEngine;
public class PlayerAttackInput : MonoBehaviour
{
    PlayerStateMachine stateMachine;
    PlayerAttack playerAttack;
    PlayerDash playerDash;
    PlayerCharge playerCharge;
    PlayerHealth playerHealth;
    private void Awake()
    {
        stateMachine = GetComponent<PlayerStateMachine>();
        playerAttack = GetComponent<PlayerAttack>();
        playerDash = GetComponent<PlayerDash>();
        playerCharge = GetComponent<PlayerCharge>();
        playerHealth = GetComponent<PlayerHealth>();
    }
    private void Update()
    {
        if (GameManager.Instance.Currentstate == GameState.Story || playerHealth.isDead) return;
        HandleDashInput();
        HandleAttackInput();
    }
    private void HandleDashInput()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //playerDash.TryDash();
        }
    }
    private void HandleAttackInput()
    {
        if (stateMachine.CurrentState == PlayerState.Dash) return;
        if (Input.GetMouseButtonDown(0))
        {
            playerCharge.StartCharge();
        }
        if (Input.GetMouseButton(0))
        {
            playerCharge.Charging();
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (stateMachine.CurrentState == PlayerState.ChargeFull)
            {
                playerCharge.ReleaseCharge();
            }
            else
            {
                playerCharge.CancelCharge();
                playerAttack.TryAttack();
            }
        }
    }
}