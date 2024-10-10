using JetBrains.Annotations;
using Money;
using UnityEngine;
using Zenject;

namespace UI.GameScene
{
    [UsedImplicitly]
    public sealed class MoneyPresenter : IMoneyPresenter
    {
        private IMoneyStorage _moneyStorage;
        private MoneyView _moneyView;

        [Inject]
        public void Construct(IMoneyStorage moneyStorage, MoneyView view)
        {
            _moneyStorage = moneyStorage;
            _moneyView = view;

            _moneyStorage.OnMoneyChanged += UpdateMoney;
        }

        private void UpdateMoney(int money)
        {
            string text = "X " + money;
            _moneyView.UpdateMoneyText(text);
        }
    }
}