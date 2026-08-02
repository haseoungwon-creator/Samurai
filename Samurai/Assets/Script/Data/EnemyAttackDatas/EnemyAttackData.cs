using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Enemy Attack Data", fileName = "Enemy Attack Data")]
public class EnemyAttackData : ScriptableObject
{
    public Vector2 offset;
    public Vector2 size;
}