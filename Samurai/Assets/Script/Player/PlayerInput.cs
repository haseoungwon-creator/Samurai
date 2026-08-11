using UnityEngine;
public class PlayerInput : MonoBehaviour
{
    PlayerAttack playerAttack;
    PlayerDash playerDash;
    PlayerCharge playerCharge;
    PlayerHealth playerHealth;
    PlayerMove playerMove;
    PlayerDefend playerDefend;
    PlayerStun playerStun;
    
    EnemyManager enemyManager;

    [SerializeField]ItemData testItem;
    [SerializeField] InventoryUI inventoryUI;
    [SerializeField] PauseManager pauseManager;
    [SerializeField] QuestData quest;

    MouseManager mouseManager;
    private void Awake()
    {
        playerAttack = GetComponent<PlayerAttack>();
        playerDash = GetComponent<PlayerDash>();
        playerCharge = GetComponent<PlayerCharge>();
        playerHealth = GetComponent<PlayerHealth>();
        playerMove = GetComponent<PlayerMove>();
        playerDefend = GetComponent<PlayerDefend>();
        mouseManager = FindAnyObjectByType<MouseManager>();
        playerStun = GetComponent<PlayerStun>();
        
        enemyManager = FindAnyObjectByType<EnemyManager>();
        
    }
    private void Update()
    {
        if (GameManager.Instance == null) return;
        if(inventoryUI == null)
        {
            inventoryUI = FindAnyObjectByType<InventoryUI>();
        }
        if(pauseManager == null)
        {
            pauseManager = FindAnyObjectByType<PauseManager>();
        }

        if (inventoryUI != null && inventoryUI.isOpen) return;

        if (GameManager.Instance.CurrentState == GameState.GameOver) return;

        if (GameManager.Instance.CurrentState == GameState.Pause) return;
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

        if (Input.GetKeyDown(KeyCode.N))
        {
            QuestManager.Instance.AddProgress("enemies");
        }

        if (GameManager.Instance.CurrentState == GameState.GameOver) return;

        Pause();

        if (enemyManager != null && enemyManager.IsAnyEnemyUsingDashAttackCombo())
        {
            playerMove.SetMoveInput(0f);
            return;
        }
            
        if (playerStun != null && playerStun.IsStunned)
        {
            return;
        }
        if (GameManager.Instance.CurrentState == GameState.Pause) return;

        HandleMouveInput();

        if(mouseManager.ismMouse) return;
        if (inventoryUI != null && inventoryUI.isOpen) return;
        if (GameManager.Instance.CurrentState != GameState.Playing || playerHealth.isDead)
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
        if (GameManager.Instance == null || GameManager.Instance.CurrentState == GameState.GameOver) return;

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