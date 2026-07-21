using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/QuestData",fileName ="Quest Data")]
public class QuestData : ScriptableObject
{
    public int chapter;
    public int stage;
    
    public string questID;

    public string questName;

    public string description;

    public QuestType questType;

    public string targetID;

    public int targetCount;

    public int RewardGold;

    public ItemData rewaedItem;
}
