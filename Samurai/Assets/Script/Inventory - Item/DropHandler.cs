using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    SlotUI mySlot;

    [SerializeField] ItemType allowType = ItemType.None;
    private void Awake()
    {
        if (mySlot == null)
            mySlot = GetComponent<SlotUI>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (DragHandler.DragSlot == null) return;

       SlotUI dragSlot = DragHandler.DragSlot;

        if (dragSlot == mySlot) return;

        if(allowType != ItemType.None)
        {
            if (dragSlot.Slot.IsEmpty) return;
            if (dragSlot.Slot.itemData.itemType != allowType)
                return;
        }
        if (dragSlot.Slot.IsEmpty) return;

        if (mySlot.Slot == null) return;

        if(allowType == ItemType.Weapon ||  allowType == ItemType.Armor)
        {
            EquipManager.Instance.Equip(dragSlot.Slot);
            return;
        }
        Inventory.Instance.Swap(dragSlot.Slot, mySlot.Slot);
    }
}

