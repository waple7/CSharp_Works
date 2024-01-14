using Banks.Banks;

namespace Banks.Accounts
{
    public class DepositAccount : MainAccount
    {
        public DepositAccount(decimal balanceDeposit, decimal cashBack, CentralBank centralBank, MainAccount mainAccount)
            : base(mainAccount.Number, mainAccount.BalanceMain, mainAccount.Bank, mainAccount.Client, mainAccount.Verification, mainAccount.MainLimitTransferOther)
        {
            CashBack = cashBack;
            CentralBank = centralBank;
            BalanceDeposit = balanceDeposit;
        }

        public decimal BalanceDeposit { get; set; }
        public CentralBank CentralBank { get; set; }
        public decimal CashBack { get; set; }
        public decimal DepositPayments(int beforeDay)
        {
                decimal dayPercent = Bank.Procent / 365;
                beforeDay = CentralBank.CountDay - beforeDay;
                for (int i = 0; i < beforeDay; i++)
                {
                    CashBack += BalanceDeposit * dayPercent;
                }

                if (CentralBank.CountDay >= 30)
                {
                    GetBalance(CashBack);
                    return BalanceMain;
                }
                else
                {
                   return 0;
                }
        }

        public void DepositPaymentsAddMoney(decimal moneyForDeposit)
        {
            BalanceDeposit += moneyForDeposit;
            BalanceMain -= moneyForDeposit;
        }

        public void Update(decimal percent)
        {
            Bank.Procent = percent;
        }
    }
}
