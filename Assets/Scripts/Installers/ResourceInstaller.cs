using System;
using System.Collections.Generic;
using Pickable;
using Price;
using Resource;
using ShowUpPattern;
using UnityEngine;
using Zenject;

namespace Resourses.Installers
{
    public class ResourceInstaller : MonoInstaller
    {
        [SerializeField] private List<Transform> _spawnPoints;

        [SerializeField] private ResourceView _resourceViewTemplate;

        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioClip _pickClip;

        [Inject] private WalletAccount _wallet;

        public override void InstallBindings()
        {
            var modelOptions = new List<ModelSpawnOptions>()
            {
                new ModelSpawnOptions()
                {
                    Pickable = new PickableSoundPattern(_source, _pickClip),
                    ShowUp = new DefauldShowUp(),
                    Color = Color.black,
                    PriceFormater = new DefaultPriceFormat(2)
                },

                new ModelSpawnOptions()
                {
                    Pickable = new PickableDefaultPattern(),
                    ShowUp = new DefauldShowUp(),
                    Color = Color.blue,
                    PriceFormater = new DefaultPriceFormat(3)
                },
                new ModelSpawnOptions()
                {
                    Pickable = new PickableAnimatedPattern(),
                    ShowUp = new AnimatedShowUp(),
                    Color = Color.green,
                    PriceFormater = new DependentpriceFormat()
                }
            };

            var resourcePicker = new ResourcePicker(_wallet);
            var resourceSpawner =
                new ResourceSpawner(resourcePicker, _spawnPoints, _resourceViewTemplate, modelOptions);
            Container.Bind(typeof(IDisposable)).To<ResourceSpawner>().FromInstance(resourceSpawner);
        }
    }
}