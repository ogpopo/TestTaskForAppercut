using System.Collections.Generic;
using ModestTree;
using Price;
using Scripts.Abstarct;

namespace Resource
{
    public class ResourcePicker
    {
        private WalletAccount _wallet;

        private Stack<int> _pickStory = new Stack<int>();

        public ResourcePicker(WalletAccount wallet)
        {
            _wallet = wallet;
        }

        public void AddToPickable(Resource resource)
        {
            resource.PickedUp += Pick;
        }

        private void Pick(Resource resource)
        {
            var price = 0;

            if (resource.PriceFormater is DependentpriceFormat)
            {
                if (_pickStory.IsEmpty())
                    return;

                price = _pickStory.Peek();
                _wallet.ChangeGold(price);
            }
            else
            {
                price = resource.PriceFormater.Price;
                _wallet.ChangeGold(price);
            }

            resource.PickedUp -= Pick;
            _pickStory.Push(price);
        }
    }
}