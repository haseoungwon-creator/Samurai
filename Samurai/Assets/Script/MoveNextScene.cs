using UnityEngine;

public class MoveNextScene : MonoBehaviour
{
    [SerializeField] string nextScene;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneryManager.Instance.LoadScene(nextScene);
    }
}
