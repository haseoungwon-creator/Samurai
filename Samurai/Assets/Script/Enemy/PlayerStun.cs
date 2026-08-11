using UnityEngine;

public class PlayerStun : MonoBehaviour
{
    private bool isStunned;
    private float stunTimer;

    public bool IsStunned => isStunned;

    private void Update()
    {
        if (!isStunned)
            return;

        stunTimer -= Time.deltaTime;

        if (stunTimer <= 0f)
        {
            EndStun();
        }
    }

    public void Stun(float duration)
    {
        if (duration <= 0f)
            return;

        stunTimer = duration;
        isStunned = true;
    }

    private void EndStun()
    {
        stunTimer = 0f;
        isStunned = false;
    }

    public void CancelStun()
    {
        EndStun();
    }
}