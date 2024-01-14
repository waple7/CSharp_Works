using Banks.Accounts;

namespace Banks.Banks
{
    public interface IObservable
    {
        void RegisterObserver(DebitAccount o);
        void RemoveObserver(DebitAccount o);
        void NotifyObserversDebit(decimal percent);
        void RegisterObserver(DepositAccount o);
        void RemoveObserver(DepositAccount o);
        void NotifyObserversDeposit(decimal percent);
        void RegisterObserver(CreditAccount o);
        void RemoveObserver(CreditAccount o);
        void NotifyObserversCredit(decimal limit);
    }
}
