using Unity.VisualScripting;
using UnityEngine;

public class QuestNPC : NPCBase
{
    [SerializeField] QuestData[] quests;

    Transform player;

    

    private void Update()
    {
        LookAtPlayer();
    }

    protected override void TryTalk()
    {
        if (!canTalk) return;

        if (!StoryManager.Instance.CanTeachTalk) return;

        StoryManager.Instance.TeacherTalkComplete();

        if(QuestManager.Instance.CurrentQuest == null)
        {
            StartNewQuest();
        }
        if (QuestManager.Instance.IsCompleted)
        {
            CompleteQuest();
        }

    }

    private void CompleteQuest()
    {
        QuestData currentQuest = QuestManager.Instance.CurrentQuest;

        QuestData nextQuest = currentQuest.nextQuest;

        if(nextQuest == null)
        {
            QuestManager.Instance.SubmitQuest();
            EndDialogue();
            return;
        }

        StoryController.Instance.Play(
            nextQuest.startStoryKey,
            () =>
            {
                QuestManager.Instance.SubmitQuest();

                if (currentQuest.autoStartNextQuest)
                {
                    QuestManager.Instance.StartNextQuest();
                }

                EndDialogue();
            });
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

    private void LookAtPlayer()
    {
        if (player == null)
        {
           GameObject obj = GameObject.FindGameObjectWithTag("Player");

            if (obj != null)
                player = obj.transform;
        }

            Vector3 scale = transform.localScale;

        scale.x = player.position.x > transform.position.x ? -1 : 1;

        transform.localScale = scale;
    }
}