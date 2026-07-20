using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    [SerializeField] Image iconImage;
    [SerializeField] Text nameText;
    [SerializeField] Text priceText;
    [SerializeField] Button buyButton;

    ShopData shopData;

    private void Update()
    {
        CheckBuyButton();
    }
    public void SetData(ShopData data)
    {
        shopData = data;

        iconImage.sprite = data.itemData.icon;
        nameText.text = data.itemData.name;
        priceText.text = data.price.ToString() + "G";

        buyButton.onClick.RemoveAllListeners();
        buyButton.onClick.AddListener(Buy);
    }

    private void Buy()
    {
        if (!GoldManager.Instance.UseGold(shopData.price))
        {
            Debug.Log("no gold");
            return;
        }

        if (!Inventory.Instance.AddItem(shopData.itemData))
        {
            Debug.Log("full Inventory");

            GoldManager.Instance.AddGold(shopData.price);
            return;
        }

        Debug.Log(shopData.itemData.name + "Buy");
    }

    private void CheckBuyButton()
    {
        buyButton.interactable = GoldManager.Instance.Gold >= shopData.price;
    }
}
