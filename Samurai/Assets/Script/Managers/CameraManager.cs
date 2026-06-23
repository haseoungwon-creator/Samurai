using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public static CameraManager Instance;
    private Camera cam;
    private float defaultSize;
    private float zoomSize = 3f;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        cam = Camera.main;
        defaultSize = cam.orthographicSize; 
        
    }

    public void Zoomin()
    {
        StartCoroutine(ZoomRoutine(cam.orthographicSize, zoomSize));
    }

    public void Zoomout()
    {
        StartCoroutine(ZoomRoutine(cam.orthographicSize, defaultSize));
    }


    private IEnumerator ZoomRoutine(float start, float end)
    {
        float time = 0f;
        float duration = 1f;

        while (time < duration)
        {
            time += Time.deltaTime;
            cam.orthographicSize = Mathf.Lerp(start, end, time / duration);
            yield return null;
        }

        cam.orthographicSize = end;
    }
}
