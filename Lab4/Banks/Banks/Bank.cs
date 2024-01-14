using Banks.Accounts;

namespace Banks.Banks
{
    public class Bank
    {
        public Bank(string name, decimal procent, decimal limitCredit)
        {
            Name = name;
            Procent = procent;
            LimitCredit = limitCredit;
        }

        public string Name { get; set; }
        public decimal Procent { get; set; }
        public decimal LimitCredit { get; set; }

        public void VerificateAcc(MainAccount mainAccount)
        {
            if (mainAccount.Verification == false)
            {
                mainAccount.MainLimitTransferOther = 30000;
            }
        }
    }
}
