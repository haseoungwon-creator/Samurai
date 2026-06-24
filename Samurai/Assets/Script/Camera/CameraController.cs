using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    public float moveDistance;
    public Transform playerTransform;
    public Transform cameraTransform;

    private Camera cam;

    bool isMoving = false;


    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        cam = Camera.main;
        playerTransform = Player.transform;
        cameraTransform = transform;
        float height = cam.orthographicSize * 2f;
        moveDistance = height * cam.aspect -2f;
    }

   
    private void LateUpdate()
    {
        if (isMoving) return;

        CheckOutOfBounds();
    }

    
    void CheckOutOfBounds()
    {

        if(IsEnemyInView()) return;
        Vector3 viewPos = cam.WorldToViewportPoint(playerTransform.position);
        if(viewPos.x > 1f)
        {
            FollowPlayer(Vector3.right);
        }
        else if(viewPos.x < 0f)
        {
            FollowPlayer(Vector3.left);
        }
    }

    bool IsEnemyInView()
    {

        foreach(Enemy enemy in EnemyManager.Instance.GetEnemies())
        {
            Vector3 viewPos = cam.WorldToViewportPoint(enemy.transform.position);

            if(viewPos.x > 0f && viewPos.x < 1f && viewPos.y > 0f && viewPos.y < 1f)
            {
                return true;
            }
        }

        return false;
    }

    private void FollowPlayer(Vector3 dir)
    {
        StartCoroutine(SmoothMoving(dir));
    }

    IEnumerator SmoothMoving(Vector3 dir)
    {
        isMoving = true; 

        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + dir *moveDistance;

        float time = 0f;
        float duration = 0.3f;

        while (time < duration)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos,endPos, time/duration);
            yield return null;
        }

        transform.position = endPos;
        isMoving = false;
    }
}