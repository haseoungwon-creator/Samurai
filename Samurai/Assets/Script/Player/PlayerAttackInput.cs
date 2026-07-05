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
        if (GameManager.Instance.Currentstate == GameState.Story) return;
        if(playerHealth.isDead) return;

        if (Input.GetMouseButtonDown(1)&& !playerCharge.isCharging)
        {
            
            playerDash.Dash();
        }

        if (playerDash.isDashing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                playerDash.QueueDashAttack();
            }

            return;
        }

        if (Input.GetMouseButtonDown(0)&&!playerCharge.isCharging)
        {
            playerCharge.StartCharge();
        }

        if (Input.GetMouseButton(0))
        {
            playerCharge.Charging();
            return;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (playerDash.dashAttackQueued) return;
            Debug.Log("Mouse Up");
            if (playerCharge.isCharged)
            {
                playerCharge.EndCharge();
                return;
            }
            else if(!playerDash.isDashing)
            {
                playerCharge.CancelCharge();
                playerAttack.OnAttackInput();
                return;
            }
        }
    }
}
