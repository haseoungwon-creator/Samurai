using NUnit.Framework;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{

    private List<Enemy> enemies = new List<Enemy>();

   

    public void Register(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public void Unregister(Enemy enemy)
    {
        enemis.Remove(enemy);
    }

    public bool HasAliveEnemy()
    {
        return enemies.Count > 0;
    }
}
