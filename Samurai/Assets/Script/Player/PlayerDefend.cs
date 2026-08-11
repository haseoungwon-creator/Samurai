using System.Collections;
using UnityEngine;

public class PlayerDefend : MonoBehaviour
{
    [SerializeField] private float justGuardWindow = 0.15f;
    [SerializeField] private int justGuardDamage = 20;
    [SerializeField] private int maxGuardCount = 3;
    [SerializeField] private float guardBreakTime = 0.8f;

    public bool isDefending { get; private set; }

    private int guardCount;
    private float defendStartTime;

    private PlayerStateMachine stateMachine;
    private PlayerAnimator playerAnimator;
    private PlayerHealth playerHealth;
    private Coroutine guardBreakCoroutine;

    private void Awake()
    {
        stateMachine = GetComponent<PlayerStateMachine>();
        playerAnimator = GetComponent<PlayerAnimator>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    public void StartDefend()
    {
        if (stateMachine == null)
            return;

        if (!stateMachine.CanDefend())
            return;

        if (stateMachine.CurrentState == PlayerState.GuardBreak) return;

        isDefending = true;
        guardCount = 0;
        defendStartTime = Time.time;

        stateMachine.ChangeState(PlayerState.Defend);

        if (playerAnimator != null)
            playerAnimator.SetDefending(true);
    }

    public void StopDefend()
    {
        if (!isDefending)
            return;

        isDefending = false;

        if (playerAnimator != null)
            playerAnimator.SetDefending(false);

        if (stateMachine != null)
            stateMachine.ChangeState(PlayerState.Idle);
    }

    public void TryGuard(Enemy attacker)
    {
        if (!isDefending)
            return;

        bool isJustGuard =
            Time.time - defendStartTime <= justGuardWindow;

        if (isJustGuard)
        {
            if (playerAnimator != null)
                playerAnimator.TriggerGuardReact();

            if (attacker != null)
                attacker.TakeDamage(justGuardDamage);

            if (playerHealth != null)
            {
                playerHealth.StartCoroutine(
                    playerHealth.InvincibleRoutine()
                );
            }

            return;
        }

        if (playerAnimator != null)
            playerAnimator.TriggerGuardReact();

        guardCount++;

        if (guardCount >= maxGuardCount)
            GuardBreak();
    }

    private void GuardBreak()
    {
        isDefending = false;

        if (playerAnimator != null)
            playerAnimator.SetDefending(false);

        if (playerAnimator != null)
            playerAnimator.TriggerGuardBreak();

        if (stateMachine != null)
            stateMachine.ChangeState(PlayerState.GuardBreak);

        if(guardBreakCoroutine != null)
            StopCoroutine(guardBreakCoroutine);

        guardBreakCoroutine = StartCoroutine(GuardBreakRecovery());
    }

    private IEnumerator GuardBreakRecovery()
    {
        yield return CoroutineManager.Wait(guardBreakTime);

        if(stateMachine != null && stateMachine.CurrentState == PlayerState.GuardBreak)
        {
            stateMachine.ChangeState(PlayerState.Idle);
        }

        guardCount = 0;
        guardBreakCoroutine = null;
    }
}