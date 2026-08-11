using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Enemy Data", fileName = "Enemy Data")]
public class EnemyData : ScriptableObject
{
    [Header("기본 정보")]
    public string enemyID;
    public string enemyName;
    public bool isBoss;
    public GameObject prefab;

    [Header("스탯")]
    public int maxHP = 100;
    public int rewardGold = 10;
    public float moveSpeed = 2f;

    [Header("AI")]
    public float detectRange = 8f;
    public float keepDistance = 1.2f;
    public float keepDistanceSpeed = 1.5f;
    public float recoverTime = 0.2f;
    public float hurtTime = 0.2f;

    [Header("일반 공격")]
    public float attackPower = 10f;
    public float attackRange = 1.2f;
    public float attackPrepareTime = 0.15f;
    public float attackCooldownMin = 0.8f;
    public float attackCooldownMax = 1.5f;
    public bool attackCanStun;
    public float attackStunTime = 0.5f;
    public EnemyAttackData[] attackDatas;
    public GameObject hitboxPrefab;

    [Header("스킬 공통")]
    [Range(0f, 100f)]
    public float skillChance = 30f;

    [Header("뒤잡기 공격")]
    public bool useBehindAttack;

    [Range(0f, 100f)]
    public float behindAttackChance = 30f;

    public float behindAttackCooldown = 5f;
    public float behindAttackDamage = 20f;
    public float behindAttackDistance = 1f;

    [Header("대시 공격 콤보")]
    public bool useDashAttackCombo;

    [Range(0f, 100f)]
    public float dashAttackChance = 30f;

    public float dashAttackCooldown = 8f;
    public float dashAttackDamage = 30f;
    public float dashStartDistance = 4f;
    public float dashHitDistance = 0.6f;
    public float dashPauseTime = 0.25f;
    public float dashIntervalStart = 0.35f;
    public float dashIntervalEnd = 0.08f;
    public int dashHitCount = 4;

    [Header("투명화")]
    public bool useInvisibility;

    [Range(0f, 100f)]
    public float invisibilityChance = 20f;

    public float invisibilityCooldown = 10f;
    public float invisibilityDuration = 4f;
}