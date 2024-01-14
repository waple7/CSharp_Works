namespace Banks.BuilderService
{
    public interface IClientBuilder
    {
        void SetName(string name);
        void SetSurname(string surname);
        void SetPassport(string passport);
        Client GetClient();
    }
}
