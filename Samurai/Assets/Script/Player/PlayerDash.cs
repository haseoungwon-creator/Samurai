using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] float dashSpeed;
    [SerializeField] float dashDuration;
    [SerializeField] float dashCooldown;
    [SerializeField] AttackData dashAttackData;

    bool canDash = true;
    public bool dashAttackQueued {  get; private set; }

    Rigidbody2D rb;
    PlayerHealth playerHealth;
    PlayerAnimator playerAnimator;
    PlayerStateMachine stateMachine;

    List<Enemy> hitEnemies;

    private void Awake()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        playerHealth = GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody2D>();
        stateMachine = GetComponent<PlayerStateMachine>();
    }

   public void TryDash()
    {
        if (!canDash || !stateMachine.CanDash()) return;

        StartCoroutine(DashRoutine());
    }

    public void QueueDashAttack()
    {
        if(stateMachine.CurrentState != PlayerState.Dash) return;
        dashAttackQueued = true;
    }

    IEnumerator DashRoutine()
    {
        canDash = false;
        dashAttackQueued = false;
        hitEnemies = new List<Enemy>();

        stateMachine.ChangeState(PlayerState.Dash);
        playerAnimator.SetDashing(true);

        float dir = transform.localScale.x > 0 ? 1 : -1;
        rb.linearVelocity = new Vector2(dashSpeed * dir, 0);
        playerHealth.SetIncincible(true);

        yield return new WaitForSeconds(dashDuration);

        rb.linearVelocity = Vector2.zero;

        playerHealth.SetIncincible(false);
        

        if (dashAttackQueued)
        {
            yield return StartCoroutine(DashAttackRoutine());
        }

        playerAnimator.SetDashing(false);
        stateMachine.ChangeState(PlayerState.Idle);
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    public void PerformDashAttack()
    {
        foreach (Enemy enemy in hitEnemies)
        {
            if(enemy == null) continue;
            enemy.TakeDamage(dashAttackData.damage);
        }
        hitEnemies.Clear();
    }
   IEnumerator DashAttackRoutine()
    {
        dashAttackQueued = false;
        stateMachine.ChangeState(PlayerState.DashAttack);

        playerAnimator.TriggerDashAttack();

        foreach (Enemy enemy in hitEnemies)
        {
            if(enemy == null) continue;
            enemy.TakeDamage(dashAttackData.damage);
        }

        hitEnemies.Clear();

        yield return new WaitForSeconds(dashAttackData.duration);

        stateMachine.ChangeState(PlayerState.Idle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(stateMachine.CurrentState != PlayerState.Dash) return;
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy == null) return;
        if (!hitEnemies.Contains(enemy))
        {
            hitEnemies.Add(enemy);
        }
    }
}

