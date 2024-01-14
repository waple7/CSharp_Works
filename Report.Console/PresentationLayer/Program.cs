using ReportSystem.Businesslayer;
using ReportSystem.DataAccesslayer;
using ReportSystem.Entities;

namespace Report.Consolee.PresentationLayer
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Нажмите 1, чтобы войти под именем Оператора: ");
            Console.WriteLine("Нажмите 2, чтобы войти под именем Алминистратора ");
            int k = Convert.ToInt32(Console.ReadLine()); ;
            switch (k)
            {
                case 1:
                    var serviceRecord = new RecordService();

                    var typeMessage = new TypeMessage("sms");

                    var message1 = new Message(typeMessage, 1, "tariff problem");

                    var messageAllowed = new List<Message>();
                    var typeMessageList = new List<TypeMessage>();
                    var workers = new List<Worker>();

                    var messageList = new List<Message>();

                    Console.WriteLine("Создание нового работника: ");

                    var worker = new Worker("John", "Operator", messageAllowed, 123654);
                    var serviceMessage = new SystemMessageService(typeMessage, 1, "tariff prolem", typeMessageList, messageList);
                    var serviceWorker = new WorkerService("John", "Operator", messageAllowed, 123654, workers);

                    serviceWorker.LogIn(worker, "Operator", 123654);

                    Console.WriteLine("LogIn аутентификация: ");

                    serviceMessage.MessageWasChecked(message1);

                    Console.WriteLine("просмотр и обработка сообщения:");

                    Console.WriteLine("Создание нового типа сообщения:");

                    serviceMessage.AddNewType(typeMessage);

                    Console.WriteLine("Передаем данные в отчет");
                    serviceRecord.FinishJobGiveToRecord(worker, 1);
                    break;
                case 2:
                    var serviceRecord1 = new RecordService();
                    var messageList1 = new List<Message>();
                    var messageAllowed1 = new List<Message>();
                    var workers1 = new List<Worker>();
                    var worker1 = new Worker("John", "Operator", messageAllowed1, 123654);
                    var record = new Record(messageList1, worker1, 1);
                    var records = new List<Record>();
                    var serviceWorker1 = new WorkerService("John", "Operator", messageAllowed1, 123654, workers1);

                    Console.WriteLine("Создаем Админа");

                    var admin = new Worker("Luffi", "Admin", messageAllowed1, 789987);

                    Console.WriteLine("LogIn аутентификация: ");

                    serviceWorker1.LogIn(worker1, "Admin", 789987);
                    var workerService = new WorkerService("Luffi", "Admin", messageAllowed1, 789987, workers1);
                    var repositoryRecord = new RepositoryRecord(messageList1, worker1, 1, records);

                    Console.WriteLine("Получаем отчёт:");

                    serviceRecord1.CreateMasterRecord(worker1, record, 1, workerService, repositoryRecord);
                    break;

            }
        }
    }
}