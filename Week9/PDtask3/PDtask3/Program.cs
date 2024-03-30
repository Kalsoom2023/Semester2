using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDtask3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
           
            Interest interest = new Interest();
            double initialAmount = 5000;
            double interestRate = 0.10;
            double regularInterest = interest.TrueBank(initialAmount, interestRate);
            Console.WriteLine("The interest for a regular account holder is: $" + regularInterest);
            double primeInterest = interest.TrueBank(initialAmount, interestRate, "prime");
            Console.WriteLine("The interest for a prime account holder is: $" + primeInterest);
        }
    }
}
