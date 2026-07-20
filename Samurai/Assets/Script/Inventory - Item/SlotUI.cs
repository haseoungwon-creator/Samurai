using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image iconImage;
    [SerializeField] TextMeshProUGUI quantityText;
    [SerializeField] GameObject emptyPanel;
    public ItemSlot Slot { get; private set; }


    public void SetSlot(ItemSlot slot)
    {
        Slot = slot;
        Refresh();
    }

    public void Refresh()
    {
        if(Slot == null || Slot.IsEmpty)
        {
            iconImage.enabled = false;
            quantityText.gameObject.SetActive(false);
            if(emptyPanel != null) emptyPanel.SetActive(true);
            return;
        }

        iconImage.enabled = true;
        iconImage.sprite = Slot.itemData.icon;
        if (emptyPanel != null) emptyPanel.SetActive(false);

        if (Slot.itemData.isStackable)
        {
            quantityText.gameObject.SetActive(true);
            quantityText.text = Slot.quantity.ToString();
        }
        else
        {
            quantityText.gameObject.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(Slot.itemData != null)
        {
            ToolTipManger.Instance.Show(Slot.itemData);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTipManger.Instance.Hide();
    }
}
