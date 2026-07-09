using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerState CurrentState { get; private set; }

    public void ChangeState(PlayerState newState)
    {
        if (CurrentState == newState) return;
        CurrentState = newState;
    }

    public bool CanAttack()
    {
        if(CurrentState == PlayerState.Idle) return true;
        return false;
    }

    public bool CanDash()
    {
        if (CurrentState == PlayerState.Idle||CurrentState == PlayerState.Attack) return true;
        return false;
    }

    public bool CanCharge()
    {
        if (CurrentState == PlayerState.Idle) return true;
        return false;
    }
}
