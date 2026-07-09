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
        animator.SetInteger("attackState", step);
    }
    public void SetDashing(bool isDashing)
    {
        animator.SetBool("isDashing", isDashing);
    }
    public void TriggerCharge()
    {
        animator.SetTrigger("charge");
    }
    public void TriggerChargeAttack()
    {
        animator.SetTrigger("chargeAttack");
    }
    public void TriggerDashAttack()
    {
        animator.SetTrigger("dashAttack");
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
        animator.SetInteger("attackState", 0);
    }
}