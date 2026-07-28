using UnityEngine;

public class FriendNPC : NPCBase
{
    [SerializeField] string storyPrefix = "village_friend";

    protected override void TryTalk()
    {
        if(!canTalk) return;

        if (talked) return;

        talked = true;

        string storyKey = GetStoryKey();

        StoryController.Instance.Play(storyKey, EndDialogue);
    }

    private string GetStoryKey()
    {
        int stage = WorldManager.Instance.CurrentStage;
        return $"{storyPrefix}_{stage}";
    }

    protected override void EndDialogue()
    {
        
    }
}
