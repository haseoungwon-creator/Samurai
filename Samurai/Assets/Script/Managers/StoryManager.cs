using System;
using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{

    private string storytext;

    public bool isTyping { get; private set; }
    Coroutine typingcoroutine;


    private IEnumerator TypeText(string storyline, Text textbox, float speed)
    {
        isTyping = true;
        storytext = "";
        foreach (char c in storyline)
        {
            storytext += c;
            textbox.text = storytext;
            yield return new WaitForSeconds(speed);
        }
        isTyping=false;
    }

    public void StartTyping(string typingstorytext, Text textbox, float speed)
    {
        StopAllCoroutines();
        if (typingcoroutine != null) 
        { 
            StopCoroutine(typingcoroutine);
        }
        typingcoroutine = StartCoroutine(TypeText(typingstorytext, textbox, speed));

    }

    public void skip(string fulltext, Text textbox)
    {
        if (typingcoroutine != null)
        {
            StopCoroutine(typingcoroutine);
        }
        textbox.text = fulltext;
        isTyping = false;
    }

}



