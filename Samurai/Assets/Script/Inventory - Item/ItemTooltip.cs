using TMPro;
using UnityEngine;

public class ItemTooltip : Singleton<ItemTooltip>
{
    [SerializeField] GameObject tooltipPanel;
    [SerializeField] TextMeshProUGUI itemNameText;
    [SerializeField] TextMeshProUGUI descriptionText;

   protected override void Awake()
    {
        base.Awake();
         tooltipPanel.SetActive(false);
    }

    public void Show(ItemData data,Vector2 position)
    {
        tooltipPanel.SetActive(true);
        itemNameText.text = data.itemName;
        descriptionText.text = data.description;

        tooltipPanel.transform.position = Input.mousePosition;
    }

    public void Hide()
    {
        tooltipPanel?.SetActive(false);
    }
}
