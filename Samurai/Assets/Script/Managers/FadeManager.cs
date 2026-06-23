using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.Port;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance;
    private GameObject fadeObject;
    Image fadeImage;
    float duration = 1f;

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
    }

    private void Start()
    {

        fadeObject = Instantiate(Resources.Load<GameObject>("FadePrefab"));
        
        fadeImage = fadeObject.GetComponentInChildren<Image>();

        Color c = fadeImage.color;
        fadeImage.color = c;

        DontDestroyOnLoad(fadeObject);
    }

    public void Create()
    {
        fadeObject = Instantiate(Resources.Load<GameObject>("FadePrefab"));
    }

    public void DestroyFade()
    {
        Destroy(fadeObject);
        StopAllCoroutines();
    }

    public void FadeIn(float fadeDurations)
    {
        duration = fadeDurations;
        StartCoroutine(FadeRoutine(0, 1, duration));
    }

    public void FadeOut(float fadeDurations)
    {
        duration = fadeDurations;
        StartCoroutine(FadeRoutine(1, 0, duration));
    }

    private IEnumerator FadeRoutine(float start,float end, float duration)
    {
        float time = 0;
        Color c = fadeImage.color;

        while (time < duration)
        {
            time += Time.deltaTime; 
            c.a = Mathf.Lerp(start, end, time/duration);
            fadeImage.color = c;
            yield return null;
        }

        c.a = end;
        fadeImage.color = c;
    }


}


