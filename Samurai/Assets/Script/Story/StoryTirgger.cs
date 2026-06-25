using UnityEngine;

public class StoryTirgger : MonoBehaviour
{
    
    [SerializeField] GameObject storyPanel;
    private bool isTriggered = false;
    Camera cameraMain;

    

    private void Start()
    {
        cameraMain = Camera.main;
    }

   

    void TriggerStory()
    {
        isTriggered = true;
        storyPanel.SetActive(true);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isTriggered) return;

        if (!collision.CompareTag("Player")) return;

        Vector3 viewPos = cameraMain.WorldToViewportPoint(transform.position);

        bool isVisible =
            viewPos.x > 0f && viewPos.x < 1f && viewPos.y > 0f && viewPos.y < 1f;

        if(!isVisible) return;

        GameManager.Instance.SetState(GameState.Story);
        
            isTriggered = true;

            GameManager.Instance.SetState(GameState.Story);

        storyPanel.SetActive(true);
        
    }
}
