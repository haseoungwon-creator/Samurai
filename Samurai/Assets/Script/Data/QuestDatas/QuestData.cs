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


    public QuestData nextQuest;
    public bool autoStartNextQuest;

    public string targetScene;
    public string spawnPointID;
    public bool returnVillage;

    public bool nextStory;
}
