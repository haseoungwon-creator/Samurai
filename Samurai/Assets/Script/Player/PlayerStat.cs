using System;
using System.Collections;
using UnityEngine;

public class PlayerStat : Singleton<PlayerStat>
{
    [SerializeField] int baseHP = 100;
    [SerializeField] int basePower = 10;
    [SerializeField] int baseDefense = 0;
    [SerializeField] int baseSpeed = 4;

    int bonusHp;
    int bonusPower;
    int bonusDefense;
    float bonusSpeed;

    float powerMultiplier = 1f;
    float speedMultiplier = 1f;

    Coroutine powerRoutine;
    Coroutine speedRoutine;

    public int MaxHp => baseHP + bonusHp;
    public int Power => bonusPower;
    public int Defense => baseDefense + bonusDefense;
    public float MoveSpeed => (baseSpeed + bonusSpeed) * speedMultiplier;

    public void AddStat(Ability ability, int value)
    {
        switch (ability)
        {
            case Ability.Hp: bonusHp += value; break;

            case Ability.Power: bonusPower += value; break;

            case Ability.Defense: bonusDefense += value; break;

            case Ability.Speed: bonusSpeed += value; break;
        }
    }

    public void RemoveStat(Ability ability, int value)
    {
        switch(ability)
        {
            case Ability.Hp:bonusHp -= value; break;
                
            case Ability.Power:bonusPower -= value; break;
                
            case Ability.Defense:bonusDefense -= value; break;
                
            case Ability.Speed:bonusSpeed -= value; break;
        }
    }

    public void StartPulsDamage(float duration)
    {
        if(powerRoutine != null)
            StopCoroutine(powerRoutine);

        powerRoutine = StartCoroutine(PlusDamageRoutine(duration));
    }

    IEnumerator PlusDamageRoutine(float duration)
    {
        powerMultiplier = 2f;

        yield return CoroutineManager.Wait(duration);

        powerMultiplier = 1f;
        powerRoutine = null;
    }

    public void StartPulsSpeed(float duration)
    {
        if (powerRoutine != null)
            StopCoroutine(powerRoutine);

       speedRoutine = StartCoroutine(PlusSpeedRoutine(duration));
    }

    IEnumerator PlusSpeedRoutine(float duration)
    {
        speedMultiplier = 2f;

        yield return CoroutineManager.Wait(duration);

        speedMultiplier = 1f;
        speedRoutine = null;
    }
}
