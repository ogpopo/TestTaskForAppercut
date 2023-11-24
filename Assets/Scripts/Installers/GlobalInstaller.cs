using Zenject;

namespace Resourses.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var input = new PlayerInput();
            Container.Bind<PlayerInput>().FromInstance(input).AsSingle().NonLazy();
        }
    }
}