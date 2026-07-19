using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/itemData", fileName = "Item Data")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public string description;
    public ItemType itemType;
    public bool isStackable;
    public int maxStack;
    public Ability ability;
    public int Stat;
}
