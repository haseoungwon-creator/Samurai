using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] AttackData[] attackData;

    [SerializeField] float comboWindowTime;

    AttackData thisAttackData;

    Animator animator;



    int comboStep;

    float comboTimer;
    

    public bool isAttacking {  get; private set; }
    bool nextAttackQueued;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isAttacking && comboTimer > 0)
        {
            comboTimer -= Time.deltaTime;
            if (comboTimer <= 0)
            {
                comboTimer = 0;
                comboStep = 0;
                animator.SetInteger("attackState", comboStep);
            }
        }
    }

    public void OnAttackInput()
    {
        if (!isAttacking)
        {
            Attack();
        }
        else
        {
            nextAttackQueued = true;
        }
    }

    private void Attack()
    {
        if(comboTimer <= 0)
        {
            comboStep = 0;
        }

        comboStep++;

        if(comboStep > attackData.Length)
        {
            comboStep = 1;
        }

        comboTimer = comboWindowTime;

        nextAttackQueued = false;

        isAttacking = true;

        animator.SetInteger("attackState", comboStep);
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

    public void PerformAttack()
    {
        thisAttackData = attackData[comboStep-1];

        float direction = transform.localScale.x > 0 ? 1f: -1f;

        GameObject hitobject = Instantiate(thisAttackData.hitboxPrefab, transform.position, Quaternion.identity);
        
        hitobject.GetComponent<Hitbox>().Init(thisAttackData, direction);
    }

}
