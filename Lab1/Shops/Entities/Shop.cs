namespace Shops.Entities
{
    public class Shop
    {
        public Shop(string name, string adress, decimal moneyShop)
        {
            Name = name;
            Adress = adress;
            MoneyShop = moneyShop;
        }

        public string Name { get; private set; }
        public string Adress { get; private set;  }
        public decimal MoneyShop { get; private set; }
        public void EarnMoney(decimal moneyShop)
        {
            MoneyShop += moneyShop;
        }
    }
}
