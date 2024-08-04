using System;

namespace UI.GameScene
{
    public interface IMoneyPresenter
    {
        public event Action<string> OnMoneyChanged;
    }
}