using System;
using Scripts.Abstarct;
using UniRx;

namespace Resourses.Player
{
    public class PlayerPresenter : PresenterBase<Player, PlayerView>, IDisposable
    {
        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public PlayerPresenter(Player model, PlayerView view) : base(model, view)
        {
            Model.Position.Subscribe(view.OnMove).AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable.Clear();
        }
    }
}