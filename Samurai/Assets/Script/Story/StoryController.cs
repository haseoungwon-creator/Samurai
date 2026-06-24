using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryController : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text dialogueText;
    [SerializeField] float textSpeed = 0.3f;

    private List<Dialogue> currentStory;
    private int index = 0;

    private void Start()
    {
        GameManager.Instance.SetState(GameState.Story);

        currentStory = StoryDatabase.Story1;

        ShowDialogue();
    }

    private void Update()
    {
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
        GameManager.Instance.SetState(GameState.Playing);
        gameObject.SetActive(false);
    }
}