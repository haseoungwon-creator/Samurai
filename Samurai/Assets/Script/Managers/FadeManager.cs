using System.Collections;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.Port;

public class FadeManager : Singleton<FadeManager>
{
    private GameObject fadeObject;
    private Image fadeImage;


    private void Start()
    {
        CreateFade();
    }

    void CreateFade()
    {
        if (fadeObject != null) return;

        fadeObject = Instantiate(Resources.Load<GameObject>("FadePrefab"));
        fadeImage = fadeObject.GetComponentInChildren<Image>();

        DontDestroyOnLoad(fadeObject);
    }

    public void SetActiveFade(bool tf)
    {
        if (fadeObject != null)
        {
            fadeObject.SetActive(tf);
        }
    }

    public void FadeIn(float duration)
    {
        if (fadeImage == null) return;
        StartCoroutine(FadeRoutine(0,1,duration));
    }

    public void FadeOut(float duration)
    {
        if (fadeImage == null) return;
        StartCoroutine(FadeRoutine(1, 0, duration));
    }

    IEnumerator FadeRoutine(float start, float end, float duration)
    {

        float time = 0;
        Color c = fadeImage.color;

        while (time < duration)
        {
            if (fadeImage == null) yield break;

            time += Time.deltaTime;
            c.a = Mathf.Lerp(start, end, time / duration);
            fadeImage.color = c;
            yield return null;

        }
        c.a = end;
        fadeImage.color = c;
    }

    
}


