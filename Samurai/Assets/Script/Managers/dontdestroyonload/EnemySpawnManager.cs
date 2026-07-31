using NUnit.Framework.Constraints;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : Singleton<EnemySpawnManager>
{
    [SerializeField] StageData[] stageDatas;

    Dictionary<string, SpawnPoint> spawnPoints = new();
    readonly List<Enemy> aliveEnemies = new();

    public bool IsStageClear {  get; private set; }



    public void RegisterSpawnPoints()
    {
        spawnPoints.Clear();
        SpawnPoint[] points = FindObjectsByType<SpawnPoint>(FindObjectsSortMode.None);

        foreach(SpawnPoint point in points)
        {
            if(!spawnPoints.ContainsKey(point.SpawnPointID))
            spawnPoints.Add(point.SpawnPointID,point);
        }
    }

    public void SpawnCurrentStage()
    {
        Debug.Log("SpawnCurrentStage");
        StageData stageData = GetCurrentStageData();
            if(stageData == null) return;

        aliveEnemies.Clear();
        IsStageClear = false;

        foreach(EnemySpawnInfo info in stageData.spawnInfos)
        {
            SpawnEnemy(info);
        }
    }

    private void SpawnEnemy(EnemySpawnInfo info)
    {
        Debug.Log(WorldManager.Instance.CurrentStage + "-" + WorldManager.Instance.CurrentChapter);
        if (!spawnPoints.TryGetValue(info.spawnPointID,out SpawnPoint point))
        {
            return;
        }
        Debug.Log("true");
        GameObject obj = Instantiate(info.enemyData.prefab, point.transform.position, Quaternion.identity);
        
        Enemy enemy = obj.GetComponent<Enemy>();

        if(enemy != null)
        {
            aliveEnemies.Add(enemy);
            enemy.Initialize(info.enemyData);
        }
    }

    private StageData GetCurrentStageData()
    {
        foreach(StageData data in stageDatas)
        {
            if(data.chapter == WorldManager.Instance.CurrentChapter&&
                data.stage == WorldManager.Instance.CurrentStage)
            {
                return data;
            }
        }

        return null;
    }

    public void RemoveEnemy(Enemy enemy)
    {
        if (!aliveEnemies.Contains(enemy)) return;

        aliveEnemies.Remove(enemy);

        if(aliveEnemies.Count == 0)
        {
            StageClear();
        }
    }

    private void StageClear()
    {
        IsStageClear = true;

    }

    
                                                                                  
}
