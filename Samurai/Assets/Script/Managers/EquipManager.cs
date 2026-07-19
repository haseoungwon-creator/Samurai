using UnityEngine;

public class EquipManager : Singleton<EquipManager>
{
    public ItemSlot WeaponSlot => Inventory.Instance.weaponSlot;
    public ItemSlot ArmorSlot => Inventory.Instance.armorSlot;

    public void Equip(ItemSlot slot)
    {
        if(slot.IsEmpty) return;

        switch (slot.itemData.itemType)
        {
            case ItemType.Weapon:EquipWeapon(slot); break;
            case ItemType.Armor:EquipArmor(slot); break;
        }
    }

    private void EquipWeapon(ItemSlot slot)
    {
        UnequipWeapon();

        Inventory.Instance.Swap(slot,WeaponSlot);

        PlayerStat.Instance.AddStat(WeaponSlot.itemData.ability, WeaponSlot.itemData.Stat);
    }

    private void EquipArmor(ItemSlot slot)
    {
        UnequipArmor();

        Inventory.Instance.Swap(slot, ArmorSlot);

        PlayerStat.Instance.AddStat(ArmorSlot.itemData.ability, ArmorSlot.itemData.Stat);
    }

    public void UnequipWeapon()
    {
        if (WeaponSlot.IsEmpty) return;

        PlayerStat.Instance.RemoveStat(WeaponSlot.itemData.ability,WeaponSlot.itemData.Stat);
    }

    public void UnequipArmor()
    {
        if(ArmorSlot.IsEmpty) return;

        PlayerStat.Instance.RemoveStat(ArmorSlot.itemData.ability,ArmorSlot.itemData.Stat);
    }
}
