using UnityEngine;

public class AttackStateMachine : MonoBehaviour
{
    public AttackState CurrentState { get; private set; }

    public float comboTime;
    public float chargeTime;
    public float chargeThreshold = 0.5f;

    private void Update()
    {
        HandleInput();
    }
    void HandleInput()
    {
        
        if(comboTime > 0) comboTime -= Time.deltaTime;
        if(comboTime <=0 && CurrentState != AttackState.Idle) ResetCombo();
        if (Input.GetMouseButtonDown(0)) chargeTime = 0;

        if (Input.GetMouseButton(0)) 
        { 
            chargeTime += Time.deltaTime;
            if(chargeTime > chargeThreshold) CurrentState = AttackState.Charging;
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (CurrentState == AttackState.Charging) CurrentState = AttackState.ChargeRelease;
            else NextCombo();
        }
    }

    public void ResetCombo()
    {
        CurrentState = AttackState.Idle;
        comboTime = 0;
    }

    void NextCombo()
    {
        switch (CurrentState)
        {
            case AttackState.Idle: CurrentState = AttackState.Combo1; break;
            case AttackState.Combo1: CurrentState = AttackState.Combo2; break;
            case AttackState.Combo2: CurrentState = AttackState.Combo3; break;
            case AttackState.Combo3: CurrentState = AttackState.Idle; break;
        }
    }

    public void SetComboWindow(float time)
    {
        comboTime = time;
    }
}
