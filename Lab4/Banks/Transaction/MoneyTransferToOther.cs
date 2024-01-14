using Banks.Accounts;
using Banks.Exceptions;

namespace Banks.MyTransaction
{
    public class MoneyTransferToOther : Transaction
    {
        public MoneyTransferToOther(MainAccount mainAccount, decimal sum, MainAccount otherMainAccount)
            : base(mainAccount, sum)
        {
            MainAccount = mainAccount;
            OtherMainAccount = otherMainAccount;
        }

        public MainAccount OtherMainAccount { get; set; }

        public override void Complete(decimal sum, MainAccount mainAccount)
        {
            if (sum > mainAccount.MainLimitTransferOther)
            {
                throw new InvalidVerificationAccountException("Account not verificate and error limit transfer");
            }

            MainAccount.BalanceMain -= sum;
            OtherMainAccount.BalanceMain += sum;
        }

        public override void Cancel(decimal sum)
        {
            if (IsCanceled == false)
            {
                throw new InvalidCancelException("Was cancel");
            }

            MainAccount.BalanceMain += sum;
            OtherMainAccount.BalanceMain -= sum;
            IsCanceled = false;
        }
    }
}