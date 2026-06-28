using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] AttackStateMachine stateMachine;
    [SerializeField] Animator animator;
    [SerializeField] AttackData[] comboData;
    [SerializeField] AttackData chargeData;

    [SerializeField]GameObject hitboxPrefab;


    private void Start()
    {
        stateMachine = GetComponent<AttackStateMachine>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetInteger("AttackState", (int)stateMachine.CurrentState);
    }

    public void SpawnHitbox()
    {
        AttackData data = null;
        if (stateMachine.CurrentState == AttackState.ChargeRelease)
          data = chargeData;

        else
        {
            int index = (int)stateMachine.CurrentState - 1;
            data = comboData[index];
        }

        if (data == null) return;
        
        GameObject obj = Instantiate(hitboxPrefab, transform.position,Quaternion.identity);
        obj.GetComponent<Hitbox>().Init(data, data.hitboxOffset, !GetComponent<SpriteRenderer>().flipX);
    }

    public void OpenComboWindow()
    {
        int index = (int)stateMachine.CurrentState - 1;
        AttackData data = comboData[index];
        stateMachine.SetComboWindow(data.comboWindowTime);
    }

    public void EndAttack()
    {
        stateMachine.ResetCombo();
    }

}
