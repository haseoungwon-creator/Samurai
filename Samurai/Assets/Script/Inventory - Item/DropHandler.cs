using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour,IDropHandler
{
   SlotUI slotUI;

    private void Awake()
    {
        slotUI = GetComponent<SlotUI>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        SlotUI draggedSlot = eventData.pointerDrag.GetComponent<SlotUI>();
        if (slotUI == draggedSlot) return;

        Inventory.Instance.SwapSlot(slotUI.slot,draggedSlot.slot);

        slotUI.UpdateUI();
        draggedSlot.UpdateUI();
    }
}
