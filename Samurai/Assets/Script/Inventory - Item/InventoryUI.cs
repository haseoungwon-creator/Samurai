using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;

    [SerializeField] SlotUI[] inventorySlots;

    [SerializeField] SlotUI[] quickSlots;

    [SerializeField] SlotUI weaponSlot;
    [SerializeField] SlotUI armorSlot;
    
    public bool isOpen {  get; private set; }

    private void Awake()
    {
        inventoryPanel.SetActive(false);

        InitSlots();
    }

    private void Update()
    {
        Refresh();
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Toggle();
        }
    }

    private void InitSlots()
    {
        for(int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i].SetSlot(Inventory.Instance.inventorySlots[i]);
        }

        for (int i = 0; i < quickSlots.Length; i++)
        {
            quickSlots[i].SetSlot(Inventory.Instance.quickSlots[i]);
        }

        if (weaponSlot != null && armorSlot != null)
        {
            weaponSlot.SetSlot(Inventory.Instance.weaponSlot);
            armorSlot.SetSlot(Inventory.Instance.armorSlot);
        }
        Refresh();
    }

    public void Refresh()
    {
        foreach(SlotUI slot in inventorySlots) slot.Refresh();

        foreach (SlotUI slot in quickSlots) slot.Refresh();

        weaponSlot.Refresh(); armorSlot.Refresh();
    }

    public void Toggle()
    {
        isOpen = !isOpen;

        if (isOpen) Refresh();

        inventoryPanel.SetActive(isOpen);

        if (isOpen)
        {
            MouseManager.Instance.ShowCursor();
        }
        else
        {
            MouseManager.Instance.HideCursor();
        }
    }
}
