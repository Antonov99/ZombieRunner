using System;
using JetBrains.Annotations;
using Money;
using UnityEngine;
using Zenject;

namespace UI.GameScene
{
    [UsedImplicitly]
    public sealed class MoneyPresenter : IMoneyPresenter
    {
        public event Action<string> OnMoneyChanged;
        private IMoneyStorage _moneyStorage;

        [Inject]
        public void Construct(IMoneyStorage moneyStorage)
        {
            _moneyStorage = moneyStorage;

            _moneyStorage.OnMoneyChanged += UpdateMoney;
        }

        private void UpdateMoney(int money)
        {
            string text = "X " + money.ToString();
            OnMoneyChanged?.Invoke(text);
        }
    }
}