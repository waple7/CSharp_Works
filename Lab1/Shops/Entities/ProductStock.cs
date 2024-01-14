namespace Shops.Entities
{
    public class ProductStock
    {
        public ProductStock(string name, decimal price, int count, Shop shop)
        {
            Name = name;
            Price = price;
            Count = count;
            Shop = shop;
        }

        public Shop Shop { get; private set;  }
        public string Name { get; private set;  }
        public decimal Price { get; private set; }
        public int Count { get; private set; }
        public void CountProductSell(int count)
        {
            Count -= count;
        }

        public void ChangePrice(decimal price)
        {
            Price = price;
        }

        public void CountProductAdd(int count)
        {
            Count += count;
        }
    }
}
