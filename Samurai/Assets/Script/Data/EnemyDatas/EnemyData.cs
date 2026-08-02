using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable/Enemy Data",fileName ="Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string enemyID;
    public string enemyName;


    public GameObject prefab;


    public int maxHP;
    public float attackPower;
    public float skillPower;
    public bool skillStun;
    public float moveSpeed;


    public int rewardGold;

    public float detectRange;

    public float attackRange;

    public float attackCooldown;

    public GameObject hitboxPrefab;
    public EnemyAttackData[] attackDatas;
}
