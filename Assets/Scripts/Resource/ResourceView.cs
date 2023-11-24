using System;
using Resourses.Player;
using Scripts.Abstarct;
using UnityEngine;

namespace Resource
{
    public class ResourceView : MonoBehaviour, IView
    {
        [SerializeField] private MeshRenderer _renderer;

        public event Action<GameObject> PickedUp;

        public void Show(IShowUp showUp, Color color)
        {
            showUp.Show(gameObject);
            _renderer.material.color = color;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerView>(out PlayerView playerView))
            {
                PickedUp?.Invoke(gameObject);
            }
        }
    }
}