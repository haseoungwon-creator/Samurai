using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : Singleton<StoryManager>
{

    public bool isTyping { get; private set; }

    private Coroutine typingCoroutine;

    public void StartTyping(string text, Text uiText, float speed)
    {
        StopTyping();

        typingCoroutine = StartCoroutine(TypeRoutine(text,uiText, speed));
    }

    IEnumerator TypeRoutine(string text, Text uiText, float speed)
    {
        if(text == null)
        {
            isTyping = false;
            yield break;
        }
        isTyping = true;
        uiText.text = "";

        foreach (char c in text)
        {
            if (uiText == null)
            {
                StopTyping();
                yield break;
            }
            uiText.text += c;
            yield return CoroutineManager.Wait(speed);
        }

        isTyping=false;
        typingCoroutine = null;
    }

    public void Skip(Text uiText,string fullText)
    {
        StopTyping();

        uiText.text = fullText;
        isTyping = false;

    }

    public void StopTyping()
    {
        if(typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }
        isTyping = false;
    }

    protected override void OnDestroy()
    {
        StopTyping() ;
        base.OnDestroy();
    }

    private void OnDisable()
    {
        StopTyping();
    }
}



