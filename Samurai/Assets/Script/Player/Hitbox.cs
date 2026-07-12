using UnityEngine;

public class Hitbox : MonoBehaviour
{
    AttackData attackData;
    public bool attackEnemy {  get; private set; }
    public void Init(AttackData data,float direction)
    {
        attackData = data;

        transform.position = (Vector2)transform.position + new Vector2(data.offset.x * direction, 0);

        GetComponent<BoxCollider2D>().size = data.size;

        Destroy(gameObject, data.duration);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy =  collision.GetComponent<Enemy>();
        if (enemy == null) return;

        attackEnemy = true;
        enemy.TakeDamage(attackData.damage);
        Destroy(gameObject);
    }
}
