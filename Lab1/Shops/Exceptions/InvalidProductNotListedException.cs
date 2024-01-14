namespace Shops.Exceptions
{
    public class InvalidProductNotListedException : Exception
    {
        public InvalidProductNotListedException(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
