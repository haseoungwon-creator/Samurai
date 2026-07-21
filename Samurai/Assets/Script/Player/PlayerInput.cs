using UnityEngine;
public class PlayerInput : MonoBehaviour
{
    PlayerAttack playerAttack;
    PlayerDash playerDash;
    PlayerCharge playerCharge;
    PlayerHealth playerHealth;
    PlayerMove playerMove;
    PlayerDefend playerDefend;
    [SerializeField]ItemData testItem;
    [SerializeField] InventoryUI inventoryUI;
    [SerializeField] PauseManager pauseManager;
    private void Awake()
    {
        playerAttack = GetComponent<PlayerAttack>();
        playerDash = GetComponent<PlayerDash>();
        playerCharge = GetComponent<PlayerCharge>();
        playerHealth = GetComponent<PlayerHealth>();
        playerMove = GetComponent<PlayerMove>();
        playerDefend = GetComponent<PlayerDefend>();
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Inventory.Instance.AddItem(testItem);

        }

        if(Input.GetKey(KeyCode.G))
        {
            GoldManager.Instance.AddGold(100);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GoldManager.Instance.UseGold(300);
        }
        Pause();

        HandleMouveInput();

        if(MouseManager.Instance.ismMouse) return;
        if (inventoryUI.isOpen) return;
        if (GameManager.Instance.Currentstate != GameState.Playing || playerHealth.isDead)
            return;

        HandleDashInput();

        if (PlayerStateMachine.Instance.CurrentState == PlayerState.Dash)
            return;

        HandleDefendInput();

        if (PlayerStateMachine.Instance.CurrentState == PlayerState.Defend)
            return;

        HandleAttackInput();
        
    }

    private void Pause()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {

            PanelManaager.Instance.Open(panel.Pause);
            pauseManager = FindAnyObjectByType<PauseManager>();
            pauseManager.Pause();

        }
    }
    private void HandleDashInput()
    {
        if (Input.GetMouseButtonDown(1))
        {
            playerDash.TryDash();
        }

        if (PlayerStateMachine.Instance.CurrentState == PlayerState.Dash)
        {
            if (Input.GetMouseButtonDown(0))
            {
                playerDash.QueueDashAttack();
            }

            return;
        }
    }

    private void HandleDefendInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerDefend.StartDefend();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerDefend.StopDefend();
        }
    }
    private void HandleAttackInput()
    {
        if (PlayerStateMachine.Instance.CurrentState == PlayerState.Dash) return;
        if (Input.GetMouseButtonDown(0))
        {
            if (PlayerStateMachine.Instance.CanCharge())
            {
                playerCharge.StartCharge();
            }

            else if (PlayerStateMachine.Instance.CurrentState == PlayerState.Attack)
            {
                playerAttack.TryAttack();
            }
        }
        if (Input.GetMouseButton(0))
        {
            playerCharge.Charging();
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (PlayerStateMachine.Instance.CurrentState == PlayerState.Charge)
            {
                playerCharge.CancelCharge();
                playerAttack.TryAttack();
                return;
            }

            //else if (PlayerStateMachine.Instance.CurrentState == PlayerState.ChargeFull)
            //{
            //    playerCharge.ReleaseCharge();
            //    return;
            //}
        }
    }
    private void HandleMouveInput()
    {
        playerMove.SetMoveInput(Input.GetAxisRaw("Horizontal"));
    }
}