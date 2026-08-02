using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    EnemyData enemyData;

    bool attacked;

    public void Init(EnemyAttackData attack, EnemyData enemy, float direction)
    {
        enemyData = enemy;

        transform.position += new Vector3(
            attack.offset.x * direction,
            attack.offset.y,
            0);

        GetComponent<BoxCollider2D>().size = attack.size;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (attacked)
            return;

        PlayerHealth player = collision.GetComponent<PlayerHealth>();

        if (player == null)
            return;

        attacked = true;

        player.TakeDamage(Mathf.RoundToInt(enemyData.attackPower));
    }
}