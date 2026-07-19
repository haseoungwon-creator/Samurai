using UnityEngine;

public class UIOrderManager : Singleton<UIOrderManager>
{
    [SerializeField] Canvas storyCanvas;
    [SerializeField] Canvas inventoryCanvas;

    public void StoryMode(bool active)
    {
        if (active)
        {
            storyCanvas.sortingOrder = 100;
            inventoryCanvas.sortingOrder = 10;
        }

        else
        {
            storyCanvas.sortingOrder = 10;
            inventoryCanvas.sortingOrder = 100;
        }
    }


}
