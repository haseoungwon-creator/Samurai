using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    [SerializeField] GameObject questPanel;

    [SerializeField] Text questNameText;

    [SerializeField] Text descriptionText;

    [SerializeField] Text progressText;

    private void Update()
    {
        UpdateQuestUI();
    }

    private void UpdateQuestUI()
    {
        QuestData quest = QuestManager.Instance.CurrentQuest;

        if(quest == null)
        {
            questPanel.SetActive(false);
            return;
        }

        questPanel.SetActive(true);

        questNameText.text = quest.questName;

        descriptionText.text = quest.description;

        progressText.text = $"{QuestManager.Instance.CurrentCount} / {quest.targetCount}";
    }
}
