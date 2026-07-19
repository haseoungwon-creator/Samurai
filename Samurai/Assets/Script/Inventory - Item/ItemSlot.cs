using System;

[Serializable]
public class ItemSlot
{
    public ItemData itemData;
    public int quantity;

    public bool IsEmpty => itemData == null;

    public bool CanStack(ItemData data)
    {
        return itemData == data && itemData.isStackable && quantity < itemData.maxStack;
    }

    public void SetItem(ItemData data, int amount)
    {
        itemData = data;
        quantity = amount;
    }

    public void Add(int amount)
    {
        quantity += amount;

        if (quantity > itemData.maxStack)
            quantity = itemData.maxStack;
    }

    public void Remove(int amount)
    {
        quantity -= amount;

        if (quantity <= 0)
            Clear();
    }

    public void Clear()
    {
        itemData = null;
        quantity = 0;
    }
}
