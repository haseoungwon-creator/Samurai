using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryController : Singleton<StoryController>
{
    [SerializeField] GameObject storyPanel;
    [SerializeField] Text speakerText;
    [SerializeField] Text dialogueText;
    [SerializeField] float typingSpeed = 0.03f;

    [SerializeField] Canvas storyCanvas;
    [SerializeField] int basestorySortingOrder = 3;
    [SerializeField] int storySortingOrder = 501;

    private List<Dialogue> currentStory;
    private int currentIndex;

    private System.Action finishCallback;

    public bool IsPlaying => currentStory != null;

    private void Update()
    {
        if (currentStory == null) return;
        
        if(!Input.GetKeyDown(KeyCode.Space)) return;

        if (StoryManager.Instance.isTyping)
        {
            StoryManager.Instance.Skip(dialogueText, currentStory[currentIndex].line);
            return;
        }

        NextDialogue();
    }

    public void Play(string storyKey,System.Action onFinish = null)
    {
        currentStory = StoryDatabase.Get(storyKey);

        if(currentStory == null || currentStory.Count == 0)
        {
            onFinish?.Invoke();
            return;
        }

        finishCallback = onFinish;

        currentIndex = 0;
        GameManager.Instance.SetState(GameState.Story);
        if(storyPanel != null)
        {
            storyPanel.SetActive(true);
            if(storyCanvas != null)
            {
                storyCanvas.sortingOrder = storySortingOrder;
            }
        }
        

        ShowDialogue();
    }

    private void ShowDialogue()
    {
        Dialogue dialogue = currentStory[currentIndex];

        speakerText.text = dialogue.speaker;

        StoryManager.Instance.StartTyping(dialogue.line, dialogueText, typingSpeed);
    }

    private void NextDialogue()
    {
        currentIndex++;

        if(currentIndex >= currentStory.Count)
        {
            EndStory();
            return;
        }

        ShowDialogue();
    }

    private void EndStory()
    {
        StoryManager.Instance.StopTyping();
        if (storyPanel != null)
        {
            storyPanel.SetActive(false);
            if (storyCanvas != null)
            {
                storyCanvas.sortingOrder = basestorySortingOrder;
            }
        }
        currentStory = null;

        GameManager.Instance.SetState(GameState.Playing);

        finishCallback?.Invoke();

        finishCallback = null;

    }

    public void FindUI()
    {
        Debug.Log("FindUI");
        if (storyCanvas == null)
        {
            storyCanvas = GameObject.Find("StoryCanvas").GetComponent<Canvas>();
        }

        if (storyPanel == null)
        {
            storyPanel = storyCanvas.transform.Find("StoryPanel").gameObject;
        }

        if (speakerText == null)
        {
            speakerText = storyPanel.transform.Find("TalkCharacter").GetComponent<Text>();
        }

        if (dialogueText == null)
        {
            dialogueText = storyPanel.transform.Find("StoryText").GetComponent<Text>();
        }
    }

}
