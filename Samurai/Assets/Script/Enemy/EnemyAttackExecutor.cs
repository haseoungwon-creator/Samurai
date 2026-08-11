using UnityEngine;

public class EnemyAttackExecutor : MonoBehaviour
{
    private Enemy enemy;
    private GameObject currentHitbox;

    public void Initialize(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void StartAttack()
    {
        if (enemy == null) return;

        EnemyData data = enemy.Data;
        if (data == null) return;
        if (data.attackDatas == null || data.attackDatas.Length == 0) return;

        int attackIndex = Random.Range(0, data.attackDatas.Length);

        enemy.SetAttackIndex(attackIndex);
        enemy.PlayAttackAnimation();
    }

    public void SpawnHitbox(int index)
    {
        if (enemy == null) return;

        EnemyData data = enemy.Data;
        if (data == null) return;
        if (data.hitboxPrefab == null) return;
        if (data.attackDatas == null) return;
        if (index < 0 || index >= data.attackDatas.Length) return;

        DestroyHitbox();

        EnemyAttackData attackData = data.attackDatas[index];
        if (attackData == null) return;

        float direction = enemy.transform.localScale.x >= 0f ? 1f : -1f;

        currentHitbox = Instantiate(
            data.hitboxPrefab,
            enemy.transform.position,
            Quaternion.identity
        );

        EnemyHitbox hitbox = currentHitbox.GetComponent<EnemyHitbox>();

        if (hitbox == null)
        {
            Destroy(currentHitbox);
            currentHitbox = null;
            return;
        }

        hitbox.Init(attackData, data, direction);
    }

    public void DestroyHitbox()
    {
        if (currentHitbox == null) return;

        Destroy(currentHitbox);
        currentHitbox = null;
    }

    public void CancelAttack()
    {
        DestroyHitbox();
    }

    private void OnDestroy()
    {
        DestroyHitbox();
    }
}