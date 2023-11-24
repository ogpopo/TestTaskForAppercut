using Scripts.Abstarct;
using UnityEngine;

namespace Pickable
{
    public class PickableDefaultPattern : IPickable
    {
        public void PickUp(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }
    }
}