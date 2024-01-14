using Banks.Accounts;

namespace Banks.MyTransaction
{
    public abstract class Transaction
    {
        public Transaction(MainAccount mainAccount, decimal sum)
        {
            MainAccount = mainAccount;
        }

        public MainAccount MainAccount { get; set; }

        public bool IsCanceled { get; set; } = true;

        public abstract void Complete(decimal sum, MainAccount mainAccount);

        public abstract void Cancel(decimal sum);
    }
}