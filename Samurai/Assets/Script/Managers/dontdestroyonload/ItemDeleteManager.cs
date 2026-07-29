using UnityEditor.Rendering;
using UnityEngine;

public class ItemDeleteManager : Singleton<ItemDeleteManager>
{
    [SerializeField] GameObject deletePanel;
    private SlotUI targetSlot;

    public void RequesDelete(SlotUI slot)
    {
        targetSlot = slot;

        PanelManaager.Instance.Open(panel.DeleteConfirm);
    }

    


    public void ConfirmDelete()
    {
        if(targetSlot == null) return;

        targetSlot.Slot.Clear();

        InventoryUI inventoryUI= FindAnyObjectByType<InventoryUI>();

        if(inventoryUI != null )
            inventoryUI.Refresh();

        PanelManaager.Instance.Close(panel.DeleteConfirm);


        targetSlot = null;
    }

    public void CancelDelete()
    {
        targetSlot = null;

        PanelManaager.Instance.Close(panel.DeleteConfirm);
    }
}
