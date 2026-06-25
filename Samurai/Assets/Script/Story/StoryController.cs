using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class StoryController : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text dialogueText;
    [SerializeField] float textSpeed = 0.1f;


    private List<Dialogue> currentStory;
    private int index = 0;

    public void StartStory(string key)
    {
        currentStory = StoryDatabase.Get(key);

        if(currentStory == null || currentStory.Count == 0)
        {
            EndStory();
            return;
        }

        index = 0;
        ShowDialogue();
    }

    private void Update()
    {
        if (currentStory == null) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextDialogue();
        }
    }

    void ShowDialogue()
    {
        var data = currentStory[index];

        nameText.text = data.speaker;
        StoryManager.Instance.StartTyping(data.line, dialogueText, textSpeed);
    }

    void NextDialogue()
    {
        if (StoryManager.Instance.isTyping)
        {
            StoryManager.Instance.skip(dialogueText, currentStory[index].line);
            return;
        }

        index++;
        if(index >= currentStory.Count)
        {
            EndStory();
            return;
        }
        ShowDialogue();
    }

    void EndStory()
    {
        currentStory = null;
        GameManager.Instance.SetState(GameState.Playing);
        gameObject.SetActive(false);
    }

    
}