using System;
using System.Collections.Generic;
using System.Text;

namespace BillingCompanyProject
{
    class Call
    {
        public int NumberToCall { get; }
        public string NameToCall { get; }
        public int Duration { get;  }
        public decimal CostPerCall { get; }
        public DateTime Date { get; }

        public Call(int numberToCall, string nameToCall, int duration, decimal costPerCall, DateTime date)
        {
            NumberToCall = numberToCall;
            NameToCall = nameToCall;
            Duration = duration;
            CostPerCall = costPerCall;
            Date = date;
        }


    }
}
