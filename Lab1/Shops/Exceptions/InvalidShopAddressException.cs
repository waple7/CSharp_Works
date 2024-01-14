namespace Shops.Exceptions
{
    public class InvalidShopAddressException : Exception
    {
        public InvalidShopAddressException(string address)
        {
            Address = address;
        }

        public string Address { get; }
    }
}