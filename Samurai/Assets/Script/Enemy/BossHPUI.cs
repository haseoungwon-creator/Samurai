using UnityEngine;
using UnityEngine.UI;

public class BossHPUI : MonoBehaviour
{
    [SerializeField] Transform hpImage;
    [SerializeField] Text bossNameText;
    [SerializeField] Text hpText;

    private const float MaxHPWidth = 800f;
    private Enemy boss;

    private void Update()
    {
        if (boss == null)
        {
            FindBoss();
            return;
        }

        if (boss.IsDead)
        {
            gameObject.SetActive(false);
            return;
        }

        if (!IsBossInView())
        {
            gameObject.SetActive(false);
            return;
        }

        gameObject.SetActive(true);
        UpdateHPUI();
    }

    private void FindBoss()
    {
        Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);

        foreach (Enemy enemy in enemies)
        {
            if (enemy == null || enemy.Data == null)
                continue;

            if (!enemy.Data.isBoss)
                continue;

            boss = enemy;
            gameObject.SetActive(IsBossInView());
            UpdateHPUI();
            return;
        }

        gameObject.SetActive(false);
    }

    private bool IsBossInView()
    {
        if (boss == null)
            return false;

        Camera cam = Camera.main;

        if (cam == null)
            return false;

        Vector3 viewPos = cam.WorldToViewportPoint(boss.transform.position);

        return viewPos.z > 0f &&
               viewPos.x >= 0f &&
               viewPos.x <= 1f &&
               viewPos.y >= 0f &&
               viewPos.y <= 1f;
    }

    private void UpdateHPUI()
    {
        if (boss == null || boss.Data == null)
            return;

        int currentHP = Mathf.Max(0, boss.CurrentHP);
        int maxHP = Mathf.Max(1, boss.Data.maxHP);

        float hpPercent = Mathf.Clamp01((float)currentHP / maxHP);

        if (hpImage != null)
        {
            Vector3 scale = hpImage.localScale;
            scale.x = hpPercent;
            hpImage.localScale = scale;
        }

        if (bossNameText != null)
            bossNameText.text = boss.Data.enemyName;

        if (hpText != null)
            hpText.text = $"{currentHP} / {maxHP}";
    }
}