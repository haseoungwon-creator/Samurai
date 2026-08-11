using System.Collections.Generic;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    public QuestData CurrentQuest { get; private set; }

    public QuestData NextQuest { get; private set; }

    public HashSet<string> CompletedQuest {  get; private set; } = new();
    public int CurrentCount { get; private set; }
    public bool IsCompleted {  get; private set; }

    
    public bool CanTeacherTalk { get; private set; } = true;
    public void StartQuest(QuestData quest)
    {
        CurrentQuest = quest;
        CurrentCount = 0;
        IsCompleted = false;
    }

    public void AddProgress(string targetId, int amount = 1)
    {
        if (CurrentQuest == null) return;

        if (CurrentQuest.targetID != targetId) return;

        if (IsCompleted) return;

        CurrentCount += amount;

        if(CurrentCount >= CurrentQuest.targetCount)
        {
            CurrentCount = CurrentQuest.targetCount;

            CompleteQuest();
        }
    }

    private void CompleteQuest()
    {
        IsCompleted = true;

        bool returnVillage = CurrentQuest.returnVillage;

        if (CurrentQuest.nextStory)
        {
            StoryManager.Instance.UnlockNextFriendStory();
        }

        StoryManager.Instance.UnlockNextTeacherStory();

        if (returnVillage)
        {
            SceneryManager.Instance.LoadScene("Village");
        }
    }

    
    public void SubmitQuest()
    {
        Debug.Log("submitQuest start");
        if (CurrentQuest == null)
        {
            Debug.Log("퀘스트 없음");
            return;
        }

        if (!IsCompleted)
        {
            Debug.Log("퀘스트 미진행");
            return;
        }
        Debug.Log(CurrentQuest.questName + " 완료 처리");

        Reward();

        CompletedQuest.Add(CurrentQuest.questId);

        NextQuest = CurrentQuest.nextQuest;

        bool autoStart = CurrentQuest.autoStartNextQuest;


        ClearQuest();

        if (autoStart)
        {
            StartNextQuest();
        }

    }

    public void StartNextQuest()
    {
        if (NextQuest == null) {
            Debug.Log("NextQuest Null");
            return;
        } 

        StartQuest(NextQuest);

        NextQuest = null;
    }
    private void Reward()
    {
        if(CurrentQuest.rewardGold > 0)
        {
            GoldManager.Instance.AddGold(CurrentQuest.rewardGold);
        }

        if(CurrentQuest.rewardItem != null)
        {
            Inventory.Instance.AddItem(CurrentQuest.rewardItem);
        }
    }

    public void ClearQuest()
    {
        CurrentQuest = null;
        CurrentCount = 0;
        IsCompleted = false;
    }

    public void ResetAllQuests()
    {
        CurrentQuest = null;
        NextQuest = null;
        CompletedQuest.Clear();
        CurrentCount = 0;
        IsCompleted = false;
        CanTeacherTalk = true;
    }
}
