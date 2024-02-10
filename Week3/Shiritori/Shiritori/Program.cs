using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Shiritori.bl;
namespace Shiritori
{
    internal class Program
    {
        static void Main(string[] args)
        {b:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to Shiritori");
            Console.ResetColor();
            ShiritoriGame game = new ShiritoriGame();
            while (game.Game_Over == false)
            {
                Console.WriteLine("Enter a word:");
                string word = Console.ReadLine();
                
                Console.WriteLine(game.Play(word));
            }
            if(game.Game_Over == true)
            {
                game.restart();
                Thread.Sleep(200);
                Console.Clear();
                goto b;
            }

        }
    }
}
