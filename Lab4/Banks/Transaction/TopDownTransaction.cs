using Banks.Accounts;
using Banks.Exceptions;

namespace Banks.MyTransaction
{
    public class TopDownTransaction : Transaction
    {
        public TopDownTransaction(MainAccount mainAccount, decimal sum)
            : base(mainAccount, sum)
        {
        }

        public override void Complete(decimal sum, MainAccount mainAccount)
        {
            if (sum > mainAccount.MainLimitTransferOther)
            {
                throw new InvalidVerificationAccountException("Account not verificate and error limit transfer");
            }

            MainAccount.BalanceMain -= sum;
        }

        public override void Cancel(decimal sum)
        {
            if (IsCanceled != true)
            {
                throw new InvalidCancelException("Was cancel");
            }

            MainAccount.BalanceMain += sum;
            IsCanceled = false;
        }
    }
}