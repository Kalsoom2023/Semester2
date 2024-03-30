using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDtask4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Interest interest = new Interest();
            Console.WriteLine("$"+interest.TrueBank(5000.00, 0.1) + ".00");
            SimpleInterest simpleInterest = new SimpleInterest();
            Console.WriteLine("$"+simpleInterest.TrueBank(5000.00, 0.1) + ".00");
            FixedInterest fixedInterest = new FixedInterest();
            interest.addinlist(simpleInterest);
            interest.addinlist(fixedInterest);
            Console.WriteLine("$"+fixedInterest.TrueBank(5000.00, 0.1) + ".00");

        }
    }
}
