using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Task1;

namespace Task1
{
    public class Calculate
    {
        public float Value1;
        public float Value2;


        public Calculate(Calculate calculate)
        {
            Value1 = calculate.Value1;
            Value2 = calculate.Value2;
        }
        public Calculate()
        { }
        public float Sum()
        {
            float Answer = Value1 + Value2;
            return Answer;
        }
        public float Sub()
        {
            float Answer = Value1 - Value2;
            return Answer;
        }
        public float Multiply()
        {
            float Answer = Value1 * Value2;
            return Answer;
        }
        public float Divide()
        {
            float Answer = Value1 / Value2;
            return Answer;
        }
        public float modulo()
        {
            float Answer = Value1 % Value2;
            return Answer;
        }
        public float sqrt(int num1)
        {

            return (float)Math.Sqrt(num1);
        }
        public float exp(int num1)
        {

            return (float)Math.Exp(num1);
        }
        public float log(int num1)
        {

            return (float)Math.Log(num1);
        }
        public float sin(int num1)
        {

            return (float)Math.Sin(num1);
        }
        public float cos(int num1)
        {

            return (float)Math.Cos(num1);
        }
        public float tan(int num1)
        {

            return (float)Math.Tan(num1);
        }

    }
}

internal class Program
{
    static void Main(string[] args)
    {
        string value ="";
        float num1 = 10F, num2 = 10F;
        int num3 = 0;
        Calculate data = new Calculate();
        data.Value1 = num1;
        data.Value2 = num2;

        while (value != "8")
        {

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("------------");
            Console.WriteLine(" CALCULATOR");
            Console.WriteLine("------------");
            Console.ResetColor();
            Console.WriteLine("1.Create an Object");
            Console.WriteLine("2.Change values");
            Console.WriteLine("3.Add");
            Console.WriteLine("4.Subtract");
            Console.WriteLine("5.Multiply");
            Console.WriteLine("6.Divide");
            Console.WriteLine("7.Modulo");
            Console.WriteLine("8.Exit");
         


            value =Console.ReadLine();

            if (value == "1")
            {
                Calculate data2 = new Calculate();

            }
            if (value == "2")
            {
                Console.WriteLine("Change Value1:");
                float number1 = float.Parse(Console.ReadLine());
                data.Value1 = number1;
                Console.WriteLine("Change Value2:");
                float number2 = float.Parse(Console.ReadLine());

                data.Value2 = number2;
            }
            if (value == "3")
            {
                Console.WriteLine("Sum:" + data.Sum());
               
            }
            if (value == "4")
            {
                Console.WriteLine("Sub:" + data.Sub());
              
            }
            if (value == "5")
            {
                Console.WriteLine("Multipliaction" + data.Multiply());
            }
            if (value == "6")
            {
                if (data.Value2 == 0)
                {
                    Console.WriteLine("Not accepted, Value is zero.Change it");
                }
                Console.WriteLine("Division:" + data.Divide());
              

            }
            if (value == "7")
            {
                Console.WriteLine("Modulo: " + data.modulo());
                
            }
            if (value == "8")
            {
Environment.Exit(0);
            }
            Thread.Sleep(400);


            Console.Clear();
        }
    }
}

