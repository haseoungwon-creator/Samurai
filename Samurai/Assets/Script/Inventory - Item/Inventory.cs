using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [SerializeField] int maxSlot = 12;
    ItemSlot[] slots;
    ItemSlot[] quickSlots;
    ItemSlot weaponSlot;
    ItemSlot armorSlot;

    protected override void Awake()
    {
        base.Awake();
        slots = new ItemSlot[maxSlot];
        quickSlots = new ItemSlot[4];
        weaponSlot = new ItemSlot();
        armorSlot = new ItemSlot();

        for (int i = 0; i < maxSlot; i++)
        {
            slots[i] = new ItemSlot();
        }
        for (int i = 0; i < 4; i++)
        {
            quickSlots[i] = new ItemSlot();
        }
    }

    public bool AddItem(ItemData data,int qty = 1)
    {
        if (data.isStackable)
        {
            foreach (ItemSlot slot in slots)
            {
                if(slot.itemData == data)
                {
                    slot.AddQuantity(qty);
                    return true;
                }
            }
        }

        foreach(ItemSlot slot in slots)
        {
            if (slot.IsEmpty)
            {
                slot.SetItem(data,qty);
                return true;
            }
        }

        return false;
    }

    public void RemoveItem(int slotIndex)
    {
        slots[slotIndex].Clear();
    }

    public void SwapSlot(ItemSlot a, ItemSlot b)
    {
        ItemData tempData = a.itemData;
        int tempQty = a.quantity;
        a.SetItem(b.itemData, b.quantity);
        b.SetItem(tempData, tempQty);
    }
}
