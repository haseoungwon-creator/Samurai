using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private readonly List<Enemy> enemies = new List<Enemy>();
    private readonly HashSet<Enemy> attackingEnemies = new HashSet<Enemy>();

    [SerializeField] private int maxAttackers = 2;

    public void Register(Enemy enemy)
    {
        if (enemy == null)
            return;

        if (!enemies.Contains(enemy))
            enemies.Add(enemy);
    }

    public void Unregister(Enemy enemy)
    {
        if (enemy == null)
            return;

        enemies.Remove(enemy);
        attackingEnemies.Remove(enemy);
    }

    public bool HasAliveEnemy()
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i] == null || enemies[i].IsDead)
                enemies.RemoveAt(i);
        }

        return enemies.Count > 0;
    }

    public List<Enemy> GetEnemies()
    {
        return enemies;
    }

    public Enemy GetClosestEnemy(Vector2 position)
    {
        Enemy closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            Enemy enemy = enemies[i];

            if (enemy == null || enemy.IsDead)
            {
                enemies.RemoveAt(i);
                continue;
            }

            float distance = (enemy.transform.position - (Vector3)position).sqrMagnitude;

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }

    public bool RequestAttack(Enemy enemy)
    {
        if (enemy == null || enemy.IsDead)
            return false;

        if (attackingEnemies.Contains(enemy))
            return true;

        if (attackingEnemies.Count >= maxAttackers)
            return false;

        attackingEnemies.Add(enemy);
        return true;
    }

    public void ReleaseAttack(Enemy enemy)
    {
        if (enemy == null)
            return;

        attackingEnemies.Remove(enemy);
    }

    public bool IsAnyEnemyUsingDashAttackCombo()
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            Enemy enemy = enemies[i];

            if (enemy == null || enemy.IsDead)
            {
                enemies.RemoveAt(i);
                continue;
            }

            EnemySkillExecutor skillExecutor = enemy.GetComponent<EnemySkillExecutor>();

            if (skillExecutor == null)
                continue;

            if (skillExecutor.CurrentSkill == EnemySkillType.DashAttackCombo)
                return true;
        }

        return false;
    }
}
