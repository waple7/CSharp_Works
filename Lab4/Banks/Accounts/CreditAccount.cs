using Banks.Banks;
using Banks.Exceptions;

namespace Banks.Accounts
{
    public class CreditAccount : MainAccount
    {
        public CreditAccount(decimal balanceCredit, decimal percent, CentralBank centralBank, MainAccount mainAccount)
            : base(mainAccount.Number, mainAccount.BalanceMain, mainAccount.Bank, mainAccount.Client, mainAccount.Verification, mainAccount.MainLimitTransferOther)
        {
            Percent = percent;
            CentralBank = centralBank;
            BalanceCredit = balanceCredit;
        }

        public decimal BalanceCredit { get; set; }
        public CentralBank CentralBank { get; set; }
        public decimal Percent { get; set; }
        public decimal CreditPayments()
        {
            if (CentralBank.CountDay < 30)
            {
                PayCredit(BalanceCredit);
                return BalanceMain;
            }
            else
            {
                BalanceCredit += 3000;
                PayCredit(BalanceCredit);
                BalanceCredit = 0;
                return BalanceMain;
            }
        }

        public void AddCredit(decimal moneyCredit)
        {
            BalanceCredit = moneyCredit;
            if (BalanceCredit > Bank.LimitCredit)
            {
                throw new InvalidCreditLimitException("Credit limit error");
            }

            BalanceMain += moneyCredit;
        }

        public void Update(decimal creditLimit)
        {
            Bank.LimitCredit = creditLimit;
        }
    }
}
