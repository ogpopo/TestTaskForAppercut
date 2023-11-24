using System;
using Cinemachine;
using Resourses.Player;
using Scripts.Abstarct;
using UnityEngine;
using Zenject;

namespace Resourses.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private CinemachineVirtualCamera _camera;

        [SerializeField] private PlayerView _playerViewTemplate;

        [SerializeField] private Transform _spawnPoint;
        [SerializeField] [Range(0, 15)] private float _playerSpeed;

        [Inject] private PlayerInput _input;

        // private CubeView _redCubeView;
        // private CubePresenter _redCubePresenter;

        private PlayerInputBroadcaster _playerInputBroadcaster;

        public override void InstallBindings()
        {
            var position = _spawnPoint.position;

            PlayerView _playerView = Container.InstantiatePrefabForComponent<PlayerView>(_playerViewTemplate,
                position,
                Quaternion.identity,
                null);

            var playerViewTransform = _playerView.transform;
            _camera.Follow = playerViewTransform;
            _camera.LookAt = playerViewTransform;

            var spawnContext = new PLayerSpawnContext(position, _playerSpeed);

            var model = new Player.Player(spawnContext);

            Container.Bind<IMovable>().To<Player.Player>().FromInstance(model);

            var playerPresenter = new PlayerPresenter(model, _playerView);
            var playerInputBroadcaster = new PlayerInputBroadcaster(_input.Player.Move, model);

            Container.Bind(typeof(IDisposable)).To<PlayerPresenter>().FromInstance(playerPresenter);
            Container.BindInterfacesAndSelfTo<PlayerInputBroadcaster>().FromInstance(playerInputBroadcaster).AsSingle();
        }
    }
}