using UnityEngine;

public class QuickSlotManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { UseQuickSlot(0); }

        if (Input.GetKeyDown(KeyCode.Alpha2)) { UseQuickSlot(1); }

        if (Input.GetKeyDown(KeyCode.Alpha3)) { UseQuickSlot(2); }

        if (Input.GetKeyDown(KeyCode.Alpha4)) { UseQuickSlot(3); }
    }


    private void UseQuickSlot(int index)
    {
        ItemSlot slot = Inventory.Instance.quickSlots[index];

        if (slot == null || slot.IsEmpty) return;

        ItemUse.Instance.Use(slot);
    }
}
