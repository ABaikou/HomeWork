using System;
using System.Collections.Generic;
using System.Text;

namespace BillingCompanyProject
{
    class Terminal
    {
        public int Number {get;}
        public bool IsEnable { get; set; }
        public bool IsUse { get; set; }

        public Terminal (int number)
        {
            Number = number;
            IsEnable = true;
            IsUse = false;
        }

    }
}
