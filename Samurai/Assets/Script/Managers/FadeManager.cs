using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.Port;

public class FadeManager : MonoBehaviour
{
    [SerializeField] GameObject fadePrefab;

    GameObject fadeObject;
    Image fadeImage;
    [SerializeField] float fadeDuration = 1f;

    private void Start()
    {
        fadeObject = Instantiate(fadePrefab);

        fadeImage = fadeObject.GetComponentInChildren<Image>();

        Color c = fadeImage.color;
        fadeImage.color = c;
    }

    public void FadeIn()
    {
        StartCoroutine(Fade(0, 1, fadeDuration));
    }

    public void FadeOut()
    {
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


