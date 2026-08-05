using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    private List<Enemy> enemies = new List<Enemy>();

    private int maxAttackCount = 2;

    private HashSet<Enemy> attackingEnemies = new HashSet<Enemy>();
    public void Register(Enemy enemy)
    {
        if(!enemies.Contains(enemy))
            enemies.Add(enemy);
    }

    public void Unregister(Enemy enemy)
    {
        enemies.Remove(enemy);
        attackingEnemies.Remove(enemy);
    }

    public bool HasAliveEnemy()
    {
        return enemies.Count > 0;
    }

    public List<Enemy> GetEnemies()
    {
        return enemies;
    }

    public bool RequesAttack(Enemy enemy)
    {
        if(attackingEnemies.Contains(enemy)) return true;

        if(attackingEnemies.Count >= maxAttackCount) return false;

        attackingEnemies.Add(enemy); return true;
    }

    public void ReleaseAttack(Enemy enemy)
    {
        attackingEnemies.Remove(enemy);
    }

    public bool IsAttacking(Enemy enemy)
    {
        return attackingEnemies.Contains(enemy);
    }

    public Enemy GetClosesetEnemy(Vector2 playerPos)
    {
        Enemy closest = null;

        float minDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            if(enemy == null) continue;

            float distance = Vector2.Distance(playerPos,enemy.transform.position);

            if(distance < minDistance)
            {
                minDistance = distance; 
                closest = enemy;
            }
        }
        return closest;
    }
}
