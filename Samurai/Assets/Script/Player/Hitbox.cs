using UnityEngine;



public class Hitbox : MonoBehaviour
{
    AttackData attackData;
    public void Init(AttackData data,Vector2 offset, bool facingRight)
    {
        attackData = data;
        float dir = facingRight ? 1 : -1;
        transform.localPosition = new Vector2(offset.x * dir , offset.y);
        Destroy(gameObject, attackData.attackDuration);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy == null) return;
        //enemy.TakeDamage(attackData.damage);
        Destroy(gameObject);
    }
}
