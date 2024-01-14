namespace Banks.BuilderService
{
    public class ClientBuilder : IClientBuilder
    {
        private Client client = new Client();
        public void SetName(string name)
        {
                client.Name = name;
        }

        public void SetSurname(string surname)
        {
                client.Surname = surname;
        }

        public void SetPassport(string passport)
        {
                client.Passport = passport;
        }

        public Client GetClient()
        {
            Client client1 = client;
            client = new Client();
            return client1;
        }
    }
}
