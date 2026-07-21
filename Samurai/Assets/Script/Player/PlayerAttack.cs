using System.Collections;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] AttackData[] attackDatas;

    PlayerAnimator playerAnimator;

    int comboStep;

    bool canQueueNextAttack;
    bool attackQueued;

    Coroutine comboResetCoroutine;
    private void Awake()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
    }
  
    public void TryAttack()
    {
        if (PlayerStateMachine.Instance.CurrentState == PlayerState.DashAttack) return;
        if (PlayerStateMachine.Instance.CurrentState == PlayerState.ChargeAttack) return;
        if (PlayerStateMachine.Instance.CanAttack())
        {
            comboStep = 1;

            PlayerStateMachine.Instance.ChangeState(PlayerState.Attack);

            playerAnimator.SetAttackStep(comboStep);
        }
        else if(PlayerStateMachine.Instance.CurrentState == PlayerState.Attack && canQueueNextAttack)
        {
            attackQueued = true;
        }
    }

    public void PerformAttack()
    {
        float direction = transform.localScale.x > 0 ? 1 : -1;

        GameObject hit = Instantiate(attackDatas[comboStep - 1].hitboxPrefab, transform.position,Quaternion.identity);

        hit.GetComponent<Hitbox>().Init(attackDatas[comboStep-1],direction);
    }

    public void OpenComboWindow() 
        {
            canQueueNextAttack = true;
        } 

    public void ClosecomboWindow()
    {
        canQueueNextAttack = false;
    }

    public void FinishAttack()
    {
        canQueueNextAttack = false;
        if(attackQueued)
        {
            attackQueued = false;
            comboStep++;
            if(comboStep > attackDatas.Length)
            {
                comboStep = 1;
            }

            playerAnimator.SetAttackStep(comboStep);
        }
        else
        {
            PlayerStateMachine.Instance.ChangeState(PlayerState.Idle);

            playerAnimator.ResetAttack();

            if(comboResetCoroutine != null)
            {
                StopCoroutine(comboResetCoroutine);
            }

            comboResetCoroutine = StartCoroutine(ResetCombo());
        }
    }

    IEnumerator ResetCombo()
    {
        yield return CoroutineManager.Wait(attackDatas[comboStep - 1].comboWindow);
        comboStep = 1;
    }
}