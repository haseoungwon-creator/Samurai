using UnityEngine;

public class NPCBase : MonoBehaviour
{
    [SerializeField] protected string storyKey;

    protected bool canTalk;
    protected bool talked;

    private void Awake()
    {
        NPCManager.Instance.Register(this);
    }

    private void OnDestroy()
    {
        if(NPCManager.Instance)
            NPCManager.Instance.Unregister(this);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        canTalk = true;

        TryTalk();
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        canTalk=false;
    }

    protected virtual void TryTalk()
    {
        if (!canTalk) return;

        if (talked) return;

        if (StoryController.Instance.IsPlaying) return;

        talked = true;

        StoryController.Instance.Play(storyKey);
    }

    public void ResetTalk()
    {
        talked = false;
    }

    public bool HasTalked()
    {
        return talked;
    }
}
