using UnityEngine;

public class Hitbox : MonoBehaviour
{
    AttackData attackData;

    public void Init(AttackData data,float direction)
    {
        Debug.Log("hitbox reset");
        attackData = data;

        transform.localPosition = new Vector2(data.offset.x * direction, 0);

        GetComponent<BoxCollider2D>().size = data.size;

        Destroy(gameObject, data.duration);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hitbox collision");
        Enemy enemy =  collision.GetComponent<Enemy>();
        if (enemy == null) return;

        enemy.TakeDamage(attackData.damage);
        Destroy(gameObject);
    }
}
