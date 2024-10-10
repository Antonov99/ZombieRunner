using TMPro;
using UnityEngine;

namespace UI.GameScene
{
    public class MoneyView:MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI moneyText;

        public void UpdateMoneyText(string text)
        {
            moneyText.text = text;
        }
    }
}