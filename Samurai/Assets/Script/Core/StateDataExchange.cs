using UnityEngine;

public class StateDataExchange : Singleton<StateDataExchange>
{
    public void StateDataExchanged()
    {
        switch (PlayerStateMachine.Instance.CurrentState)
        {
            
            case PlayerState.Attack:
                CameraStateMachine.Instance.ChangeState(CameraState.AttackMove);
                break;

            case PlayerState.ChargeFull:
                CameraStateMachine.Instance.ChangeState(CameraState.ChargeAttackMove);
                break;

            case PlayerState.DashAttack:
                CameraStateMachine.Instance.ChangeState(CameraState.DashAttackMove);
                break;

            case PlayerState.TakeDamage:
                CameraStateMachine.Instance.ChangeState(CameraState.TakeDamageMove);
                break;

            case PlayerState.LowHp:
                CameraStateMachine.Instance.ChangeState(CameraState.HeartBit);
                break;

            case PlayerState.none:
                CameraStateMachine.Instance.ChangeState(CameraState.none);
                break;
            default:
                CameraStateMachine.Instance.ChangeState(CameraState.Follow);
                break;
        }
    }
}
