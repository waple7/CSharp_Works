using Banks.Banks;

namespace Banks.Accounts
{
    public class DebitAccount : MainAccount
    {
        public DebitAccount(decimal balanceDebit, decimal cashBack, CentralBank centralBank, MainAccount mainAccount)
            : base(mainAccount.Number, mainAccount.BalanceMain, mainAccount.Bank, mainAccount.Client, mainAccount.Verification, mainAccount.MainLimitTransferOther)
        {
            CashBack = cashBack;
            CentralBank = centralBank;
            BalanceDebit = balanceDebit;
        }

        public decimal BalanceDebit { get; set; }
        public CentralBank CentralBank { get; set; }
        public decimal CashBack { get; set; }
        public decimal DebitPayments(int beforeDay)
        {
                decimal dayPercent = Bank.Procent / 365;
                beforeDay = CentralBank.CountDay - beforeDay;
                for (int i = 0; i < beforeDay; i++)
                {
                    CashBack += BalanceDebit * dayPercent;
                }

                GetBalance(CashBack);
                BalanceDebit = 0;
                CashBack = 0;
                return BalanceMain;
        }

        public void DebitPaymentsAddMoney(decimal moneyForDebit)
        {
            BalanceDebit += moneyForDebit;
            BalanceMain -= moneyForDebit;
        }

        public void Update(decimal percent)
        {
            Bank.Procent = percent;
        }
    }
}
