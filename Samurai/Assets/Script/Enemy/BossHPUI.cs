using UnityEngine;
using UnityEngine.UI;

public class BossHPUI : MonoBehaviour
{
    [SerializeField] GameObject HpBg;
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
            SetUIAlpha(0f);
            boss = null;
            return;
        }

        if (!IsBossInView())
        {
            SetUIAlpha(0f);
            return;
        }

        SetUIAlpha(1f);
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

            if (IsBossInView())
                SetUIAlpha(1f);
            else
                SetUIAlpha(0f);

            UpdateHPUI();
            return;
        }

        SetUIAlpha(0f);
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

    private void SetUIAlpha(float alpha)
    {
        if(HpBg != null)
        {
            Image imageHpBg = HpBg.GetComponent<Image>();
            Color color = imageHpBg.color;
            color.a = alpha;
            imageHpBg.color = color;
        }

        if (hpImage != null)
        {
            Image image = hpImage.GetComponent<Image>();

            if (image != null)
            {
                Color color = image.color;
                color.a = alpha;
                image.color = color;
            }
        }

        if (bossNameText != null)
        {
            Color color = bossNameText.color;
            color.a = alpha;
            bossNameText.color = color;
        }

        if (hpText != null)
        {
            Color color = hpText.color;
            color.a = alpha;
            hpText.color = color;
        }
    }
}