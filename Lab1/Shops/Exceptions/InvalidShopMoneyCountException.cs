namespace Shops.Exceptions
{
    public class InvalidShopMoneyCountException : Exception
    {
        public InvalidShopMoneyCountException(int count)
        {
            Count = count;
        }

        public int Count { get; }
    }
}