using Shops.Entities;
using Shops.Exceptions;

namespace Shops.Services
{
    public class Marketplaceservice : IMarketplaceservice
    {
        private List<ProductStock> productList = new List<ProductStock>();
        public Buyer AddBuyer(string name, decimal money)
        {
            var buyer = new Buyer(name, money);
            return buyer;
        }

        public Shop AddShop(string name, string address, decimal moneyShop)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidShopNameException(name);
            }

            if (string.IsNullOrEmpty(address))
            {
                throw new InvalidShopAddressException(address);
            }

            if (name.Length == 0)
            {
                throw new InvalidShopNameException(name);
            }

            if (address.Length == 0)
            {
                throw new InvalidShopAddressException(address);
            }

            var shop = new Shop(name, address, moneyShop);

            return shop;
        }

        public ProductStock SupplyShopNewProduct(Shop shop, string name, decimal price, int count)
        {
            var product = new ProductStock(name, price, count, shop);
            productList.Add(product);
            return product;
        }

        public ProductStock SupplyShopOldProduct(Shop shop, string name, int count)
        {
            ProductStock producstock = FindProduct(name, shop);
            producstock.CountProductAdd(count);
            return producstock;
        }

        public ProductStock FindProduct(string name, Shop shop)
        {
            ProductStock? productToFind = productList
                .Where(product => product.Name == name && product.Shop == shop)
                .FirstOrDefault();

            if (productToFind is not null)
            {
                return productToFind;
            }
            else
            {
                throw new InvalidProductNotListedException(name);
            }
        }

        public ProductStock SellProduct(Shop shop, Buyer buyer, string name, int count)
        {
            {
                ProductStock productstock = FindProduct(name, shop);
                if ((productstock.Count >= count) && (buyer.Money >= (count * productstock.Price)))
                {
                    buyer.SpendMoney(count * productstock.Price);
                    shop.EarnMoney(count * productstock.Price);
                    productstock.CountProductSell(count);
                }
                else
                {
                    throw new InvalidShopMoneyCountException(count);
                }

                return productstock;
            }
        }

        public ProductStock PriceChange(Shop shop, string name, decimal price)
        {
            ProductStock productstock = FindProduct(name, shop);
            productstock.ChangePrice(price);
            return productstock;
        }

        public Shop? ShopSearchCheapProduct(List<Shop> shops, ProductStock productstock, int count)
        {
            decimal priceCheap = decimal.MinValue;
            Shop? shopPriceCheap = null;

            foreach (Shop shop in shops)
            {
                if ((FindProduct(productstock.Name, shop).Count >= count) && priceCheap < 0)
                {
                    priceCheap = FindProduct(productstock.Name, shop).Price;
                    shopPriceCheap = shop;
                }

                if (FindProduct(productstock.Name, shop).Price < priceCheap &&
                    (FindProduct(productstock.Name, shop).Count >= count))
                {
                    priceCheap = FindProduct(productstock.Name, shop).Price;
                    shopPriceCheap = shop;
                }
            }

            return shopPriceCheap;
        }
    }
}
