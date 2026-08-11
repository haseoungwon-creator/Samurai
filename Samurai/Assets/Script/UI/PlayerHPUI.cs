using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MonoBehaviour
{
    [SerializeField] RectTransform hpImage;
    [SerializeField] Text hpText;

    private const float MaxHPWidth = 400f;

    private void Update()
    {
        UpdateHPUI();
    }

    private void UpdateHPUI()
    {
        if (GameManager.Instance == null || GameManager.Instance.Player == null)
            return;

        PlayerHealth playerHealth = GameManager.Instance.Player.GetComponent<PlayerHealth>();

        if (playerHealth == null)
            return;

        int currentHP = Mathf.Max(0, playerHealth.CurrentHP);
        int maxHP = Mathf.Max(0, PlayerStat.Instance.MaxHp);

        float hpPercent = maxHP > 0 ? (float)currentHP / maxHP : 0f;
        hpPercent = Mathf.Clamp01(hpPercent);

        hpImage.sizeDelta = new Vector2(MaxHPWidth * hpPercent, hpImage.sizeDelta.y);
        hpText.text = $"{currentHP} / {maxHP}";
    }
}