using UnityEngine;
using Wallet;
using Zenject;

namespace Resourses.Installers
{
    public class WalletInstaller : MonoInstaller
    {
        [SerializeField] private WalletView _walletView;

        public override void InstallBindings()
        {
            var model = new WalletAccount();
            Container.Bind<WalletAccount>().FromInstance(model).AsSingle().NonLazy();
            var presenter = new WalletPresenter(model, _walletView);

            model.ChangeGold(0);
        }
    }
}