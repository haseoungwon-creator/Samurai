using UnityEngine;

public class GuestManager : Singleton<GuestManager>
{
    [SerializeField] QuestData currentQuest;
    public QuestData CurrentQuest => currentQuest;
    public int CurrentCount {  get; private set; }
    public bool IsCompleted { get; private set; }

    public void StartQuest(QuestData quest)
    {
        currentQuest = quest;
        CurrentCount = 0;
        IsCompleted = false;
        Debug.Log("start");
    }

    public void AddProgress(string targetID,int amount = 1)
    {
        if (currentQuest == null) return;
        if (currentQuest.targetID != targetID) return;

        CurrentCount += amount;
        if(CurrentCount >= currentQuest.targetCount)
        {
            CurrentCount = currentQuest.targetCount;

            CompleteQuest();
        }
    }

    private void CompleteQuest()
    {
        IsCompleted = true;
        Debug.Log("end");
        Reward();
    }

    private void Reward()
    {

        GoldManager.Instance.AddGold(CurrentQuest.RewardGold);


        if (CurrentQuest.rewaedItem != null)
        {
            Inventory.Instance.AddItem(CurrentQuest.rewaedItem);
        }
    }
}
