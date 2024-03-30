using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDtask4
{
    class FixedInterest :  Interest
{

        public override double TrueBank(double amount, double rate) 
    {
        return amount + (amount* rate) + 1500;
    }
}
}
