using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("numm.");
        EnemySpawnManager.Instance.RegisterSpawnPoints();
        EnemySpawnManager.Instance.SpawnCurrentStage();
    }
}
