using Scripts.Abstarct;

namespace Price
{
    public class DefaultPriceFormat : IPriceFormater
    {
        public DefaultPriceFormat(int price)
        {
            Price = price;
        }

        public int Price { get; }
    }
}