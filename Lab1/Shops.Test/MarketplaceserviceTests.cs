using Shops.Entities;
using Shops.Exceptions;
using Shops.Services;
using Xunit;

namespace Shops.Test;

public class MarketplaceserviceTests
{
    [Fact]
    public void SellPairProductcountCountFailure()
    {
        var service = new Marketplaceservice();
        Buyer buyer = service.AddBuyer("Radmir", 9999);
        Shop shop = service.AddShop("Product Store", "Vagos Street 37/01", 0);
        ProductStock product = service.SupplyShopNewProduct(shop, "Boots", 50, 20);
        ProductStock product1 = service.SupplyShopNewProduct(shop, "Shirt", 80, 10);

        ProductStock sellProduct = service.SellProduct(shop, buyer, "Boots", 5);
        sellProduct = service.SellProduct(shop, buyer, "Boots", 5);
        sellProduct = service.SellProduct(shop, buyer, "Boots", 10);

        ProductStock sellProduct2 = service.SellProduct(shop, buyer, "Shirt", 5);
        sellProduct2 = service.SellProduct(shop, buyer, "Shirt", 5);
        Assert.Throws<InvalidShopMoneyCountException>(() =>
        {
            service.SellProduct(shop, buyer, "Shirt", 1);
        });
    }

    [Fact]
    public void SellPairProductcountCountSuccess()
    {
        var service = new Marketplaceservice();
        Buyer buyer = service.AddBuyer("Radmir", 9999);
        Shop shop = service.AddShop("Product Store", "Vagos Street 37/01", 0);
        ProductStock product = service.SupplyShopNewProduct(shop, "Boots", 50, 20);
        ProductStock product1 = service.SupplyShopNewProduct(shop, "Shirt", 80, 10);

        ProductStock sellProduct = service.SellProduct(shop, buyer, "Boots", 5);
        sellProduct = service.SellProduct(shop, buyer, "Boots", 5);
        sellProduct = service.SellProduct(shop, buyer, "Boots", 10);

        ProductStock sellProduct2 = service.SellProduct(shop, buyer, "Shirt", 5);
        sellProduct2 = service.SellProduct(shop, buyer, "Shirt", 5);
    }

    [Fact]
    public void SellPairProductcountMoneyFailure()
    {
        var service = new Marketplaceservice();
        Buyer buyer = service.AddBuyer("Radmir", 1800);
        Shop shop = service.AddShop("Product Store", "Vagos Street 37/01", 0);
        ProductStock product = service.SupplyShopNewProduct(shop, "Boots", 50, 20);
        ProductStock product1 = service.SupplyShopNewProduct(shop, "Shirt", 80, 10);

        ProductStock sellProduct = service.SellProduct(shop, buyer, "Boots", 5);
        sellProduct = service.SellProduct(shop, buyer, "Boots", 5);
        sellProduct = service.SellProduct(shop, buyer, "Boots", 10);

        ProductStock sellProduct2 = service.SellProduct(shop, buyer, "Shirt", 5);
        sellProduct2 = service.SellProduct(shop, buyer, "Shirt", 5);
        Assert.Throws<InvalidShopMoneyCountException>(() =>
        {
            service.SellProduct(shop, buyer, "Shirt", 1);
        });
    }

    [Fact]
    public void SellPairProductcountMoneySuccess()
    {
        var service = new Marketplaceservice();
        Buyer buyer = service.AddBuyer("Radmir", 1800);
        Shop shop = service.AddShop("Product Store", "Vagos Street 37/01", 0);
        ProductStock product = service.SupplyShopNewProduct(shop, "Boots", 50, 20);
        ProductStock product1 = service.SupplyShopNewProduct(shop, "Shirt", 80, 10);

        ProductStock sellProduct = service.SellProduct(shop, buyer, "Boots", 5);
        sellProduct = service.SellProduct(shop, buyer, "Boots", 5);
        sellProduct = service.SellProduct(shop, buyer, "Boots", 10);

        ProductStock sellProduct2 = service.SellProduct(shop, buyer, "Shirt", 5);
        sellProduct2 = service.SellProduct(shop, buyer, "Shirt", 5);
    }

    [Fact]
    public void SupplyShopOldProductFailure()
    {
        var service = new Marketplaceservice();
        Buyer buyer = service.AddBuyer("Radmir", 5000);
        Shop shop = service.AddShop("Product Store", "Vagos Street 37/01", 0);

        ProductStock product = service.SupplyShopNewProduct(shop, "Boots", 50, 10);
        product = service.SupplyShopOldProduct(shop, "Boots", 5);
        product = service.SupplyShopOldProduct(shop, "Boots", 5);

        service.SellProduct(shop, buyer, "Boots", 20);
        Assert.Throws<InvalidShopMoneyCountException>(() =>
        {
            service.SellProduct(shop, buyer, "Boots", 1);
        });
    }

    [Fact]
    public void SupplyShopOldProductSuccess()
    {
        var service = new Marketplaceservice();
        Buyer buyer = service.AddBuyer("Radmir", 5000);
        Shop shop = service.AddShop("Product Store", "Vagos Street 37/01", 0);

        ProductStock product = service.SupplyShopNewProduct(shop, "Boots", 50, 10);
        product = service.SupplyShopOldProduct(shop, "Boots", 5);
        product = service.SupplyShopOldProduct(shop, "Boots", 5);

        service.SellProduct(shop, buyer, "Boots", 20);
    }

    [Fact]
    public void ProductNotListedFailure()
    {
        var service = new Marketplaceservice();
        Buyer buyer = service.AddBuyer("Radmir", 9999);
        Shop shop = service.AddShop("Product Store", "Vagos Street 37/01", 0);
        ProductStock product = service.SupplyShopNewProduct(shop, "Boots", 50, 10);
        Assert.Throws<InvalidProductNotListedException>(() =>
        {
            service.SellProduct(shop, buyer, "Milk", 1);
        });
    }

    [Fact]
    public void ProductNotListedSuccess()
    {
        var service = new Marketplaceservice();
        Buyer buyer = service.AddBuyer("Radmir", 9999);
        Shop shop = service.AddShop("Product Store", "Vagos Street 37/01", 0);
        ProductStock product = service.SupplyShopNewProduct(shop, "Boots", 50, 10);
    }

    [Fact]
    public void ChangePriceFailure()
    {
        var service = new Marketplaceservice();
        Buyer buyer = service.AddBuyer("Radmir", 5000);
        Shop shop = service.AddShop("Product Store", "Vagos Street 37/01", 0);
        ProductStock product = service.SupplyShopNewProduct(shop, "Boots", 5000, 1000);
        ProductStock price = service.PriceChange(shop, "Boots", 50);
        service.SellProduct(shop, buyer, "Boots", 100);
        Assert.Throws<InvalidShopMoneyCountException>(() =>
        {
            service.SellProduct(shop, buyer, "Boots", 1);
        });
    }

    [Fact]
    public void ChangePriceSuceess()
    {
        var service = new Marketplaceservice();
        Buyer buyer = service.AddBuyer("Radmir", 5000);
        Shop shop = service.AddShop("Product Store", "Vagos Street 37/01", 0);
        ProductStock product = service.SupplyShopNewProduct(shop, "Boots", 5000, 1000);
        ProductStock price = service.PriceChange(shop, "Boots", 50);
        service.SellProduct(shop, buyer, "Boots", 100);
    }

    [Fact]
    public void ShopSearchCheapProductCheck()
    {
        var shops = new List<Shop>();
        var service = new Marketplaceservice();
        Shop shop1 = service.AddShop("clothing store1", "Grove Street 25/01", 0);
        shops.Add(shop1);
        Shop shop2 = service.AddShop("clothing store2", "Ballas Street 25/02", 0);
        shops.Add(shop2);
        Shop shop3 = service.AddShop("clothing store3", "Ballas Street 25/03", 0);
        shops.Add(shop3);

        ProductStock product = service.SupplyShopNewProduct(shop1, "Boots", 50, 5);
        product = service.SupplyShopNewProduct(shop2, "Boots", 20, 5);
        product = service.SupplyShopNewProduct(shop3, "Boots", 30, 5);

        Assert.Equal(shop2, service.ShopSearchCheapProduct(shops, product, 1));
    }
}
