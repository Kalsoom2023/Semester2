using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDtask3
{
    internal class Interest
    {
      

        public double TrueBank(double amount, double rate)
            {
                return amount + (amount * rate);
            }
            public double TrueBank(double amount, double rate, string holderType)
            {
                return amount + (amount * rate) + 2000;
            }

           
        }
    }

