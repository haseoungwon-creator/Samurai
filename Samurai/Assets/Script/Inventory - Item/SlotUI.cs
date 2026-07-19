using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    [SerializeField] Image iconImage;
    [SerializeField] TextMeshProUGUI quantityText;

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
            return;
        }

        iconImage.enabled = true;
        iconImage.sprite = Slot.itemData.icon;

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

}
