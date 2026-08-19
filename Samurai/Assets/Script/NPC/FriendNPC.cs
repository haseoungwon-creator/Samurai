using UnityEngine;

public class FriendNPC : NPCBase
{
    [SerializeField] string storyPrefix = "village_friend";

    protected override void TryTalk()
    {
        if(!canTalk) return;

        if(!StoryManager.Instance.CanFriendTalk) return;

        StoryManager.Instance.FriendTalkComplete();

        string storyKey = GetStoryKey();

        StoryController.Instance.Play(storyKey);
    }

    private string GetStoryKey()
    {
        return $"{storyPrefix}_{StoryManager.Instance.FriendStoryIndex}";
    }
}
