using Money;

namespace Collectibles
{
    public interface ICollectible
    {
        public void Collect(IMoneyStorage moneyStorage);
    }
}