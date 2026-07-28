using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/QuestData",fileName ="Quest Data")]
public class QuestData : ScriptableObject
{
    public string questId;
    public string questName;
    public string description;


    public int chapter;
    public int stage;


    public QuestType questType;
    public string targetID;
    public int targetCount;


    public int rewardGold;
    public ItemData rewardItem;

    public string startStoryKey;
    public string progressStoryKey;
    public string completeStoryKey;


    public QuestData nextQuest;
    public bool autoStartNextQuest;
}
