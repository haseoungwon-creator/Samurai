using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;

    Animator animator;

    PlayerHealth playerHealth;

    PlayerDash playerDash;

    PlayerCharge playerCharge;

    PlayerDefend playerDefen;
    
    InventoryUI inventoryUI;

    float x;

    [SerializeField] float footstepInterval = 0.12f;

    float footstepCooldown;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();
        playerDash = GetComponent<PlayerDash>();
        playerCharge = GetComponent<PlayerCharge>();
        playerDefen = GetComponent<PlayerDefend>();
        GameManager.Instance.SetState(GameState.Playing);
        inventoryUI = FindAnyObjectByType<InventoryUI>();

    }
    private void Update()
    {

        if (GameManager.Instance.CurrentState == GameState.Story || playerHealth.isDead || playerCharge.isCharged || playerDefen.isDefending || inventoryUI.isOpen)
        {
            rb.linearVelocity = Vector2.zero;
            animator.SetFloat("speed", 0);
            return;
        }

        if (playerDash.isDashing) return;

        
        if (x > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (x < 0) transform.localScale = new Vector3(-1, 1, 1);

        animator.SetFloat("speed", Mathf.Abs(x));

        bool canPlayFootstep =
            Mathf.Abs(rb.linearVelocity.x) > 0.5f && !playerDash.isDashing && !playerCharge.isCharged && !playerDefen.isDefending && !playerHealth.isDead && GameManager.Instance.CurrentState == GameState.Playing;

        if (canPlayFootstep)
        {
            footstepCooldown -= Time.deltaTime;

            if (footstepCooldown <= 0f)
            {
                SoundManager.Instance.Emit(Sound.Run);
                footstepCooldown = footstepInterval;
            }
        }
        else
        {
            // 움직이지 않으면 조금 기다렸다가 다시 첫 발소리
            if (footstepCooldown > 0.05f)
                footstepCooldown = 0.05f;
        }
    }

    public void SetMoveInput(float input)
    {
        x = input;
    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.CurrentState == GameState.Story || playerHealth.isDead || playerCharge.isCharged || playerDefen.isDefending || inventoryUI.isOpen)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        if (playerDash.isDashing) return;

        rb.linearVelocity = new Vector2(x * PlayerStat.Instance.MoveSpeed, rb.linearVelocity.y);
    }
}
