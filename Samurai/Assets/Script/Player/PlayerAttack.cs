using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] AttackData[] attackData;

    [SerializeField] float comboWindowTime;

    AttackData thisAttackData;

    Animator animator;

    int comboStep;

    float comboTimer;
    

    bool isAttacking;
    bool nextAttackQueued;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (GameManager.Instance.Currentstate == GameState.Story) return;
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

    public void PerformAttack()
    {
        thisAttackData = attackData[comboStep-1];
        float direction = transform.localScale.x > 0 ? 1f: -1f;
        GameObject hitobject = Instantiate(thisAttackData.hitboxPrefab, transform.position, Quaternion.identity);
        Debug.Log("hitbox make");
        hitobject.transform.SetParent(transform);
        hitobject.GetComponent<Hitbox>().Init(thisAttackData, direction);
    }
}
