using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace BillingCompanyProject
{
    class Client
    {
        public delegate void Message(object sender, string message);
        public static event Message Notify;

        private BillingCompany company;
        private List<Call> calls;
        private DateTime tariffChangeDate;
        private DateTime balancePayDate;



        public Terminal Phone { get; private set; }
        public string Name { get; private set; }
        public Tariffs TariffPlan { get; private set; }
        public decimal Balance { get; private set; }


        public Client(string name, BillingCompany company, int number)
        {
            Name = name;
            Phone = new Terminal(number);
            company.AddClient(this);
            this.company = company;
            TariffPlan = Tariffs.Standart;
            Balance = 0;
            calls = new List<Call>();
            tariffChangeDate = DateTime.Now;
            balancePayDate = DateTime.Now;
        }

        public void TurnOnOffTerminal()
        {
            if (Phone.IsEnable)
            {
                Phone.IsEnable = false;
            }
            else
            {
                Phone.IsEnable = true;
            }
        }

        public void Call(int number, ushort durationOfCall)
        {
            var client = company.GetClientList().FirstOrDefault(user => user.Phone.Number == number);
            if (number == Phone.Number || client == null)
            {
                Notify?.Invoke(this, "Wrong Number");
                return;
            }
            if (DateTime.Now.Subtract(balancePayDate).Days > 30 && Balance < 0)
            {
                Notify?.Invoke(this, $"Your account is temporarily blocked. Pay off debt: {Balance}");
                return;
            }
            if (client.Phone.IsEnable == false)
            {
                Notify?.Invoke(this, "The number you have dialed is temporarily unavailable");
                return;
            }
            if (client.Phone.IsUse == true)
            {
                Notify?.Invoke(this, "The number you have dialed is busy");
                return;
            }

            Phone.IsUse = true;
            client.Phone.IsUse = true;
            decimal costPerCall = durationOfCall * (int)TariffPlan;
            Balance -= costPerCall;
            
            DateTime date = DateTime.Now;
            //Thread.Sleep(10 * durationOfCall);
            Call call = new Call(number, client.Name, durationOfCall, costPerCall, date);
            calls.Add(call);
            Phone.IsUse = false;
            client.Phone.IsUse = false;

        }

        public void ChangeTariff(Tariffs tariff)
        {
            if (TariffPlan == tariff)
            {
                Notify?.Invoke(this, $"This is your current tariff: {tariff}");
                return;
            }
            DateTime date = DateTime.Now;
            if (date.Subtract(tariffChangeDate).Days > 30)
            {
                TariffPlan = tariff;
                tariffChangeDate = date;
                Notify?.Invoke(this, $"Your tariff changed: {tariff}");
            }
            else
            {
                Notify?.Invoke(this, $"You can change your tariff plan in {30 - date.Subtract(tariffChangeDate).Days} days");
            }
            
            
        }

        public void PayTheBill(decimal sum)
        {
            Balance += sum;
            Notify?.Invoke(this, $"The account recived {sum}. Your balance is: {Balance}");
            if (Balance >= 0 && DateTime.Now.Subtract(balancePayDate).Days > 30)
            {
                balancePayDate = balancePayDate.AddDays(30);
                Notify?.Invoke(this, $"You must replenish the balance no later than {balancePayDate:d}");
            }
        }

        public List<Call> GenerateReport() 
        {
            return calls;
        }
        public List<Call> GenerateReport(DateTime date)
        {
            var selectedcalls = calls.Where(c => date.Subtract(c.Date).Days == 0).ToList();
            return selectedcalls;
        }
        public List<Call> GenerateReport(decimal minCost)
        {
            var selectedcalls = calls.Where(c => c.CostPerCall > minCost).OrderBy(s => s.CostPerCall).ToList();
            return selectedcalls;
        }
        public List<Call> GenerateReport(string clientName)
        {
            var selectedcalls = calls.Where(n => clientName.ToUpper() == n.NameToCall.ToUpper()).ToList();
            return selectedcalls;
        }

        public void SaveReportToFile()
        {
            string path = "Reports";
            try
            {
                Directory.CreateDirectory(path);
                using (StreamWriter sw = new StreamWriter($"{path}\\{Name}.txt", false, Encoding.UTF8))
                {                    
                    sw.WriteLine($"{DateTime.Now}\n{Name.ToUpper()} call report:\n");
                    foreach (var call in calls)
                    {
                        sw.WriteLine($"Date:{call.Date}\t Number:{call.NumberToCall}\t Name: {call.NameToCall}\t  Duration:{call.Duration}\t Cost:{call.CostPerCall}\t");
                    }
                    
                }               
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void SaveReportToFile(List<Call> calls)
        {
            string path = "Reports";
            try
            {
                Directory.CreateDirectory(path);
                using (StreamWriter sw = new StreamWriter($"{path}\\{Name}.txt", false, Encoding.UTF8))
                {

                    sw.WriteLine($"{DateTime.Now}\n{Name.ToUpper()} call report:\n");
                    foreach (var call in calls)
                    {
                        sw.WriteLine($"Date:{call.Date}\t Number:{call.NumberToCall}\t Name: {call.NameToCall}\t  Duration:{call.Duration}\t Cost:{call.CostPerCall}\t");
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void OutputReportToConsole()
        {
            try
            {
                Console.WriteLine($"{DateTime.Now}\n{Name.ToUpper()} call report:\n");
                foreach (var call in calls)
                {
                    Console.WriteLine($"Date:{call.Date}\t Number:{call.NumberToCall}\t Name: {call.NameToCall}\t  Duration:{call.Duration}\t Cost:{call.CostPerCall}\t");
                }
                Console.WriteLine("\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void OutputReportToConsole(List<Call> calls)
        {
            try
            {
                Console.WriteLine($"{DateTime.Now}\n{Name.ToUpper()} call report:\n");
                foreach (var call in calls)
                {
                    Console.WriteLine($"Date:{call.Date}\t Number:{call.NumberToCall}\t Name: {call.NameToCall}\t  Duration:{call.Duration}\t Cost:{call.CostPerCall}\t");
                }
                Console.WriteLine("\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }












    }
}
