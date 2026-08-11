//using System.Collections;
//using UnityEngine;

//public class EnemySkillDashCombo : MonoBehaviour
//{
//    private Enemy enemy;
//    private Transform player;
//    private EnemyManager enemyManager;
//    private Coroutine comboCoroutine;

//    private const float ScreenEdgeMargin = 0.5f;
//    private const float FallbackDistance = 5f;
//    private const float HitDistance = 0.6f;
//    private const float PauseTime = 0.25f;
//    private const float DashInterval = 0.12f;

//    public void Init(Enemy enemy, Transform player)
//    {
//        this.enemy = enemy;
//        this.player = player;
//        enemyManager = FindAnyObjectByType<EnemyManager>();
//    }

//    public void StartCombo()
//    {
//        if (comboCoroutine != null)
//            StopCoroutine(comboCoroutine);

//        comboCoroutine = StartCoroutine(DashRoutine());
//    }

//    private IEnumerator DashRoutine()
//    {
//        if (enemy == null || player == null)
//        {
//            Finish();
//            yield break;
//        }

//        int approachCount =
//            Mathf.Max(
//                1,
//                enemy.Data.dashApproachCount
//            );

//        int hitCount =
//            Mathf.Max(
//                1,
//                enemy.Data.dashHitCount
//            );

//        for (int i = 0; i < approachCount; i++)
//        {
//            float side =
//                i % 2 == 0 ? 1f : -1f;

//            float targetX =
//                GetScreenEdgeX(side);

//            TeleportTo(targetX);

//            yield return new WaitForSeconds(
//                DashInterval
//            );
//        }

//        yield return new WaitForSeconds(
//            PauseTime
//        );

//        for (int i = 0; i < hitCount; i++)
//        {
//            float side =
//                i % 2 == 0 ? 1f : -1f;

//            float targetX =
//                player.position.x +
//                side * HitDistance;

//            TeleportTo(targetX);

//            DamagePlayer();

//            yield return new WaitForSeconds(
//                DashInterval
//            );
//        }

//        DamageScreenEnemies();

//        Finish();
//    }

//    private float GetScreenEdgeX(float side)
//    {
//        Camera cam = Camera.main;

//        if (cam == null || !cam.orthographic)
//        {
//            return player.position.x +
//                   side * FallbackDistance;
//        }

//        float halfWidth =
//            cam.orthographicSize *
//            cam.aspect;

//        return cam.transform.position.x +
//               side *
//               (halfWidth - ScreenEdgeMargin);
//    }

//    private void TeleportTo(float targetX)
//    {
//        Vector3 position =
//            enemy.transform.position;

//        position.x = targetX;

//        enemy.transform.position = position;
//    }

//    private void DamagePlayer()
//    {
//        if (player == null)
//            return;

//        PlayerHealth playerHealth =
//            player.GetComponent<PlayerHealth>();

//        if (playerHealth == null)
//            return;

//        playerHealth.TakeDamage(
//            Mathf.RoundToInt(
//                enemy.Data.skillPower
//            )
//        );
//    }

//    private void DamageScreenEnemies()
//    {
//        if (enemyManager == null)
//            return;

//        enemyManager.DamageEnemiesInScreen(
//            enemy.Data.skillPower
//        );
//    }

//    private void Finish()
//    {
//        comboCoroutine = null;

//        if (enemy != null)
//            enemy.SkillFinish();
//    }

//    public void StopCombo()
//    {
//        if (comboCoroutine == null)
//            return;

//        StopCoroutine(comboCoroutine);
//        comboCoroutine = null;
//    }

//    private void OnDestroy()
//    {
//        StopCombo();
//    }
//}