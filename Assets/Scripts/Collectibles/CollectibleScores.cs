using Money;
using UnityEngine;
using Zenject;

namespace Collectibles
{
    public class CollectibleScores:MonoBehaviour, ICollectible
    {
        [SerializeField]
        private int amount;

        public void Collect(IMoneyStorage moneyStorage)
        {
            moneyStorage.Add(amount);
            gameObject.SetActive(false);
            Invoke(nameof(Activate),2);
        }

        private void Activate()
        {
            gameObject.SetActive(true);
        }
    }
}