using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool canFollow = true;
    CameraManager cameraManager;

    private void Awake()
    {
        cameraManager = FindAnyObjectByType<CameraManager>();
    }
    private void LateUpdate()
    {
        if (!canFollow) return;
        if (cameraManager.isMoving) return;
        cameraManager.CheckOutOfBounds();

        if(CameraStateMachine.Instance.CurrentState != CameraState.none &&
            CameraStateMachine.Instance.CurrentState != CameraState.Follow)
        {
            cameraManager.CameraMoving(CameraStateMachine.Instance.CurrentState);
        }
    }

    
}