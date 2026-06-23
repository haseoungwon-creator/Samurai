using UnityEngine;

public class StoryTirgger : MonoBehaviour
{
    public float triggerDistance = 2f;
    private Transform player;
    private bool isTriggered = false;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (isTriggered) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < triggerDistance)
        {
            TriggerStory();
        }
    }

    private void TriggerStory()
    {
        CameraManager.Instance.Zoomin();
    }
}
