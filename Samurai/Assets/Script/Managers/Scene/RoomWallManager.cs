using UnityEngine;

public class RoomWallManager : MonoBehaviour
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
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    public void OffRoomWall()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
