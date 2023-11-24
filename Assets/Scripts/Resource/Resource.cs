using System;
using Scripts.Abstarct;
using UnityEngine;

namespace Resource
{
    public class Resource : IModel
    {
        private IPickable _pickable;

        public event Action<Resource> PickedUp;

        public Resource(IPickable pickable, IPriceFormater price, int value)
        {
            _pickable = pickable;
            PriceFormater = price;
            Value = value;
        }

        public IPriceFormater PriceFormater { get; }

        public int Value { get; private set; }

        public void PickUp(GameObject res)
        {
            _pickable.PickUp(res);
            PickedUp?.Invoke(this);
        }
    }
}