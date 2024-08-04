using System;
using JetBrains.Annotations;

namespace Money
{
    [UsedImplicitly]
    public sealed class MoneyStorage : IMoneyStorage
    {
        public event Action<int> OnMoneyChanged;

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
            if (CanSpend(range))
            {
                Money -= range;
                OnMoneyChanged?.Invoke(Money);
            }
        }

        public void Add(int range)
        {
            Money += range;
            OnMoneyChanged?.Invoke(Money);
        }
    }
}