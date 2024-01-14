using Banks.Accounts;

namespace Banks.Banks
{
    public class CentralBank : IObservable
    {
        private static CentralBank? instance;
        private List<Bank> _bankList;

        private List<DebitAccount> observersDebitAccount;
        private List<DepositAccount> observersDepositAccount;
        private List<CreditAccount> observersCreditAccount;
        public CentralBank(List<Bank> banks, int countDay)
        {
            CountDay = countDay;
            observersDebitAccount = new List<DebitAccount>();
            observersDepositAccount = new List<DepositAccount>();
            observersCreditAccount = new List<CreditAccount>();
            _bankList = banks;
        }

        public int CountDay { get; set; }
        public IReadOnlyList<Bank> Banks => _bankList;

        public CentralBank GetInstance()
        {
            if (instance == null)
            {
                instance = new CentralBank(_bankList, CountDay);
            }

            return instance;
        }

        public void RegisterBank(Bank nameBank)
        { _bankList.Add(nameBank); }
        public void DayMachine(int day)
        {
            CountDay += day;
        }

        public void ChangeProcentDebit(decimal procent, DebitAccount debitAccount)
        {
            debitAccount.Bank.Procent = procent;
            NotifyObserversDebit(procent);
        }

        public void ChangeProcentDeposit(decimal procent, DepositAccount depositAccount)
        {
            depositAccount.Bank.Procent = procent;
            NotifyObserversDeposit(procent);
        }

        public void ChangeCreditLimit(decimal limit, CreditAccount depositAccount)
        {
            depositAccount.Bank.LimitCredit = limit;
            NotifyObserversCredit(limit);
        }

        public void RegisterObserver(DebitAccount o)
        {
            observersDebitAccount.Add(o);
        }

        public void RemoveObserver(DebitAccount o)
        {
            if (observersDebitAccount != null)
            {
                observersDebitAccount.Remove(o);
            }
        }

        public void NotifyObserversDebit(decimal percent)
        {
            if (observersDebitAccount != null)
            {
                foreach (DebitAccount o in observersDebitAccount)
                {
                    o.Update(percent);
                }
            }
        }

        public void RegisterObserver(DepositAccount o)
        {
            observersDepositAccount.Add(o);
        }

        public void RemoveObserver(DepositAccount o)
        {
            if (observersDepositAccount != null)
            {
                observersDepositAccount.Remove(o);
            }
        }

        public void NotifyObserversDeposit(decimal percent)
        {
            if (observersDepositAccount != null)
            {
                foreach (DepositAccount o in observersDepositAccount)
                {
                    o.Update(percent);
                }
            }
        }

        public void RegisterObserver(CreditAccount o)
        {
            observersCreditAccount.Add(o);
        }

        public void RemoveObserver(CreditAccount o)
        {
            if (observersCreditAccount != null)
            {
                observersCreditAccount.Remove(o);
            }
        }

        public void NotifyObserversCredit(decimal limit)
        {
            if (observersCreditAccount != null)
            {
                foreach (CreditAccount o in observersCreditAccount)
                {
                    o.Update(limit);
                }
            }
        }
    }
}
