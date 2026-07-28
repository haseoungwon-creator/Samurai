using UnityEngine;

public class QuestNPC : NPCBase
{
    [SerializeField] QuestData[] quests;

    protected override void TryTalk()
    {
        if (!canTalk) return;

        QuestManager questManager = QuestManager.Instance;

        if(questManager.CurrentQuest == null)
        {
            StartNewQuest();
            return;
        }

        if (!questManager.IsCompleted)
        {
            ShowProgressStory();
            return;
        }

        ShowCompleteStory();
    }

    private void StartNewQuest()
    {
        QuestData quest = GetCurrentQuest();

        if (quest == null) return;
        if(QuestManager.Instance.CompletedQuest.Contains(quest.questId)) return;

        talked = true;

        StoryController.Instance.Play(quest.startStoryKey,
            () =>
            {
                QuestManager.Instance.StartQuest(quest);

                EndDialogue();
            });
    }

    private void ShowProgressStory()
    {
        QuestData quest = QuestManager.Instance.CurrentQuest;

        StoryController.Instance.Play(quest.progressStoryKey, EndDialogue);
    }

    private void ShowCompleteStory()
    {
        QuestData quest = QuestManager.Instance.CurrentQuest;

        StoryController.Instance.Play(
            quest.completeStoryKey,
            () =>
            {
                Debug.Log("스토리 나올거임");
                QuestManager.Instance.SubmitQuest();
                Debug.Log("다음 퀘스트");
                EndDialogue();
            });
    }

    private QuestData GetCurrentQuest()
    {
        int chapter = WorldManager.Instance.CurrentChapter;

        int stage = WorldManager.Instance.CurrentStage;

        foreach(QuestData quest in quests)
        {
            if(quest.chapter == chapter && quest.stage == stage)
            {
                return quest;
            }
        }

        return null;
    }

    protected override void EndDialogue()
    {
            
    }
}