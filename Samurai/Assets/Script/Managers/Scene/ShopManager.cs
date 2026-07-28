using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] ShopData[] shopData;

    [SerializeField] Transform content;

    [SerializeField] ShopSlot ShopSlotPrefab;

    private void Start()
    {
        CreateShop();
    }

    private void CreateShop()
    {
        foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }

        foreach(ShopData data in shopData)
        {
            ShopSlot slot = Instantiate(ShopSlotPrefab, content);

            slot.SetData(data);
        }
    }
}
