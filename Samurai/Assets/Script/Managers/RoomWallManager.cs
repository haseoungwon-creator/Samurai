using UnityEngine;
using UnityEngine.UIElements;

public class RoomWallManager : Singleton<RoomWallManager>
{
   
    Transform cameraTransform;


    private void Start()
    {
        cameraTransform = Camera.main.transform;
        gameObject.transform.position = cameraTransform.position;
    }

    public void MoveWall()
    {
        gameObject.transform.position = cameraTransform.position;
    }

    public void OnRoomWall()
    {
        gameObject.SetActive(true);
    }

    public void OffRoomWall()
    {
        gameObject.SetActive(false);
    }
}
