using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    private EnemyData enemyData;
    private EnemyAttackData attackData;
    private bool attacked;

    public void Init(
        EnemyAttackData attack,
        EnemyData enemy,
        float direction)
    {
        attackData = attack;
        enemyData = enemy;

        transform.position += new Vector3(
            attack.offset.x * direction,
            attack.offset.y,
            0f
        );

        BoxCollider2D box =
            GetComponent<BoxCollider2D>();

        if (box != null)
            box.size = attack.size;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (attacked)
            return;

        if (enemyData == null)
            return;

        PlayerHealth player =
            collision.GetComponent<PlayerHealth>();

        if (player == null)
            player =
                collision.GetComponentInParent<PlayerHealth>();

        if (player == null)
            return;

        attacked = true;

        player.TakeDamage(
            Mathf.RoundToInt(
                enemyData.attackPower
            )
        );

        if (enemyData.attackCanStun)
        {
            PlayerStun stun =
                player.GetComponent<PlayerStun>();

            if (stun == null)
            {
                stun =
                    player.GetComponentInParent<PlayerStun>();
            }

            stun?.Stun(
                enemyData.attackStunTime
            );
        }
    }
}