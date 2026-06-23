using System;
using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{

    public static StoryManager instance;

    private string storytext;

    public bool isTyping { get; private set; }
    Coroutine typingcoroutine;
    Text textbox;
    float speed;
    string storyline;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private IEnumerator TypeText()
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

    public void StartTyping(string typingstorytext, Text textbox_, float speed_)
    {
        storyline = typingstorytext;
        textbox = textbox_;
        speed = speed_;

        StopAllCoroutines();
        if (typingcoroutine != null) 
        { 
            StopCoroutine(typingcoroutine);
        }
        typingcoroutine = StartCoroutine(TypeText());

    }

    public void SkipTyping()
    {
        if (typingcoroutine != null)
        {
            StopCoroutine(typingcoroutine);
        }
        textbox.text = storyline;
        isTyping = false;
    }

}



