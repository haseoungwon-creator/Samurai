using UnityEngine;

public class UIOrderManager : Singleton<UIOrderManager>
{
    [SerializeField] Canvas storyCanvas;
    [SerializeField] Canvas inventoryCanvas;

    private void FindCanvas()
    {
        if(storyCanvas == null)
        {
            storyCanvas = GameObject.Find("StoryCanvas")?.GetComponent<Canvas>();
        }

        if(inventoryCanvas == null)
        {
            inventoryCanvas = GameObject.Find("InventoryCanvas")?.GetComponent<Canvas>();
        }
    }

    public void StoryMode(bool active)
    {
        FindCanvas();
        if (storyCanvas == null || inventoryCanvas == null) return;

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
