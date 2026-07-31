using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StageIntroManager : MonoBehaviour
{
    [SerializeField] Transform leftPoint;
    [SerializeField] Transform rightPoint;

    [SerializeField] CameraController cameraController;
    Transform cameraTransform;

    [SerializeField] float moveTime = 5f;

    [SerializeField] Text Chapter;
    [SerializeField] Text Stage;

    private void Start()
    {
        Chapter.text ="Chapter " + WorldManager.Instance.CurrentChapter.ToString();
        Stage.text = "Stage " + WorldManager.Instance.CurrentChapter.ToString() + " - " + WorldManager.Instance.CurrentStage.ToString();
        Chapter.gameObject.SetActive(false);
        Stage.gameObject.SetActive(false);
        StartCoroutine(Intro());
    }

    IEnumerator Intro()
    {
        Chapter.gameObject.SetActive(true);
        Stage.gameObject.SetActive(true);
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

        Chapter.gameObject.SetActive(false);
        Stage.gameObject.SetActive(false);

        yield return CoroutineManager.Wait(0.5f);

        cameraController.canFollow = true;

        GameManager .Instance.SetState(GameState.Playing);
    }
}
