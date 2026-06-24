using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{

    private List<Enemy> enemies = new List<Enemy>();

   

    public void Register(Enemy enemy)
    {
        if(!enemies.Contains(enemy))
            enemies.Add(enemy);
    }

    public void Unregister(Enemy enemy)
    {
        enemies.Remove(enemy);
    }

    public bool HasAliveEnemy()
    {
        return enemies.Count > 0;
    }

    public List<Enemy> GetEnemies()
    {
        return enemies;
    }
}
