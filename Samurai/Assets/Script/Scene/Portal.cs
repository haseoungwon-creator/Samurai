using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] bool returnVillage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;



        if (returnVillage)
        {
            if(QuestManager.Instance.IsCompleted)
                SceneryManager.Instance.LoadScene("Village");
        }
        else
        {
            QuestData quest = QuestManager.Instance.CurrentQuest;

            if(quest == null) return;

            WorldManager.Instance.SetStage(quest.chapter,quest.stage);

            SceneryManager.Instance.LoadScene(quest.targetScene);
        }
    }
}
