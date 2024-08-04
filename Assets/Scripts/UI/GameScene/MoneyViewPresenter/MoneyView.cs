using TMPro;
using UnityEngine;
using Zenject;

namespace UI.GameScene
{
    public class MoneyView:MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI moneyText;

        private IMoneyPresenter _moneyPresenter;
        
        [Inject]
        public void Construct(IMoneyPresenter moneyPresenter)
        {
            _moneyPresenter = moneyPresenter;

            _moneyPresenter.OnMoneyChanged += UpdateMoneyText;
        }

        private void UpdateMoneyText(string text)
        {
            moneyText.text = text;
        }
    }
}