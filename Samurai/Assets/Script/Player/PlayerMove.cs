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

    public void PlayFootstep()
    {
        if (playerHealth.isDead) return;
        if (playerDash.isDashing) return;
        if (playerCharge.isCharged) return;
        if (playerDefen.isDefending) return;
        if (GameManager.Instance.CurrentState != GameState.Playing) return;

        SoundManager.Instance.Emit(Sound.Walk);
    }
}
