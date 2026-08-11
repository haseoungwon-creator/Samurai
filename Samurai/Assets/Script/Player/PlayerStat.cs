using System;
using System.Collections;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerStat : Singleton<PlayerStat>
{
    [SerializeField] int baseHP = 100;
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
    public int Defense => baseDefense + bonusDefense;
    public int Power
    {
        get
        {
            int power = Mathf.RoundToInt(bonusPower * powerMultiplier);

            PlayerHealth health = FindAnyObjectByType<PlayerHealth>();

            if (health == null)
                return power;

            float hp = health.HpPercent;

            if (hp <= 0.2f)
                power = Mathf.RoundToInt(power * 2.0f);      // 20% 이하

            else if (hp <= 0.4f)
                power = Mathf.RoundToInt(power * 1.5f);      // 40% 이하

            else if (hp <= 0.6f)
                power = Mathf.RoundToInt(power * 1.2f);      // 60% 이하

            return power;
        }
    }
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

    public void ResetStat()
    {
        if(powerRoutine != null) StopCoroutine(powerRoutine);
        if(speedRoutine != null) StopCoroutine(speedRoutine);

        bonusHp = 0;
        bonusPower = 0;
        bonusDefense = 0;
        bonusSpeed = 0;
        powerRoutine = null;
        speedRoutine = null;
        powerMultiplier = 1f;
        speedMultiplier = 1f;
    }
}
