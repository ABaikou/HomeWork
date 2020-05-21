using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace BillingCompanyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            BillingCompany company = new BillingCompany("A1");
            Client bob = new Client("Bob", company, 101);
            Client tom = new Client("Tom", company, 102);
            Client anna = new Client("Anna", company, 103);
            Client elza = new Client("Elza", company, 104);
            Client fill = new Client("Fill", company, 105);
            Client.Notify += DisplayMessage;
            
            DoCalls(company);

            tom.ChangeTariff(Tariffs.Standart);
            tom.ChangeTariff(Tariffs.Premium);
            tom.PayTheBill(3000);
            tom.SaveReportToFile();
            bob.SaveReportToFile(bob.GenerateReport("tom"));
            anna.OutputReportToConsole(anna.GenerateReport(50));
            elza.OutputReportToConsole();
            fill.OutputReportToConsole(fill.GenerateReport("elza"));
        }

        private static void DoCalls(BillingCompany company)
        {
            Random random = new Random();
            for (int i = 0; i < 300; i++)
            {
                var clients = company.GetClientList();
                var client = clients[random.Next(clients.Count)];
                var number = random.Next(101, 106);
                if (client.Phone.Number != number)
                {
                    client.Call(number, (ushort)random.Next(1,30));
                }
            }
        }

        private static void DisplayMessage(object obj, string message)
        {
            
            Console.WriteLine($"{(obj as Client).Name}: {message}");
        }
    }
}
