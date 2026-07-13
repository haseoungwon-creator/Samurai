using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private void LateUpdate()
    {
        if (CameraManager.Instance.isMoving) return;
        CameraManager.Instance.CheckOutOfBounds();

        if(CameraStateMachine.Instance.CurrentState != CameraState.none &&
            CameraStateMachine.Instance.CurrentState != CameraState.Follow)
        {
            CameraManager.Instance.CameraMoving(CameraStateMachine.Instance.CurrentState);
        }
    }

    
}