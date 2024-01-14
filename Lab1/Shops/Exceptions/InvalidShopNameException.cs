namespace Shops.Exceptions
{
    public class InvalidShopNameException : Exception
    {
        public InvalidShopNameException(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}