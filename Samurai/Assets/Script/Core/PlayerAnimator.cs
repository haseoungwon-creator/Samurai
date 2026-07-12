using UnityEngine;
public class PlayerAnimator : MonoBehaviour
{
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void SetAttackStep(int step)
    {
        animator.SetInteger("attackstate", step);
    }
    public void SetDashing(bool isDashing)
    {
        animator.SetBool("isdashing", isDashing);
    }
    public void TriggerCharge()
    {
        animator.SetTrigger("charge");
    }
    public void TriggerChargeAttack()
    {
        animator.SetTrigger("chargeattack");
    }
    public void TriggerDashAttack()
    {
        animator.SetTrigger("dashattack");
    }
    public void TriggerHurt()
    {
        animator.SetTrigger("hurt");
    }
    public void TriggerDie()
    {
        animator.SetTrigger("die");
    }
    public void SetSpeed(float speed)
    {
        animator.SetFloat("speed", speed);
    }
    public void ResetAttack()
    {
        animator.SetInteger("attackstate", 0);
    }
    public void ResetTriggerCharge()
    {
        animator.ResetTrigger("charge");
        animator.ResetTrigger("chargeattack");
    }

    public void SetDefending(bool isDefending)
    {
        animator.SetBool("isdefending",isDefending);
    }

    public void TriggerGuardReact()
    {
        animator.SetTrigger("guardreact");
    }

    public void TriggerGuardBreak()
    {
        animator.SetTrigger("guardbreak");

    }
}