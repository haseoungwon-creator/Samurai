using System.Collections;
using UnityEngine;

public class StageIntroManager : MonoBehaviour
{
    [SerializeField] Transform leftPoint;
    [SerializeField] Transform rightPoint;

    [SerializeField] CameraController cameraController;
    Transform cameraTransform;

    [SerializeField] float moveTime = 5f;

    private void Start()
    {
        StartCoroutine(Intro());
    }

    IEnumerator Intro()
    {
        cameraController.canFollow = false;

        GameManager.Instance.SetState(GameState.Story);

        Camera.main.transform.position = new Vector3(rightPoint.position.x, rightPoint.position.y, Camera.main.transform.position.z);

        float t = 0;

        while (t < moveTime)
        {
            t += Time.deltaTime;

            float progress = Mathf.SmoothStep(0f, 1f, t / moveTime);

            Camera.main.transform.position = Vector3.Lerp(rightPoint.position, leftPoint.position,progress);

            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -10);

            yield return null;
        }

        yield return CoroutineManager.Wait(0.5f);

        cameraController.canFollow = true;

        GameManager .Instance.SetState(GameState.Playing);
    }
}
