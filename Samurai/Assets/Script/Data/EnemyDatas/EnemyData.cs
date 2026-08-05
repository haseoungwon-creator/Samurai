using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable/Enemy Data",fileName ="Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string enemyID;
    public string enemyName;
    public GameObject prefab;


    public int maxHP;
    public int rewardGold;
    public float moveSpeed;


    public float attackPower;
    public float skillPower;
    public bool skillStun;
    

    public float detectRange;
    public float attackRange;

    public float minAttackCooldown = 0.8f;
    public float maxAttackCooldown = 1.5f;


    public float pressureDistance = 1.2f;
    public float pressureSpeed = 1.5f;


    public float attackPrepareTime = 0.15f;


    public float attackLungeSpeed = 4f;
    public float attackLungeTime = 0.12f;

    public float recoverTime = 0.2f;
    

    public GameObject hitboxPrefab;
    public EnemyAttackData[] attackDatas;
}
