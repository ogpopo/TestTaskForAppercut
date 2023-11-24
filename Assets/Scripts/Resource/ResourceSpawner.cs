using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Scripts.Abstarct;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Resource
{
    public class ResourceSpawner : IDisposable
    {
        private List<Transform> _spawnPoints;
        private ResourcePicker _picker;
        private ResourceView _template;

        private bool needSpawn;

        [Inject] private List<ModelSpawnOptions> _modelOptions;

        public ResourceSpawner(ResourcePicker picker, List<Transform> spawnPoints, ResourceView template,
            List<ModelSpawnOptions> modelOptions)
        {
            _picker = picker;
            _spawnPoints = spawnPoints;
            _template = template;
            needSpawn = true;
            _modelOptions = modelOptions;

            Spawn();
        }

        private async void Spawn()
        {
            while (needSpawn)
            {
                var option = _modelOptions.ElementAt(Random.Range(0, _modelOptions.Count));

                var model = new Resource(option.Pickable, option.PriceFormater, 3);
                var view = GameObject.Instantiate(_template);
                view.gameObject.SetActive(false);
                view.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;
                view.Show(option.ShowUp, option.Color);
                var presenter = new ResourcePresenter(model, view);

                _picker.AddToPickable(model);

                await Task.Delay(1000);
            }
        }

        public void Dispose()
        {
            needSpawn = false;
        }
    }

    [Serializable]
    public class ModelSpawnOptions
    {
        public IPickable Pickable;
        public IShowUp ShowUp;
        public Color Color;
        public IPriceFormater PriceFormater;
    }
}