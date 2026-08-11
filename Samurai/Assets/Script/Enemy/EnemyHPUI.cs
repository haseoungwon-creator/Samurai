using UnityEngine;

public class EnemyHPUI : MonoBehaviour
{
    [SerializeField] Transform hpImage;

    private const float MaxHPScale = 1.2f;

    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    private void Update()
    {
        UpdateHPUI();
    }

    private void UpdateHPUI()
    {
        if (enemy == null || enemy.Data == null)
            return;

        int currentHP = Mathf.Max(0, enemy.CurrentHP);
        int maxHP = Mathf.Max(1, enemy.Data.maxHP);

        float hpPercent = Mathf.Clamp01((float)currentHP / maxHP);

        Vector3 scale = hpImage.localScale;
        scale.x = MaxHPScale * hpPercent;
        hpImage.localScale = scale;

        if (enemy.IsDead)
            gameObject.SetActive(false);
    }
}