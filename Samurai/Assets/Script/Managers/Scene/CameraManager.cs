using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] float moveDistance;
    private Transform playerTransform;
    private Transform cameraTransform;

    private Camera cam;

    public bool isMoving { get; private set; }

    [SerializeField] float attackMoveDistance = 0.2f;
    [SerializeField] float attackmoveDuration = 0.05f;

    [SerializeField] float dashAttackMoveDistance = 0.5f;
    [SerializeField] float dashAttackMoveDuration = 0.03f;

    [SerializeField] float chargeAttackMoveDistance = 0.3f;
    [SerializeField]float chargeAttackMoveDuration = 0.05f;

    [SerializeField] float damageZoomSize = 0.2f;
    [SerializeField] float damageZoomDuration = 0.05f;

    EnemyManager enemyManager;
    RoomWallManager roomWallManager;

    private void Awake()
    {
        enemyManager = FindAnyObjectByType<EnemyManager>();
        roomWallManager = FindAnyObjectByType<RoomWallManager>();
    }

    IEnumerator Start()
    {
        while (FindAnyObjectByType<PlayerMove>() == null)
        {
            yield return null;
        } 
        Player = GameObject.FindGameObjectWithTag("Player");
        cam = Camera.main;
        playerTransform = Player.transform;
        cameraTransform = transform;
        float height = cam.orthographicSize * 2f;
        moveDistance = height * cam.aspect - 2f;
    }
    private void Update()
    {
        if(cam == null)
        {
            cam = Camera.main;
        }
        if(Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player"); 

            if(Player != null)
            {
                playerTransform = Player.transform;
            }
        }
    }

    public void CheckOutOfBounds()
    {
        if (IsEnemyInView()) return;

        Vector3 viewPos = cam.WorldToViewportPoint(playerTransform.position);
        if (viewPos.x > 1f)
        {
            FollowPlayer(Vector3.right);
        }
        else if (viewPos.x < 0f)
        {
            FollowPlayer(Vector3.left);
        }
    }

    bool IsEnemyInView()
    {

        foreach (Enemy enemy in enemyManager.GetEnemies().ToArray())
        {
            if(enemy == null) continue;
            Vector3 viewPos = cam.WorldToViewportPoint(enemy.transform.position);

            if (viewPos.x > 0f && viewPos.x < 1f && viewPos.y > 0f && viewPos.y < 1f)
            {
                roomWallManager.OnRoomWall();
                roomWallManager.MoveWall();
                return true;
            }
        }

        roomWallManager.OffRoomWall();

        return false;
    }

    private void FollowPlayer(Vector3 dir)
    {
        roomWallManager.OffRoomWall();
        StartCoroutine(SmoothMoving(dir));

    }

    IEnumerator SmoothMoving(Vector3 dir)
    {
        isMoving = true;

        Vector3 startPos = cam.transform.position;
        Vector3 endPos = startPos + dir * moveDistance;

        float time = 0f;
        float duration = 0.3f;

        while (time < duration)
        {
            time += Time.deltaTime;
            cam.transform.position = Vector3.Lerp(startPos, endPos, time / duration);
            yield return null;
        }

        cam.transform.position = endPos;
        isMoving = false;

        cameraTransform = cam.transform;
        roomWallManager.OnRoomWall();
    }



    public void CameraMoving(CameraState cameraState)
    {
        switch (cameraState)
        {
            case CameraState.none:
                return;
            case CameraState.AttackMove:
                StartCoroutine(CameraStateMoving(attackMoveDistance, attackmoveDuration));
                CameraStateMachine.Instance.ChangeState(CameraState.none);
                break;
            case CameraState.ChargeAttackMove:
                StartCoroutine(CameraStateMoving(chargeAttackMoveDistance, chargeAttackMoveDuration,true));
                CameraStateMachine.Instance.ChangeState(CameraState.none);
                break;
            case CameraState.DashAttackMove:
                StartCoroutine(CameraStateMoving(dashAttackMoveDistance, dashAttackMoveDuration));
                CameraStateMachine.Instance.ChangeState(CameraState.none);
                break;
            case CameraState.TakeDamageMove:
                StartCoroutine(TakeDamageMove(damageZoomSize,damageZoomDuration));
                CameraStateMachine.Instance.ChangeState(CameraState.none);
                break;
            case CameraState.HeartBit:
                StartCoroutine(TakeDamageMove(damageZoomSize, damageZoomDuration));
                CameraStateMachine.Instance.ChangeState(CameraState.none);
                break;
        }
    }

    IEnumerator CameraStateMoving(float distance, float durationTime, bool down = false)
    {
        float dir = Player.transform.localScale.x > 0 ? 1 : -1;

        Vector3 startpos = cam.transform.position;
        Vector3 endpos;

        if (down) 
            endpos = startpos + new Vector3(0, -1, 0) * distance;
        else
            endpos = startpos + new Vector3(dir, 0, 0) * distance;

        float point = 0;

        while(point < durationTime) { 
            point += Time.deltaTime;
            cam.transform.position = Vector3.Lerp(startpos,endpos,point/durationTime) ;
            yield return null;
        }

        cam.transform.position = endpos;
        point = 0;

        while(point < durationTime)
        {
            point += Time.deltaTime;
            cam.transform.position = Vector3.Lerp(endpos, startpos, point / durationTime);
            yield return null;
        }

        cam.transform.position = startpos;
    }

    IEnumerator TakeDamageMove (float zoomsize, float zoomdurationTime)
    {
        float startSize = cam.orthographicSize;
        float endSize = cam.orthographicSize + zoomsize;

        float timer = 0;
        while (timer < zoomdurationTime)
        {
            timer += Time.deltaTime;
            cam.orthographicSize = Mathf.Lerp(startSize, endSize, timer / zoomdurationTime);
            yield return null;
        }

        cam.orthographicSize = endSize;
        timer = 0;

        while(timer < zoomdurationTime)
        {
            timer += Time.captureDeltaTime;
            cam.orthographicSize = Mathf.Lerp(endSize, startSize, timer /zoomdurationTime);
            yield return null;
        }

        cam.orthographicSize = startSize;
    }
}
