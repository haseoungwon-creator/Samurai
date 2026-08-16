using UnityEngine;

// Final Enemy 오브젝트에 이 스크립트를 임시로 추가하면
// 그 적 머리 위에 현재 상태값이 실시간으로 표시됩니다.
// 원인 확인 후 컴포넌트를 지우거나 비활성화하면 됩니다.
public class EnemyDebugOverlay : MonoBehaviour
{
    private Enemy enemy;
    private Rigidbody2D rb;
    private Animator animator;
    private EnemyAttackExecutor attackExecutor;
    private EnemySkillExecutor skillExecutor;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        attackExecutor = GetComponent<EnemyAttackExecutor>();
        skillExecutor = GetComponent<EnemySkillExecutor>();
    }

    private void OnGUI()
    {
        if (enemy == null) return;

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 1.5f);
        if (screenPos.z < 0) return;

        float guiY = Screen.height - screenPos.y;

        GUIStyle style = new GUIStyle();
        style.fontSize = 14;
        style.normal.textColor = Color.yellow;

        string text =
            $"HP: {enemy.CurrentHP}\n" +
            $"rb null: {rb == null}\n" +
            $"animator null: {animator == null}\n" +
            $"attackExecutor null: {attackExecutor == null}\n" +
            $"skillExecutor null: {skillExecutor == null}\n" +
            $"IsUsingSkill: {(skillExecutor != null ? skillExecutor.IsUsingSkill.ToString() : "N/A")}\n" +
            $"CurrentSkill: {(skillExecutor != null ? skillExecutor.CurrentSkill.ToString() : "N/A")}\n" +
            $"CanUpdateAi: {enemy.CanUpdateAi}\n" +
            $"IsDead: {enemy.IsDead}\n" +
            $"DistToPlayer: {(enemy.Player != null ? Vector2.Distance(transform.position, enemy.Player.position).ToString("F2") : "no player")}";

        GUI.Box(new Rect(screenPos.x - 80, guiY - 160, 220, 160), "");
        GUI.Label(new Rect(screenPos.x - 75, guiY - 155, 220, 160), text, style);
    }
}