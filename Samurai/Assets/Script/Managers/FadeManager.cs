using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.Port;

public class FadeManager : MonoBehaviour
{
    public static FadeManager instance;
    static GameObject fadeInstance;
    Image fadeImage;
    float fadeDuration = 1f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

        fadeInstance = Instantiate(Resources.Load<GameObject>("FadePrefab"));
        
        fadeImage = fadeInstance.GetComponentInChildren<Image>();

        Color c = fadeImage.color;
        fadeImage.color = c;

        DontDestroyOnLoad(fadeInstance);
    }

    public void FadeIn(float fadeDurations)
    {
        fadeDuration = fadeDurations;
        StartCoroutine(Fade(0, 1, fadeDuration));
    }

    public void FadeOut(float fadeDurations)
    {
        fadeDuration = fadeDurations;
        StartCoroutine(Fade(1, 0, fadeDuration));
    }

    private IEnumerator Fade(float start,float end, float duration)
    {
        float t = 0;
        Color c = fadeImage.color;

        while (t < duration)
        {
            t += Time.deltaTime; 
            c.a = Mathf.Lerp(start, end, t/duration);
            fadeImage.color = c;
            yield return null;
        }

        c.a = end;
        fadeImage.color = c;
    }


}


