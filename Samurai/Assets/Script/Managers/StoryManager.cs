using System;
using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : Singleton<StoryManager>
{
    public bool isTyping { get; private set; }

    private Coroutine typingCoroutine;

    public void StartTyping(string text, Text uiText, float speed)
    {
        if(typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeRoutine(text, uiText uiText, speed));
    }

    IEnumerator TypeRoutine(string text, Text uiText, float speed)
    {
        isTyping = true;
        uiText.text = "";

        foreach(char c in text)
        {
            uiText.text += c;
            yield return new WaitForSeconds(speed);
        }

        isTyping=false;
    }

    public void skip(Text uiText,string fullText)
    {
        if(typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        uiText.text = fullText;
        isTyping = false;

    }

}



