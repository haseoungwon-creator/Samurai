using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{
    PlayerAttack playerAttack;
    PlayerCharge playerCharge;
    PlayerDash playerDash;
    PlayerHealth playerHealth;

    private void Awake()
    {
        playerAttack = GetComponent<PlayerAttack>();
        playerCharge = GetComponent<PlayerCharge>();
        playerDash = GetComponent<PlayerDash>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if(GameManager.Instance.Currentstate == GameState.Story || playerHealth.isDead) return;

        HandleDashInput();
        HandleAttackInput();
    }

    void HandleDashInput()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(!playerCharge.isCharged)
                playerDash.Dash();
        }

        if(playerDash.isDashing && Input.GetMouseButtonDown(0))
        {
            playerDash.QueueDashAttack();
        }

    }

    void HandleAttackInput()
    {
        if (playerDash.isDashing) return;

        if (playerCharge.isCharging || playerCharge.isCharged)
        {
            if (Input.GetMouseButton(0))
            {
                playerCharge.Charging();
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (playerCharge.isCharged)
                    playerCharge.ReleaseCharge();
                else
                    playerCharge.CancelCharge();
            }   
        }

        if(Input.GetMouseButtonDown(0))
        {
            playerCharge.StartCharge();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Attack Input Detected");
            playerAttack.OnAttackInput();
        }
    }



}
