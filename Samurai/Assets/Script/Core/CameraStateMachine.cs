using UnityEngine;

public class CameraStateMachine : Singleton<CameraStateMachine>
{
    public CameraState CurrentState { get; private set; }

    public void ChangeState(CameraState newState)
    {
        if (CurrentState == newState) return;
        CurrentState = newState;
    }

   public bool Following()
    {
        if(CurrentState == CameraState.Follow) return true;
        return false;
    }

    public bool AttackMoving()
    {
        if(CurrentState == CameraState.AttackMove) return true;
        return false;
    }

    public bool ChargeAttackMoving()
    {
        if(CurrentState == CameraState.ChargeAttackMove) return true;
        return false;
    }

    public bool DashAttackMoving()
    {
        if(CurrentState == CameraState.DashAttackMove) return true;
        return false;
    }

    public bool TakeDamageMoving()
    {
        if(CurrentState == CameraState.TakeDamageMove) return true;
        return false;
    }

    public bool HeartBitMoving()
    {
        if(CurrentState == CameraState.HeartBit) return true;
        return false;
    }
}
