using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDtask4
{
    class Interest
    {
        List <Interest> interests=new List<Interest> ();
        public void addinlist(Interest interest)
        {
            interests.Add(interest);
        }
        public virtual double TrueBank(double amount, double rate)
        {
            return amount + (amount * rate);
        }
    };
}
