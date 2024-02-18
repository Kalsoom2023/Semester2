using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ProblemNo1.bl;
using System.Threading;

namespace ProblemNo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("+------------------------+");
            Console.WriteLine("|        Angle          |");
            Console.WriteLine("+------------------------+");
            Console.WriteLine("| - degrees: int        |");
            Console.WriteLine("| - minutes: float      |");
            Console.WriteLine("| - direction: char     |");
            Console.WriteLine("+------------------------+");
            Console.WriteLine("| + Angle(degrees: int, |");
            Console.WriteLine("|        minutes: float,|");
            Console.WriteLine("|       direction: char)|");
            Console.WriteLine("| + SetString():        |");
            Console.WriteLine("|        string         |");
            Console.WriteLine("+-------------------------+");

            Console.WriteLine("+-------------------------+");
            Console.WriteLine("|         Ship           |");
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| - number: string|");
            Console.WriteLine("| - latitude: Angle      |");
            Console.WriteLine("| - longitude: Angle     |");
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| + Ship(number: string, |");
            Console.WriteLine("|        latitude: Angle,|");
            Console.WriteLine("|       longitude: Angle)|");
            Console.WriteLine("| + printPosition(): void|");
            Console.WriteLine("| + PrintSerialNumber(): |");
            Console.WriteLine("|        void            |");
            Console.WriteLine("| + ChangePosition(newLat|");
            Console.WriteLine("|        itude: Angle,   |");
            Console.WriteLine("|        newLongitude:   |");
            Console.WriteLine("|        Angle): void    |");
            Console.WriteLine("+-------------------------+");
            Console.WriteLine();
            List<Ship> ships = new List<Ship>();
            while (true)
            {
                Console.WriteLine("Add Ship");
                Console.WriteLine("View Ship Position");
                Console.WriteLine("View Ship Serial Number");
                Console.WriteLine("Change Ship Position");
                Console.WriteLine("Exit");
                string option = Console.ReadLine();
                if (option == "1")
                {
                    Console.WriteLine("Enter Ship Number:");
                    string num = Console.ReadLine();

                    Console.WriteLine("Enter Ship Latitude:");

                    Console.WriteLine("Enter Latitude Degree:");
                    int num3 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Latitude Minute:");

                    float num4 = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Latitude Direction:");
                    char num5 = char.Parse(Console.ReadLine());
                    Angle angle = new Angle(num3, num4, num5);
                    Console.WriteLine("Enter Ship Longitude:");

                    Console.WriteLine("Enter Longitude Degree:");
                    int num7 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Longitude Minute:");
                    float num8 = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Longitude Direction:");
                    char num9 = char.Parse(Console.ReadLine());
                    Angle angle2 = new Angle(num7, num8, num9);
                    Ship ship = new Ship(num, angle, angle2);
                    ships.Add(ship);



                }
                if (option == "2")
                {
                    Console.WriteLine("Enter ship number to view position");
                    string ans = Console.ReadLine();
                    bool shipFound = false;
                    foreach (var ship in ships)
                    {
                        if (ship != null && ans == ship.number)
                        {
                            ship.printPosition();
                            shipFound = true;
                            break;
                        }
                    }

                    if (!shipFound)
                    {
                        Console.WriteLine("Ship not found.");
                    }
                }
                if (option == "3")
                {
                    bool shipF = false;
                    Console.WriteLine(" Enter the ship latitude:");
                    string lat = Console.ReadLine();
                    Console.WriteLine(" Enter the ship longitude:");
                    string lon = Console.ReadLine();
                    for (int i = 0; i < ships.Count; i++)
                    {
                        Console.WriteLine(ships[i].latitude.setString());
                        if (lat == ships[i].latitude.setString() && lon == ships[i].longitude.setString())
                        {
                            ships[i].printSerial();

                            shipF = true;
                            break;
                        }
                    }
                    if (!shipF)
                    {
                        Console.WriteLine("Ship not found");
                    }




                }
                if (option == "4")
                {
                    bool shipd = false;
                    Console.WriteLine("Enter Ship Number whose position you want to change:");
                    string num = Console.ReadLine();

                    Console.WriteLine("Enter Ship Latitude:");

                    Console.WriteLine("Enter Latitude Degree:");
                    int num3 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Latitude Minute:");

                    float num4 = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Latitude Direction:");
                    char num5 = char.Parse(Console.ReadLine());
                    Angle latitude = new Angle(num3, num4, num5);
                    Console.WriteLine("Enter Ship Longitude:");

                    Console.WriteLine("Enter Longitude Degree:");
                    int num7 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Longitude Minute:");
                    float num8 = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Longitude Direction:");
                    char num9 = char.Parse(Console.ReadLine());
                    Angle longitude = new Angle(num7, num8, num9);
                    for (int i = 0; i < ships.Count; i++)
                    {
                        if (num == ships[i].number)
                        {
                            ships[i].ChangePosition(latitude, longitude);

                            shipd = true;
                            break;
                        }
                    }
                    if (!shipd)
                    {
                        Console.WriteLine("Ship not found");
                    }



                }
                if (option == "5")
                {
                    Console.WriteLine("Exiting...");
                    Thread.Sleep(100);
                    Environment.Exit(0);

                }
            }

        }
    }
}
