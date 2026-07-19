using UnityEngine;

public class ItemUse : Singleton<ItemUse>
{
    PlayerHealth playerHealth;

    protected override void Awake()
    {
        base.Awake();
        playerHealth = FindAnyObjectByType<PlayerHealth>();
    }

    public void Use(ItemSlot slot)
    {
        if(slot == null|| slot.IsEmpty) return;

        Debug.Log("Item Use");
        switch (slot.itemData.itemType)
        {
            case ItemType.Consumable:
                UseConsumable(slot); break;

            case ItemType.Weapon:
                EquipWeapon(slot); break;

            case ItemType.Armor:
                EquipArmor(slot); break;
        }
    }

    void UseConsumable(ItemSlot slot)
    {
        switch (slot.itemData.ability)
        {
            case Ability.Hp:
                playerHealth.Heal(slot.itemData.Stat); break;

            case Ability.PlusDamage:
                PlayerStat.Instance.StartPulsDamage(5f); break;

            case Ability.Speed:
                PlayerStat.Instance.StartPulsSpeed(5f); break;
        }

        slot.Remove(1);
    }

    void EquipWeapon(ItemSlot slot)
    {
        Inventory.Instance.Swap(slot,Inventory.Instance.weaponSlot);
    }

    void EquipArmor(ItemSlot slot)
    {
        Inventory.Instance.Swap(slot,Inventory.Instance.armorSlot);
    }
}
