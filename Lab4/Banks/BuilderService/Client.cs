namespace Banks.BuilderService
{
    public class Client
    {
        public Client(string? name, string? surname, string? passport)
        {
            Name = name;
            Surname = surname;
            Passport = passport;
        }

        public Client() { }
        public string? Name { get; internal set; }
        public string? Surname { get; internal set; }
        public string? Passport { get; internal set; }
    }
}
