using UnityEngine;
public class PlayerAttackInput : MonoBehaviour
{
    PlayerStateMachine stateMachine;
    PlayerAttack playerAttack;
    PlayerDash playerDash;
    PlayerCharge playerCharge;
    PlayerHealth playerHealth;
    PlayerMove playerMove;
    private void Awake()
    {
        stateMachine = GetComponent<PlayerStateMachine>();
        playerAttack = GetComponent<PlayerAttack>();
        playerDash = GetComponent<PlayerDash>();
        playerCharge = GetComponent<PlayerCharge>();
        playerHealth = GetComponent<PlayerHealth>();
        playerMove = GetComponent<PlayerMove>();
    }
    private void Update()
    {
        if (GameManager.Instance.Currentstate == GameState.Story || playerHealth.isDead) return;
        HandleDashInput();
        HandleAttackInput();
        HandleMouveInput();
    }
    private void HandleDashInput()
    {
        if (Input.GetMouseButtonDown(1))
        {
            playerDash.TryDash();
        }

        if(stateMachine.CurrentState== PlayerState.Dash)
        {
            if(Input.GetMouseButtonDown(0))
            {
                playerDash.QueueDashAttack();
            }

            return;
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
    private void HandleMouveInput()
    {
       playerMove.SetMoveInput(Input.GetAxisRaw("Horizontal"));
    }
}