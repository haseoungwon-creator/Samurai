using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : Singleton<StoryManager>
{

    public bool isTyping { get; private set; }

    private Coroutine typingCoroutine;

    public int FriendStoryIndex { get; private set; } = 1;
    public bool CanFriendTalk { get; private set; } = true;

    public bool CanTeachTalk { get; private set;} = true;

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
            SoundManager.Instance.Emit(Sound.Text2);
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

    public void FriendTalkComplete()
    {
        CanFriendTalk = false;
    }

    public void UnlockNextFriendStory()
    {
        FriendStoryIndex++;
        CanFriendTalk = true;
    }

    public void TeacherTalkComplete()
    {
        CanTeachTalk = false;
    }

    public void UnlockNextTeacherStory()
    {
        CanTeachTalk= true;
    }
}



