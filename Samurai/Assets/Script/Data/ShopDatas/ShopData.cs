using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/ShopData",fileName ="Shop Data")]
public class ShopData : ScriptableObject
{
    public ItemData itemData;
    public int price;
}