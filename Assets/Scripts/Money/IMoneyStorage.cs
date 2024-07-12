namespace Money
{
    public interface IMoneyStorage
    {
        int Money { get; }
        bool CanSpend(int range);
        void Spend(int range);
        void Add(int range);
    }
}