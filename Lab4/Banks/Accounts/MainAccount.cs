using Banks.Banks;
using Banks.BuilderService;

namespace Banks.Accounts
{
    public class MainAccount
    {
        public MainAccount(string number, decimal balanceMain, Bank bank, Client client, bool verification, decimal mainLimitTransferOther)
        {
            Number = number;
            BalanceMain = balanceMain;
            Client = client;
            Bank = bank;
            Verification = verification;
            MainLimitTransferOther = mainLimitTransferOther;
        }

        public decimal MainLimitTransferOther { get; set; }
        public bool Verification { get; set; }
        public string Number { get; }
        public Bank Bank { get; }
        public decimal BalanceMain { get; set; }
        public Client Client { get; }
        public decimal GetBalance(decimal cashBack)
        {
            BalanceMain += cashBack;
            return BalanceMain;
        }

        public decimal PayCredit(decimal credit)
        {
            BalanceMain -= credit;
            return BalanceMain;
        }

        public void VerificationAccount(Client client)
        {
            if (client.Passport == null)
            {
                Verification = false;
            }
            else
            {
                Verification = true;
            }
        }
    }
}
