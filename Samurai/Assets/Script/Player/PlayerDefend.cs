using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerDefend : MonoBehaviour
{
    [SerializeField] float justGuardWindow;
    [SerializeField] float justGuardInvincibleTime;

    [SerializeField] int justGuardDamage;
    [SerializeField] int maxGuardCount = 3;
    public bool isDefending {  get; private set; }

    int guardCount;

    float defendStartTime;

    PlayerStateMachine stateMahine;
    PlayerAnimator playerAnimator;
    PlayerHealth playerHealth;

    private void Awake()
    {
        stateMahine = GetComponent<PlayerStateMachine>();
        playerAnimator = GetComponent<PlayerAnimator>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    public void StartDefend()
    {
        if (!stateMahine.CanDefend()) return;

        isDefending = true;
        guardCount = 0;
        defendStartTime = Time.time;

        stateMahine.ChangeState(PlayerState.Defend);
        playerAnimator.SetDefending(true);

    }

    public void StopDefend()
    {
        if (isDefending)
        {
            isDefending = false;
            playerAnimator.SetDefending(false);
            stateMahine.ChangeState(PlayerState.Idle);
        }
    }

    public void TryGuard(Enemy attacker)
    {
        if(!isDefending) return;

        if(Time.time - defendStartTime <= justGuardWindow)
        {
            playerAnimator.TriggerGuardReact();
            attacker.TakeDamage(justGuardDamage);

            playerHealth.StartCoroutine(playerHealth.InvincibleRoutine());
        }

        playerAnimator.TriggerGuardReact();
        guardCount++;
        if (guardCount >= maxGuardCount)
        {
            GuardBreak();
        }
    }

    private void GuardBreak()
    {
        isDefending = false;

        playerAnimator.SetDefending(false);
        playerAnimator.TriggerGuardBreak();
        stateMahine.ChangeState(PlayerState.GuardBreak);
    }

}
