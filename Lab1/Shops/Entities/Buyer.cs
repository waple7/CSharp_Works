namespace Shops.Entities
{
    public class Buyer
    {
        public Buyer(string name, decimal money)
        {
            Name = name;
            Money = money;
        }

        public string Name { get; private set; }
        public decimal Money { get; private set; }
        public void SpendMoney(decimal money)
        {
            Money -= money;
        }
    }
}
