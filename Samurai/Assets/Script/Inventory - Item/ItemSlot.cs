[System.Serializable]
public class ItemSlot
{
    public ItemData itemData;
    public int quantity;

    public bool IsEmpty => itemData == null ? true : false;

    public void SetItem(ItemData data, int qty)
    {
        itemData = data;
        quantity = qty;
    }

    public void AddQuantity(int amoumt)
    {
        quantity += amoumt;
    }

    public void Clear()
    {
        itemData = null;
        quantity = 0;
    }
}
