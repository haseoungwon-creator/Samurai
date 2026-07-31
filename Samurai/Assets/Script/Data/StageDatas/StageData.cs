using UnityEngine;

[CreateAssetMenu(menuName ="Stage/StageData",fileName ="StageData")]
public class StageData : ScriptableObject
{
    public int chapter;

    public int stage;

    public EnemySpawnInfo[] spawnInfos;
}
