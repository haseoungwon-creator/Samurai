using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] float dashSpeed;
    [SerializeField] float dashDuration;
    [SerializeField] float dashCooldown;
    [SerializeField] AttackData dashAttackData;

    public bool isDashing { get; private set; }
    bool canDash;
    public bool dashAttackQueued {  get; private set; }

    Rigidbody2D rb;
    PlayerHealth playerHealth;
    Animator animator;

    List<Enemy> hitEnemies;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody2D>();

        isDashing = false;
        canDash = true;
    }

   public void Dash()
    {
        if (!canDash || isDashing) return;

        StartCoroutine(DashRoutine());
    }

    public void QueueDashAttack()
    {
        if(!isDashing) return;
        dashAttackQueued = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isDashing)
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy == null) return;
            if (!hitEnemies.Contains(enemy))
            {
                hitEnemies.Add(enemy);
            }
        }
    }

    IEnumerator DashRoutine()
    {
        isDashing = true;
        canDash = false;
        hitEnemies = new List<Enemy>();
        dashAttackQueued = false;

        animator.SetBool("isdashing", true);

        float dir = transform.localScale.x > 0 ? 1 : -1;

        rb.linearVelocity = new Vector2(dir * dashSpeed, rb.linearVelocity.y);
        playerHealth.SetIncincible(true);

        yield return new WaitForSeconds(dashDuration);
        playerHealth.SetIncincible(false);

        

        if (dashAttackQueued)
        {
            DashAttack();

            yield break;
        }
        rb.linearVelocity = Vector2.zero;
        playerHealth.SetIncincible(false);
        animator.SetBool("isdashing", false);
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;

    }

    private void DashAttack()
    {
        dashAttackQueued = false;

        

        animator.SetTrigger("dashattack");
        foreach(Enemy enemy in hitEnemies)
        {
            if(enemy == null) continue;
            enemy.TakeDamage(dashAttackData.damage);
        }
        hitEnemies.Clear();
        rb.linearVelocity = Vector2.zero;
        playerHealth.SetIncincible(false);
        animator.SetBool("isdashing", false);

    }

    private void EndDashAttack()
    {
        isDashing = false;
        StartCoroutine(DashCooldown());
    }

    IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
