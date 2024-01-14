using Shops.Entities;

namespace Shops.Services
{
    public interface IMarketplaceservice
    {
        Buyer AddBuyer(string name, decimal money);
        Shop AddShop(string name, string address, decimal moneyShop);
        ProductStock SupplyShopNewProduct(Shop shop, string name, decimal price, int count);
        ProductStock FindProduct(string name, Shop shop);
        ProductStock SellProduct(Shop shop, Buyer buyer, string name, int count);
        ProductStock PriceChange(Shop shop, string name, decimal price);
        ProductStock SupplyShopOldProduct(Shop shop, string name, int count);
    }
}
