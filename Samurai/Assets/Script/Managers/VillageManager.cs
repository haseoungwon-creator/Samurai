using UnityEngine;

public class VillageManager : MonoBehaviour
{
    private void Start()
    {
        FadeManager.Instance.SetActiveFade(false);
        StoryController.Instance.FindUI();
    }
}
