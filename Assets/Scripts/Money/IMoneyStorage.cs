using System;

namespace Money
{
    public interface IMoneyStorage
    {
        public event Action<int> OnMoneyChanged;
        int Money { get; }
        bool CanSpend(int range);
        void Spend(int range);
        void Add(int range);
    }
}