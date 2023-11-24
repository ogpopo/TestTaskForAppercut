using System;
using Scripts.Abstarct;
using UniRx;

namespace Wallet
{
    public class WalletPresenter: PresenterBase<WalletAccount, WalletView>, IDisposable
    {
        private readonly CompositeDisposable _disposable = new CompositeDisposable();
        public WalletPresenter(WalletAccount model, WalletView view) : base(model, view)
        {
            Model.GoldValue.Subscribe(View.OnGoldChanged).AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable.Clear();
        }
    }
}