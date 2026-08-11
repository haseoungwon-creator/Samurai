using UnityEngine;

public class GoldManager : Singleton<GoldManager>
{
    [SerializeField] int startGold = 0;

    int gold;

    public int Gold => gold;

    protected override void Awake()
    {
        base.Awake();

        gold = startGold;
    }

    public void AddGold(int amount)
    {
        if (amount <= 0) return;

        gold += amount;
    }

    public bool UseGold(int amount)
    {
        if(amount <= 0) return false;

        if(gold< amount) return false;

        gold -= amount;

        return true;
    }

    public void ResetGold()
    {
        gold = startGold;
    }
}
