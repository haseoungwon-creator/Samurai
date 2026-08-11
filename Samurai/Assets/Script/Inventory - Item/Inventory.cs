using System.Data;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [SerializeField] int inventorySize = 12;

    public ItemSlot[] inventorySlots;

    public ItemSlot[] quickSlots = new ItemSlot[4];

    public ItemSlot weaponSlot = new ItemSlot();
    public ItemSlot armorSlot = new ItemSlot();

    protected override void Awake()
    {
        base.Awake();

        inventorySlots = new ItemSlot[inventorySize];

        for (int i = 0; i < inventorySize; i++)
            inventorySlots[i] = new ItemSlot();

        for(int i = 0;i < quickSlots . Length; i++)
            quickSlots[i] = new ItemSlot();
    }

    public bool AddItem(ItemData data, int amount = 1)
    {
        if (data.isStackable)
        {
            foreach(ItemSlot slot in inventorySlots)
            {
                if (slot.CanStack(data))
                {
                    slot.Add(amount);


                    return true;
                }
            }
        }

        foreach (ItemSlot slot in inventorySlots)
        {
            if (slot.IsEmpty)
            {
                slot.SetItem(data,amount);


                return true;
            }
        }
        return false;
    }

    public void RemoveItem(ItemSlot slot,int amount = 1)
    {
        slot.Remove(amount);

    }

    public void Swap(ItemSlot a , ItemSlot b)
    {
        if(!a.IsEmpty && !b.IsEmpty && a.itemData == b.itemData && a.itemData.isStackable)
        {
            int total = a.quantity + b.quantity;

            if(total <= a.itemData.maxStack)
            {
                b.quantity = total;
                a.Clear();
            }
            else
            {
                b.quantity = a.itemData.maxStack;
                a.quantity = total - a.itemData.maxStack;
            }
            return;
        }
        ItemData data = a.itemData;
        int amount = a.quantity;

        a.SetItem(b.itemData, b.quantity);

        if(data == null)
            b.Clear();
        else
            b.SetItem(data, amount);

    }

    public void ResetInventory()
    {
        foreach(ItemSlot slot in inventorySlots)
            slot.Clear();
        foreach (ItemSlot slot in quickSlots) slot.Clear();

        weaponSlot.Clear();
        armorSlot.Clear();
    }

}
