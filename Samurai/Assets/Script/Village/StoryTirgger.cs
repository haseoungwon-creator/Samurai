using UnityEngine;

public class StoryTirgger : MonoBehaviour
{
    private bool isTriggered = false;

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
