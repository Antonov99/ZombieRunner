using Audio;
using Money;
using UnityEngine;

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
            AudioManager.Instance.PlayCollectSound();
        }

        private void Activate()
        {
            gameObject.SetActive(true);
        }
    }
}