using System.Collections;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] AttackData[] attackDatas;

    PlayerStateMachine stateMachine;
    PlayerAnimator playerAnimator;

    int comboStep;

    bool canQueueNextAttack;
    bool attackQueued;

    Coroutine comboResetCoroutine;
    private void Awake()
    {
        stateMachine = GetComponent<PlayerStateMachine>();
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    private void Start()
    {
        comboStep = 0;
    }
  
    public void TryAttack()
    {
        if (stateMachine.CanAttack())
        {
            comboStep = 1;

            stateMachine.ChangeState(PlayerState.Attack);

            StartCoroutine(AttackRoutine());
        }
        else if(stateMachine.CurrentState == PlayerState.Attack && canQueueNextAttack)
        {
            attackQueued = true;
        }
    }


    IEnumerator AttackRoutine()
    {
        Debug.Log($"comboStep : {comboStep}");
        Debug.Log($"Length : {attackDatas.Length}");
        Debug.Log($"Data : {attackDatas[comboStep - 1]}");
        AttackData data = attackDatas[comboStep-1];

        attackQueued = false;
        canQueueNextAttack = false;

        playerAnimator.SetAttackStep(comboStep);

        yield return new WaitForSeconds(data.duration * 0.3f);

        PerformAttack();

        yield return new WaitForSeconds(data.duration * 0.4f);

        canQueueNextAttack = true;

        yield return new WaitForSeconds(data.duration * 0.3f);

        canQueueNextAttack = false;

        if (attackQueued)
        {
            comboStep++;

            if(comboStep > attackDatas.Length)
                comboStep = 1;

            StartCoroutine(AttackRoutine());
            yield break;
        }

        stateMachine.ChangeState(PlayerState.Idle);

        playerAnimator.ResetAttack();

        if (comboResetCoroutine != null)
            StopCoroutine(comboResetCoroutine);

        comboResetCoroutine = StartCoroutine(ComboReset(data.comboWindow));
    }


    IEnumerator ComboReset(float time)
    {
        yield return new WaitForSeconds(time);

        comboStep = 0;
    }
    void PerformAttack()
    {
        float direction = transform.localScale.x > 0 ? 1 : -1;
        GameObject hitobject = Instantiate(attackDatas[comboStep - 1].hitboxPrefab, transform.position, Quaternion.identity);
        hitobject.GetComponent<Hitbox>().Init(attackDatas[comboStep - 1], direction);
    }
}