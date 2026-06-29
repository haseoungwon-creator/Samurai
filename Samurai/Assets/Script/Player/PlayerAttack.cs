using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator animator;

    int comboStep;

    [SerializeField] float comboWindowTime;
    float comboTimer;

    bool isAttacking;
    bool nextAttackQueued;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        comboTimer -= Time.deltaTime;
        if(comboTimer <= 0 && !isAttacking)
        {
            comboStep = 0;
            animator.SetInteger("attackState", comboStep);
        }

        if(Input.GetMouseButtonDown(0))
        {
            if(!isAttacking) Attack();
            else nextAttackQueued = true;
        }
    }

    private void Attack()
    {
        comboStep++;

        if(comboStep > 3)
        {
            comboStep = 1;
        }
        animator.SetInteger("attackState",comboStep);
        comboTimer = comboWindowTime;
        isAttacking = true;
    }

    public void EndAttack()
    {
        isAttacking = false;
        if(nextAttackQueued)
        {
            nextAttackQueued = false;
            Attack();
        }
    }
}
