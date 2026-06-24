using UnityEngine;

public class StoryTirgger : MonoBehaviour
{
    
    [SerializeField] GameObject storyPanel;

    private Transform player;
    private bool isTriggered = false;
    private float triggerDistance = 2f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (!isTriggered) return;

        float distance = Vector2.Distance(transform.position,player.position);

        if (distance < triggerDistance)
        {
            TriggerStory();
        }
    }

    void TriggerStory()
    {
        isTriggered = true;
        storyPanel.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTriggered) return;

        if (collision.CompareTag("Player"))
        {
            isTriggered = true;

            GameManager.Instance.SetState(GameState.Story);
        }
    }
}
