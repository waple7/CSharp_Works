using Banks.Accounts;
using Banks.Banks;
using Banks.BuilderService;
using Banks.MyTransaction;

namespace Banks
{
    public class Program
    {
        public static void Main()
        {
            var banks = new List<Bank>();
            var clientBuilder1 = new ClientBuilder();
            clientBuilder1.SetName("Radmir");
            clientBuilder1.SetSurname("Radmir");
            clientBuilder1.SetPassport("337576");

            Client client1 = clientBuilder1.GetClient();

            var clientBuilder2 = new ClientBuilder();
            clientBuilder2.SetName("Ivan");
            clientBuilder2.SetSurname("Ivanov");
            clientBuilder2.SetPassport("123456");

            Client client2 = clientBuilder1.GetClient();

            var bank = new Bank("Tinkoff", 1, 30000);
            var mainAccount2 = new MainAccount("1234123", 50000, bank, client2, true, 0);
            var mainAccount1 = new MainAccount("1234", 50000, bank, client1, true, 0);
            var centralBank = new CentralBank(banks, 0);
            var debitAccount1 = new DebitAccount(0, 0, centralBank, mainAccount1);
            var depositAccount1 = new DepositAccount(0, 0, centralBank, mainAccount1);
            var creditAccount1 = new CreditAccount(0, 0, centralBank, mainAccount1);
            var topDown = new TopDownTransaction(mainAccount1, 5000);
            var topUp = new TopUpTransaction(mainAccount1, 5000);
            var moneyTransferToOtherAccount = new MoneyTransferToOther(mainAccount1, 3000, mainAccount2);

            Console.WriteLine("=====================================================\n");

            Console.WriteLine("Положить 25000 рублей на Дебетовый счет: Выполнено");
            debitAccount1.DebitPaymentsAddMoney(25000);
            Console.WriteLine("Перевести время на 10 дней: Выполнено");
            centralBank.DayMachine(10);
            Console.WriteLine("Получаем выплату: " + debitAccount1.DebitPayments(0));
            Console.WriteLine("Положить 25000 рублей на Дебетовый счет: Выполнено");
            debitAccount1.DebitPaymentsAddMoney(25000);
            Console.WriteLine("Перевести время на 10 дней: Выполнено");
            centralBank.DayMachine(10);
            Console.WriteLine("Получаем выплату: " + debitAccount1.DebitPayments(10));

            Console.WriteLine("=====================================================\n");

            Console.WriteLine("Положить 25000 рублей на Депозит счет: Выполнено");
            depositAccount1.DepositPaymentsAddMoney(25000);
            Console.WriteLine("Перевести время на 30 дней: Выполнено");
            centralBank.DayMachine(30);
            Console.WriteLine("Получаем выплату: " + depositAccount1.DepositPayments(20));

            Console.WriteLine("=====================================================\n");

            Console.WriteLine("Взять 25000 в кредит: Выполнено");
            creditAccount1.AddCredit(25000);
            Console.WriteLine("Перевести время на 25 дней: Выполнено");
            centralBank.DayMachine(25);
            Console.WriteLine("Плати кредит за: " + creditAccount1.CreditPayments());

            Console.WriteLine("=====================================================\n");

            Console.WriteLine("Положить 5000 на основной счетй: Выполнено ");
            topUp.Complete(5000, mainAccount1);
            Console.WriteLine("Снять 5000 с основного счета: Выполнено ");
            topDown.Complete(1000, mainAccount1);
            Console.WriteLine("Перевести деньги с одного счета на другой: Выполнено ");
            moneyTransferToOtherAccount.Complete(3000, mainAccount1);

            Console.WriteLine("=====================================================\n");

            Console.WriteLine("Add Notifications and change");

            centralBank.RegisterObserver(creditAccount1);
            centralBank.RegisterObserver(depositAccount1);
            centralBank.RegisterObserver(debitAccount1);
            centralBank.ChangeProcentDeposit(3, depositAccount1);
            centralBank.ChangeProcentDebit(4, debitAccount1);
            centralBank.ChangeCreditLimit(50000, creditAccount1);
        }
    }
}