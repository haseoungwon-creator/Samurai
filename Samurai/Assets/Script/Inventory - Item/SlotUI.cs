using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    [SerializeField] Image iconImage;
    [SerializeField] TextMeshProUGUI quantityText;
    public ItemSlot slot;

    public void UpdateUI()
    {
        if (slot.IsEmpty)
        {
            iconImage.gameObject.SetActive(false);

            quantityText.gameObject.SetActive(false);
        }
        else
        {
            iconImage.gameObject.SetActive(true);

            iconImage.sprite = slot.itemData.icon;

            if (slot.itemData.isStackable)
            {
                quantityText.gameObject.SetActive(true);
                quantityText.text = slot.quantity.ToString();
            }

            else
                quantityText.gameObject.SetActive(false);
        }
    }

    private void Awake()
    {
        UpdateUI();
    }

}
