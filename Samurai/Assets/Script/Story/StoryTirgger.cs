using UnityEngine;

public class StoryTirgger : MonoBehaviour
{
    
    [SerializeField] GameObject storyPanel;
    [SerializeField] string storyKey = "";
    [SerializeField] string storyKeyPrefix = "";
    [SerializeField] int maxCount = 10;

    private bool isTriggered = false;

    private int meetCount = 0;
    Camera cameraMain;

    

    private void Start()
    {
        cameraMain = Camera.main;
        FadeManager.Instance.SetActiveFade(false);
    }

   

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isTriggered) return;

        if (!collision.CompareTag("Player")) return;

        Vector3 viewPos = cameraMain.WorldToViewportPoint(transform.position);

        bool isVisible =
            viewPos.x > 0f && viewPos.x < 1f && viewPos.y > 0f && viewPos.y < 1f;

        if(!isVisible) return;

        TriggerStory();
        
    }


    void TriggerStory()
    {
        string key = GetCurrentKey();
        if (!StoryDatabase.Exists(key)) return;
        isTriggered = true;
        GameManager.Instance.SetState(GameState.Story);
        storyPanel.SetActive(true);
        var controller = storyPanel.GetComponent<StoryController>();
        controller.StartStory(key, this);
    }

    string GetCurrentKey()
    {
        if (!string.IsNullOrEmpty(storyKeyPrefix))
        {
            meetCount++;
            int clampedCount = Mathf.Clamp(meetCount,1,maxCount);
            return storyKeyPrefix + clampedCount;
        }

        return storyKey;
    }

    public void ResetTrigger()
    {
        isTriggered = false;
    }

    private void OnDisable()
    {
        isTriggered = false;
    }
}
