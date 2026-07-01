using UnityEngine;

[CreateAssetMenu(menuName = " Scriptable/AttackData", fileName ="Attack Data")]
public class AttackData : ScriptableObject
{
    public int damage;
    public Vector2 size;
    public Vector2 offset;
    public float duration;
    public GameObject hitboxPrefab;
}
