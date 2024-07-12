using JetBrains.Annotations;
using UnityEngine;

namespace Money
{
    [UsedImplicitly]
    public sealed class MoneyStorage: IMoneyStorage
    {
        public int Money { get; private set; }
        
        public MoneyStorage(int money)
        {
            Money = money;
        }
        
        public bool CanSpend(int range)
        {
            return Money >= range;
        }

        public void Spend(int range)
        {
            if (CanSpend(range)) Money -= range;
        }

        public void Add(int range)
        {
            Money += range;
            Debug.Log(Money);
        }
    }
}