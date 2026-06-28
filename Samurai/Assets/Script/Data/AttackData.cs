using UnityEngine;

[CreateAssetMenu(menuName = "AttackData/AttackData",fileName ="Attack Data")]
public class AttackData : ScriptableObject
{
    public int damage;

    public float knockBackPower;
    public float attackDuration;
    public float comboWindowTime;

    public Vector2 hitboxSize;
    public Vector2 hitboxOffset;
}
