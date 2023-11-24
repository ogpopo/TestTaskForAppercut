using DG.Tweening;
using Scripts.Abstarct;
using UnityEngine;

namespace Pickable
{
    public class PickableAnimatedPattern : IPickable
    {
        public void PickUp(GameObject gameObject)
        {
            gameObject.transform.DOScale(Vector3.zero, 0.5f).OnComplete(() => gameObject.SetActive(false));
        }
    }
}