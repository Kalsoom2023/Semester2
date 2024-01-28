using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using check.data;
namespace check
{
    public class Program
    {
        static void Login()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("Enter 1 to sign in:");
            Console.WriteLine("------------------------------");
            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine("Enter 2 to sign up:");
            Console.WriteLine("------------------------------");
            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine("Enter 3 to exit:");
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------------------------");
            Console.Write("Enter choice: ");
            Console.ResetColor();
            Console.WriteLine("------------------------------");
            Console.WriteLine();
        }
        static void Header()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                        |                             ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                       _|_                            ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                     / ___ \\                          ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                    /oo   oo\\                         ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\\___________________\\       /___________________/     ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  `-----|------|-----\\_____/-----|------|------'      ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("    ( )    ( )     O|OOo|oOO|O     ( )    ( )         ");
            Console.WriteLine();
            Console.WriteLine("       WELCOME TO FLIGHT MANAGEMENT SYSTEM           ");
            Console.WriteLine();
            Console.ResetColor();
        }
        static string LowerString(string role)
        {
            string smaller = role.ToLower();

            return smaller;
        }
        static void success()

        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("--------------------");
            Console.WriteLine("Operation success");
            Console.WriteLine("--------------------");
            Console.ResetColor();

        }
        static void failure()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("--------------------");
            Console.WriteLine("Operation failure");
            Console.WriteLine("--------------------");
            Console.ResetColor();
        }
        static string SignIn(string name, string password, List<MUser> users)
        {
            string a = "none";

            for (int i = 0; i < users.Count; i++)
            {
                if (name == users[i].Username && password == users[i].Password)
                {

                    return users[i].Role;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("----------------------");
            Console.WriteLine("     NO USER FOUND       ");
            Console.WriteLine("----------------------");
            Console.WriteLine();
            Console.ResetColor();
            return a;
        }
        static string GetField(string record, int field)
        {
            int commaCount = 1;
            string item = "";

            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    commaCount++;
                }
                else if (commaCount == field)
                {
                    item += record[x];
                }
            }

            return item;
        }
        static void signup(string name, string password, string role, List<MUser> users, ref int count)
        {
            users[count] = new MUser(name, password, role);
            StoreData(name, password, role);
            count++;
        }
        static bool validuser(string name, List<MUser> users, ref int count)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (name == users[i].Username)

                    return false;
            }
            return true;
        }
        static void StoreData(string name, string password, string role)
        {
            string path = "C:\\Users\\ADMIN\\Desktop\\users.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(name + "," + password + "," + role);
            file.Flush();
            file.Close();
        }
        static void viewrate(List<Rate> rates)
        {
            Console.WriteLine("Ratings are below: ");
            for (int i = 0; i < rates.Count; i++)
            {
                Console.WriteLine(rates[i].name + ": " + rates[i].rating);
            }
        }
        static void ReadRate(List<Rate> rates)
        {
            string path = "C:\\Users\\ADMIN\\Desktop\\rates.txt";
            if (File.Exists(path))

            {
                StreamReader fileVar = new StreamReader(path);
                string record;
                while ((record = fileVar.ReadLine()) != null)
                {
                    string rating = GetField(record, 2);
                    string ratename = GetField(record, 1);
                    Rate rate = new Rate(ratename, rating);
                    rates.Add(rate);

                }
                fileVar.Close();
            }

            else
            {
                Console.WriteLine("Does not exist");
            }
        }
        static void readData(List<MUser> users, ref int count)
        {
            string path = "C:\\Users\\ADMIN\\Desktop\\users.txt";
            if (File.Exists(path))
            {
                StreamReader fileVar = new StreamReader(path);
                string record;
                while ((record = fileVar.ReadLine()) != null)
                {


                    string userName = GetField(record, 1);
                    string password = GetField(record, 2);
                    string role = GetField(record, 3);
                    MUser user = new MUser(userName, password, role);
                    users.Add(user);

                }
                fileVar.Close();
            }
        }
        static void adminheader()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("                     ***********************************************");
            Console.WriteLine("                     *             WELCOME                         *");
            Console.WriteLine("                     *                 TO                          *");
            Console.WriteLine("                     *                 ADMIN                       *");
            Console.WriteLine("                     *                    PORTAL                   *");
            Console.WriteLine("                     ***********************************************");
            Console.WriteLine();
            Console.ResetColor();
        }
        static void AdminMenu()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Press 1 to add a flight: ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Press 2 to cancel a flight: ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Press 3 to Update a flight: ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Press 4 to view all flight: ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Press 5 to see information of a flight: ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Press 6 to view rating: ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Press 7 to view booked flights: ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Press 8 to give announcements: ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Press 9 to exit: ");
            Console.WriteLine("-------------------------------");
        }
        static bool isValidDate(int dd, int mm, int yy)
        {
            if (yy <= 0)
                return false;

            if (mm <= 0 || mm > 12)
                return false;

            if (mm == 2)
            {
                if (yy % 4 == 0)
                {
                    if (dd > 29 || dd <= 0)
                        return false;
                }
                else
                {
                    if (dd > 28 || dd <= 0)
                        return false;
                }
            }
            else if (mm == 1 || mm == 3 || mm == 5 || mm == 7 || mm == 8 || mm == 10 || mm == 12)
            {
                if (dd > 31 || dd <= 0)
                    return false;
            }
            else
            {
                if (dd > 30 || dd <= 0)
                    return false;
            }

            return true;
        }
        static bool validflight(string numberofflight, List<Flights> flights)
        {
            for (int i = 0; i < flights.Count; i++)
            {
                if (numberofflight == flights[i].flightNo)
                {
                    return false;
                }
            }
            return true;
        }
        static void AddFlight(string numberofflight, string date, string destination, string departure, int price, int seatnew, List<Flights> flights, ref int flightcount)
        {

            Flights f = new Flights(numberofflight, date, destination, departure, price, seatnew);
            flights.Add(f);
            StoreFlight(numberofflight, date, destination, departure, price, seatnew);

            flightcount++;
        }
        static void storeFlight(List<Flights> flights)
        {
            string path = "C:\\Users\\ADMIN\\Desktop\\flight.txt";
            StreamWriter file = new StreamWriter(path);
            for (int i = 0; i < flights.Count; i++)
            {
                file.WriteLine(flights[i].flightNo + "," + flights[i].flightDate + "," + flights[i].flightDestination + "," + flights[i].flightDeparture + "," + flights[i].flightPrice + "," + flights[i].flightSeats);
            }
            file.Flush();
            file.Close();
        }
        static void StoreFlight(string numberofflight, string flightDate, string flightDestination, string flightDeparture, int flightPrice, int flightSeats)
        {
            string path = "C:\\Users\\ADMIN\\Desktop\\flight.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(numberofflight + "," + flightDate + "," + flightDestination + "," + flightDeparture + "," + flightPrice + "," + flightSeats);
            file.Flush();
            file.Close();
        }
        static void CancelFlight(string numberofflight, List<Flights> flights,List <Book> books)
        {
            for (int c = 0; c < flights.Count; c++)
            {
                if (numberofflight == flights[c].flightNo)
                {
                    flights.RemoveAt(c);
                    
                    
                }
            }
            for (int c = 0; c < books.Count; c++)
            {
                if (numberofflight == books[c].bookednumber)
                {
                    books.RemoveAt(c);
                    success();
                    break;
                }
            }

            storebook(books);
            storeFlight(flights);
        }
        static void ViewFlight(List<Flights> flights)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Flightnumber\tFlightdate\tFlightdestination\tFlightdeparture\tFlightprice\tFlightseats");
            Console.ResetColor();

            for (int i = 0; i < flights.Count; i++)
            {
                Console.WriteLine(flights[i].flightNo + "\t\t" + flights[i].flightDate + "\t\t" + flights[i].flightDestination + "\t\t\t" + flights[i].flightDeparture + "\t\t" + flights[i].flightPrice + "\t\t" + flights[i].flightSeats);
            }
        }
        static void viewoneflight(string numberofflight, List<Flights> flights)
        {
            {
                for (int i = 0; i < flights.Count; i++)
                    if (numberofflight == flights[i].flightNo)
                    {
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine(" Flight number: " + flights[i].flightNo);
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine(" Flight date: " + flights[i].flightDate);
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine(" Flight destination: " + flights[i].flightDestination);
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine(" Flight departure: " + flights[i].flightDeparture);
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine(" Flight price: " + flights[i].flightPrice);
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine(" Flight seats: " + flights[i].flightSeats);
                        Console.WriteLine("------------------------------------");
                    }
            }
        }
        static void GiveMessage(string mess, List<Message> messages)
        {
            Message message = new Message(mess);
            messages.Add(message);
            storemessage(mess);


        }
        static void UpdateFlight(string numberofflight, string date, string destination, string departure, int price, int seatnew, List<Flights> flights)
        {
            for (int i = 0; i < flights.Count; i++)
            {
                if (numberofflight == flights[i].flightNo)
                {
                    flights[i].flightDate = date;
                    flights[i].flightDestination = destination;
                    flights[i].flightDeparture = departure;
                    flights[i].flightPrice = price;
                    flights[i].flightSeats = seatnew;
                }
            }

            storeFlight(flights);
        }
        static void storemessage(string message)
        {
            string path = "C:\\Users\\ADMIN\\Desktop\\messages.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(message + ",");
            file.Flush();
            file.Close();
        }
        static void ReadFlight(List<Flights> flights)
        {
            string path = "C:\\Users\\ADMIN\\Desktop\\flight.txt";
            if (File.Exists(path))

            {

                StreamReader fileVar = new StreamReader(path);
                string record;
                int flightprices = 0, flightseatss = 0;
                while ((record = fileVar.ReadLine()) != null)
                {
                    string flightnum = GetField(record, 1);
                    string flightdates = GetField(record, 2);
                    string flightdestinations = GetField(record, 3);
                    string flightdepartures = GetField(record, 4);
                    flightprices = int.Parse(GetField(record, 5));

                    flightseatss = int.Parse(GetField(record, 6));

                    Flights flighto = new Flights(flightnum, flightdates, flightdestinations, flightdepartures, flightprices, flightseatss);
                    flights.Add(flighto);
                }
                fileVar.Close();
            }

            else
            {
                Console.WriteLine("Does not exist");
            }
        }
        static void ReadMessage(List<Message> messages)
        {
            string mmessage;
            string path = "C:\\Users\\ADMIN\\Desktop\\messages.txt";
            if (File.Exists(path))
            {
                StreamReader fileVar = new StreamReader(path);
                string record;
                while ((record = fileVar.ReadLine()) != null)
                {
                    mmessage = GetField(record, 1);
                    Message mess = new Message(mmessage);
                    messages.Add(mess);

                }
                fileVar.Close();
            }
            else
            {
                Console.WriteLine("Does not exist");
            }
        }
        static void ViewAllBookedFlight(List<Book> books)
        {
            Console.WriteLine("Username\t\tFlightdate\tFlightnumber\tFlightdestination\tFlightdeparture\tTotalprice\tBookedseats");

            for (int c = 0; c < books.Count; c++)
            {
                Console.WriteLine(books[c].name + "\t\t\t" + books[c].bookednumber + "\t" + books[c].bookeddate + "\t\t" + books[c].bookeddestination + "\t\t\t" + books[c].bookeddeparture + "\t\t" + books[c].bookedprice + "\t\t" + books[c].bookedseats);
            }
        }
        static void bookflight(string username, string number, int seatnew1, List<Book> books, List<Flights> flights)
        {
            int bookedprice = 0;
            string bookdep = "", bookdes = "", bookeddate = "";
            for (int i = 0; i < flights.Count; i++)
            {
                if (number == flights[i].flightNo && seatnew1 <= flights[i].flightSeats)
                {
                    flights[i].flightSeats -= seatnew1;
                    bookedprice = seatnew1 * flights[i].flightPrice;
                    bookdep = flights[i].flightDeparture;
                    bookdes = flights[i].flightDestination;
                    bookeddate = flights[i].flightDate;
                    Book booked = new Book(username, number, bookeddate, bookdep, bookdes, bookedprice, seatnew1);
                    books.Add(booked);
                }

            }
            storeFlight(flights);
            Storebook(username, number, bookeddate, bookdes, bookdep, bookedprice, seatnew1);

        }
        static bool flightisvalid(string username, List<Book> books, string flightnumber)
        {
            int k = 0;
            for (int i = 0; i < books.Count; i++)
            {
                if (username == books[i].name && flightnumber == books[i].bookednumber)
                {

                    Console.WriteLine("You already booked this flight. Please go to update seat.");
                    return false;

                }
            }


            return true;
        }
        static void ViewBookedFlight(string username, List<Book> books)
        {
            for (int c = 0; c < books.Count; c++)
            {
                if (username == books[c].name)
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Flight number: " + books[c].bookednumber);
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Flight date: " + books[c].bookeddate);
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Flight destination: " + books[c].bookeddestination);
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Flight departure: " + books[c].bookeddeparture);
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Flight price: " + books[c].bookedprice);
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Flight seats: " + books[c].bookedseats);
                    Console.WriteLine("------------------------------------");
                }
            }
        }
        static void CancelBookedFlight(List<Flights> flights, string username, List<Book> books, string numberofflight)
        {
            int total = 0;
            for (int c = 0; c < books.Count; c++)
            {
                if (numberofflight == books[c].bookednumber && username == books[c].name)
                {
                    total = books[c].bookedseats;
                    books.RemoveAt(c);
                }
            }
                for (int i = 0; i < flights.Count; i++)
                {
                    if (numberofflight == flights[i].flightNo)
                    {
                        flights[i].flightSeats += total;
                    }
                }

                success();
            storeFlight(flights);
            storebook(books);
        }
        static void storebook(List<Book> books)
        {
            string path = "C:\\Users\\ADMIN\\Desktop\\book.txt";
            StreamWriter file = new StreamWriter(path);

            for (int i = 0; i < books.Count; i++)
            {
                file.WriteLine(books[i].name + "," + books[i].bookednumber + "," + books[i].bookeddate + "," + books[i].bookeddestination + "," + books[i].bookeddeparture + "," + books[i].bookedprice + "," + books[i].bookedseats);
            }
            file.Flush();
            file.Close();
        }

        static bool ValidForUpdate(string username, string numberofflight, int seatnew1, List<Flights> flights, List<Book> books)
        {
            int total = 0;
            for (int b = 0; b < books.Count; b++)
            {
                if (numberofflight == books[b].bookednumber && username == books[b].name)
                {
                    total = books[b].bookedseats;

                }
            }
            for (int b = 0; b < flights.Count; b++)
            {
                if (numberofflight == flights[b].flightNo)
                {
                    flights[b].flightSeats += total;
                    if (seatnew1 <= flights[b].flightSeats)
                    {
                        flights[b].flightSeats -= seatnew1;
                        return true;
                    }

                }
            }
            return false;
        }
        static bool ValidBooked(string username, string numberofflight, List<Book> books)
        {
            for (int c = 0; c < books.Count; c++)
            {
                if (numberofflight == books[c].bookednumber && username == books[c].name)
                {
                    return true;
                }
            }
            return false;
        }
        static void Storebook(string bookedname, string bookednumber, string bookeddate, string bookeddestination, string bookeddeparture, int bookedprice, int bookedseats)
        {
            string path = "C:\\Users\\ADMIN\\Desktop\\book.txt";
            StreamWriter file = new StreamWriter(path, true);

            file.WriteLine(bookedname + "," + bookednumber + "," + bookeddate + "," + bookeddestination + "," + bookeddeparture + "," + bookedprice + "," + bookedseats);
            file.Flush();
            file.Close();
        }
        static void updateseat(string username, List<Book> books, List<Flights> flights, string numberofflight, int seatnew1)
        {
            int p = 0;
            for (int c = 0; c < flights.Count; c++)
            {
                if (numberofflight == flights[c].flightNo)
                {
                    p = flights[c].flightPrice;
                }
            }

                for (int k = 0; k < books.Count; k++)
                {
                    if (numberofflight == books[k].bookednumber && username == books[k].name)
                    {


                        books[k].bookedseats = seatnew1;
                        books[k].bookedprice = seatnew1 * p;
                    }
                }


                
            
        
        storeFlight(flights);
        storebook(books);
    }
        static void giverate(string username, string ratings,List <Rate> rates)
        {
            Rate rate = new Rate(username, ratings);
            rates.Add(rate);
            storerate(username, ratings);
            
        }
         static void storerate(string username, string ratings)
        {
            string path = "C:\\Users\\ADMIN\\Desktop\\rates.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(username+ "," + ratings + ",");
            file.Flush();
            file.Close();
        }
        static void viewmessage(List <Message> messages)
        {
            Console.WriteLine("Message are given below  ");
            for (int i = 0; i < messages.Count; i++)
            {

                Console.WriteLine(messages[i].messageData);
            }
        }
        static void userheader()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                     ***********************************************");
            Console.WriteLine("                     *             WELCOME                         *");
            Console.WriteLine("                     *                 TO                          *");
            Console.WriteLine("                     *                  USER                       *");
            Console.WriteLine("                     *                    PORTAL                   *");
            Console.WriteLine("                     ***********************************************");
            Console.WriteLine();
            Console.ResetColor();
        }
        static void usermenu()
        {
            string option2;
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Press 1 to book a flight: ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Press 2 to view all flight: ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Press 3 to change seat information : ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Press 4 to cancel flight: ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Press 5 to see your booked flight: ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Press 6 to give rating: ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Press 7 to read announcements: ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Press 8 to exit: ");
            Console.WriteLine("-------------------------------");
        }
        static void Userinterface( List <Rate> rates,List <Message> messages,string username,List <Flights> flights, List <Book> books)

        {
            Console.Clear();

            string destination1, departure1, date, rate, numberofflight, cnic, cnicnew1;
            int price;
            string seatnew11;
            int seatnew1 = 0;
            string userOption = "";
            while (userOption != "8")

            {
                userheader();
                usermenu();
                userOption = Console.ReadLine();
                if (userOption == "1")
                {
                    Console.Clear();
                    ViewFlight(flights);
                n:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("      BOOK A FLIGHT     ");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine();
                    Console.ResetColor();

                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Enter flight Number: ");
                    Console.WriteLine("----------------------------");
                    numberofflight = Console.ReadLine();
                   

                  
                k:
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Enter total seat: ");
                    Console.WriteLine("----------------------------");

                    seatnew11 = Console.ReadLine();
                    int size2 = seatnew11.Length;       //seats validation
                    char[] seatchar = seatnew11.ToCharArray();
                    for (int i = 0; i < size2; i++)
                    {
                        if (!(seatchar[i] >= 48 && seatchar[i] <= 57))
                        {
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine("!!!Invalid.Incorrect type of data!!!");
                            Console.WriteLine("-------------------------------------");
                            goto k;
                        }
                    }
                    seatnew1 = int.Parse(seatnew11);
                    if (flightisvalid(username,books,numberofflight))
                    {
                        bookflight( username,numberofflight, seatnew1, books,flights);
                        success();
                    }
                    else
                    {

                        failure();
                    }

                    Console.ReadLine();
                    Console.Clear();
                }
                else if (userOption == "2")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("          VIEW FLIGHTS      ");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine();
                    Console.ResetColor();
                    ViewFlight(flights);
                    Console.ReadLine();
                    Console.Clear();
                }

                else if (userOption == "5")
                {

                j:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("      VIEW BOOKED FLIGHT ");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine();
                    Console.ResetColor();

                    ViewBookedFlight(username,books);
                    success();

                    Console.ReadLine();
                    Console.Clear();
                }
                else if (userOption == "4")
                {

                l:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("       CANCEL BOOKED FLIGHT");
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine();
                    Console.ResetColor();

                i:
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine("Enter your flight number which you want to cancel: ");
                    Console.WriteLine("------------------------------------------------");
                    numberofflight = Console.ReadLine();
                    int sizeflight = numberofflight.Length;
                    char[] numberchar = numberofflight.ToCharArray(); //number of flight check if exist
                    for (int i = 0; i < sizeflight; i++)
                    {
                        if (!(numberchar[i] >= 48 && numberchar[i] <= 57))
                        {
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine("!!!Invalid.Incorrect type of data!!!");
                            Console.WriteLine("-------------------------------------");
                            Console.ReadLine();
                            goto i;
                        }
                    }
                    if (!(sizeflight == 4))
                    {
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("!!Invalid, limit should be three!!");
                        Console.WriteLine("--------------------------------------");
                        Console.ReadLine();
                        goto i;
                    }

                    if (ValidBooked( username,  numberofflight,books))
                    {
                        CancelBookedFlight(flights,username, books, numberofflight);
                        success();
                    }
                    else
                        failure();
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (userOption == "3")
                {

                c:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("    UPDATE  BOOKED SEATS");
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Enter flight number to update: ");
                    Console.WriteLine("----------------------------");
                    numberofflight = Console.ReadLine();
                    int sizeflight1 = numberofflight.Length;
                    char[] numberchar = numberofflight.ToCharArray(); //   //number of fllght check if exist	
                    for (int i = 0; i < sizeflight1; i++)
                    {
                        if (!(numberchar[i] >= 48 && numberchar[i] <= 57))
                        {
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine("!!!Invalid.Incorrect type of data!!!");
                            Console.WriteLine("-------------------------------------");
                            Console.ReadLine();
                            goto c;
                        }
                    }
                    if (!(sizeflight1 == 4))
                    {
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("!!Invalid, limit should be three!!");
                        Console.WriteLine("--------------------------------------");
                        Console.ReadLine();
                        goto c;
                    }
                e:
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Enter new seats: ");
                    Console.WriteLine("----------------------------");
                    seatnew11 = Console.ReadLine();
                    int size2 = seatnew11.Length;       //seats validation
                    char[] seatchar = seatnew11.ToCharArray();

                    for (int i = 0; i < size2; i++)
                    {
                        if (!(seatchar[i] >= 48 && seatchar[i] <= 57))
                        {
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine("!!!Invalid.Incorrect type of data!!!");
                            Console.WriteLine("-------------------------------------");
                            goto e;
                        }
                    }
                    seatnew1 = int.Parse(seatnew11);

                    if (ValidForUpdate( username,numberofflight,seatnew1,flights,books))
                    {
                        updateseat(username,books,flights, numberofflight, seatnew1);
                        success();
                        Console.ReadLine();
                    }

                    else
                        failure();

                    Console.ReadLine();
                    Console.Clear();
                }
                else if (userOption == "6")
                {
                x:
                g:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("----------------------");
                    Console.WriteLine("    GIVE RATING ");
                    Console.WriteLine("----------------------");
                    Console.WriteLine();
                    Console.ResetColor();
                y:
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("Enter rating of app in stars(1 to 5): ");
                    Console.WriteLine("--------------------------------------");
                    string ratings = Console.ReadLine();
                    if (ratings == "*" || ratings == "**" || ratings == "***" || ratings == "****" || ratings == "*****")

                        giverate(username, ratings,  rates);
                    else
                    {
                        Console.WriteLine("Invalid");
                        goto y;
                    }
                    success();
                    Console.ReadLine();
                    Console.Clear();

                }
                else if (userOption == "7")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("----------------------------");
                    Console.WriteLine(" CHECK ANNOUNEMENTS");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine();
                    Console.ResetColor();
                    viewmessage(messages);
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (userOption == "8")
                {

                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    failure();
                    Console.ReadLine();
                    Console.Clear();
                }
                Console.Clear();
            }
        }
        static void Admininterface(List <Flights> flights,List <Message> messages,List <Rate> rates,List <Book> books,ref int flightcount)
        {
            Console.Clear();
            string dd, mm, yy;
            int d, m, y;
            
            
            string destination, departure, date, numberofflight, a, b, c;
            int price, g = 1, v = 0;
            string seatnew1;
            string price1;
            int seatnew;
            string adminOption = "";
            while (adminOption != "9")

            {
            k:

                adminheader();
                AdminMenu();
                adminOption = Console.ReadLine();
                if (adminOption == "1")
                {

                    Console.Clear();

                n:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("         ADD FLIGHT      ");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine();
                    Console.ResetColor();
                b:
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Enter flight number(must be four): ");
                    Console.WriteLine("----------------------------");
                    numberofflight = Console.ReadLine();
                    int size = numberofflight.Length;
                    char[] numberchar = numberofflight.ToCharArray();    //flight validation
                    for (int i = 0; i < size; i++)
                    {
                        if (!(numberchar[i] >= 48 && numberchar[i] <= 57))
                        {
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine("!!!Invalid.Incorrect type of data!!!");
                            Console.WriteLine("-------------------------------------");
                            goto b;
                        }
                    }
                    if (!(size == 4))
                    {
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("!!Invalid, limit should be three!!");
                        Console.WriteLine("--------------------------------------");
                        goto b;
                    }

                w:
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Enter flight date(dd/mm/yy)");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Enter date: ");

                    dd = Console.ReadLine();
                    int siz = dd.Length;
                    char[] ddchar = dd.ToCharArray();
                    if (!(siz == 2))
                    {
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("!!Invalid, limit should be two!!");
                        Console.WriteLine("--------------------------------------");
                        goto w;
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        if (!(ddchar[i] >= 48 && ddchar[i] <= 57))                   //date validation
                        {
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine("!!!Invalid.Incorrect type of data!!!");
                            Console.WriteLine("-------------------------------------");
                            goto w;
                        }
                    }
                    if (!(siz == 2))
                    {
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("!!Invalid, limit should be two!!");
                        Console.WriteLine("--------------------------------------");
                        goto w;
                    }

                    Console.WriteLine("Enter month: ");
                    mm = Console.ReadLine();
                    char[] mmchar = mm.ToCharArray();
                    int s = mm.Length;
                    if (!(s == 2))
                    {
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("!!Invalid, limit should be two!!");
                        Console.WriteLine("--------------------------------------");
                        goto w;
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        if (!(mmchar[i] >= 48 && mmchar[i] <= 57))
                        {
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine("!!!Invalid.Incorrect type of data!!!");
                            Console.WriteLine("-------------------------------------");
                            goto w;
                        }
                    }
                    if (!(s == 2))
                    {
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("!!Invalid, limit should be two!!");
                        Console.WriteLine("--------------------------------------");
                        goto w;
                    }

                    Console.WriteLine("Enter year: ");
                    yy = Console.ReadLine();
                    char[] yychar = yy.ToCharArray();

                    int sizes = yy.Length;
                    if (!(sizes == 2))
                    {
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("!!Invalid, limit should be two!!");
                        Console.WriteLine("--------------------------------------");
                        goto w;
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        if (!(yy[i] >= 48 && yy[i] <= 57))
                        {
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine("!!!Invalid.Incorrect type of data!!!");
                            Console.WriteLine("-------------------------------------");
                            goto w;
                        }
                    }
                    if (!(sizes == 2))
                    {
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("!!Invalid, limit should be two!!");
                        Console.WriteLine("--------------------------------------");
                        goto w;
                    }
                    d = int.Parse(dd);
                    m = int.Parse(mm);
                    y = int.Parse(yy);

                    if (isValidDate(d, m, y) == false)
                    {
                        Console.WriteLine();
                        Console.WriteLine("invalid");
                        goto w;
                    }
                    a = d.ToString();
                    b = m.ToString();
                    c = y.ToString();

                    date = a + "\\" + b + "\\" + c;

                j:
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("Enter destination in small letters: ");
                    Console.WriteLine("---------------------------------");
                    destination = Console.ReadLine();
                    char[] destinationchar = destination.ToCharArray();
                    for (int i = 0; i < destination.Length; i++)          //destination validation
                    {
                        if (destinationchar[i] >= 97 && destinationchar[i] <= 122)
                        {
                            continue;
                        }
                        else
                            Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine("!!!You entered an invalid character in name!!! ");
                        Console.WriteLine("-----------------------------------------------");
                        goto j;
                    }


                i:
                    Console.WriteLine("----------------------------------");         //departure validation
                    Console.WriteLine("Enter departure in small letters: ");
                    Console.WriteLine("----------------------------------");
                    departure = Console.ReadLine();
                    char[] departurechar = departure.ToCharArray();
                    for (int i = 0; i < departure.Length; i++)
                    {
                        if (departurechar[i] >= 97 && departurechar[i] <= 122)
                        {
                            continue;
                        }
                        else
                            Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine("!!!You entered an invalid character in name!!! ");
                        Console.WriteLine("-----------------------------------------------");
                        goto i;
                    }


                o:
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Enter price per seat: ");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Rs. ");
                    price1 = Console.ReadLine();
                    char[] pricechar = price1.ToCharArray();
                    int size3 = price1.Length;              //price validation

                    for (int i = 0; i < size3; i++)
                    {
                        if (!(pricechar[i] >= 48 && pricechar[i] <= 57))
                        {
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine("!!!Invalid.Incorrect type of data!!!");
                            Console.WriteLine("-------------------------------------");
                            goto o;
                        }
                    }
                    price = int.Parse(price1);

                d:
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Enter total seat: ");
                    Console.WriteLine("----------------------------");
                    seatnew1 = Console.ReadLine();
                    char[] seatchar = seatnew1.ToCharArray();
                    int size2 = seatnew1.Length;

                    for (int i = 0; i < size2; i++)           //seats validation
                    {
                        if (!(seatchar[i] >= 48 && seatchar[i] <= 57))
                        {
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine("!!!Invalid.Incorrect type of data!!!");
                            Console.WriteLine("-------------------------------------");
                            goto d;
                        }
                    }
                    seatnew = int.Parse(seatnew1);

                    if (validflight(numberofflight, flights))
                    {
                        AddFlight(numberofflight, date, destination, departure, price, seatnew, flights,ref flightcount);
                        success();
                    }
                    else
                        failure();

                    Console.ReadLine();
                    Console.Clear();
                }
                else if (adminOption == "4")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("         VIEW FLIGHT        ");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine();
                    Console.ResetColor();
                    ViewFlight(flights);
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (adminOption == "6")
                {

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("        VIEW RATING          ");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine();
                    Console.ResetColor();
                    viewrate(rates);
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (adminOption == "7")
                {

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("   VIEW ALL BOOKED FLIGHT   ");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine();
                    Console.ResetColor();
                    ViewAllBookedFlight(books);
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (adminOption == "2")
                {

                p:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("       CANCEL FLIGHT       ");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine("Enter the flight number you want to cancel: ");
                    Console.WriteLine("------------------------------------------------");
                    numberofflight = Console.ReadLine();
                    int size = numberofflight.Length;
                    char[] numberchar = numberofflight.ToCharArray();           //number of flight validation
                    for (int i = 0; i < size; i++)
                    {
                        if (!(numberchar[i] >= 48 && numberchar[i] <= 57))
                        {
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine("!!!Invalid.Incorrect type of data!!!");
                            Console.WriteLine("-------------------------------------");
                            Console.ReadLine();
                            goto p;
                        }
                    }
                    if (!(size == 4))
                    {
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("!!Invalid, limit should be three!!");
                        Console.WriteLine("--------------------------------------");
                        Console.ReadLine();
                        goto p;
                    }
                    if (validflight(numberofflight, flights) == false)
                    {
                        CancelFlight(numberofflight, flights,books);
                        success();
                        Console.ReadLine();
                    }
                    else
                    {
                        failure();
                    }
                    Console.ReadLine();

                    Console.Clear();
                }
                else if (adminOption == "5")
                {

                u:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("     VIEW A FLIGHT         ");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine("Enter the flight number you want to view:");
                    Console.WriteLine("----------------------------------------------");
                    numberofflight = Console.ReadLine();
                    int size = numberofflight.Length;
                    char[] numberchar = numberofflight.ToCharArray();
                    for (int i = 0; i < size; i++)
                    {
                        if (!(numberchar[i] >= 48 && numberchar[i] <= 57))     //number of flight validation
                        {
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine("!!!Invalid.Incorrect type of data!!!");
                            Console.WriteLine("-------------------------------------");
                            Console.ReadLine();
                            goto u;
                        }
                    }
                    if (!(size == 4))
                    {
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("!!Invalid, limit should be three!!");
                        Console.WriteLine("--------------------------------------");
                        Console.ReadLine();
                        goto u;
                    }

                    if (validflight(numberofflight, flights) == false)
                    {
                        viewoneflight(numberofflight,flights);
                        Console.ReadLine();
                    }
                    else
                    {
                        failure();
                        Console.ReadLine();
                    }
                    Console.Clear();
                }
                else if (adminOption == "3")
                {
                    string update;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("       UPDATE FLIGHT    ");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine();
                x: Console.ResetColor();
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Enter flight number to update: ");
                    Console.WriteLine("----------------------------");
                    numberofflight = Console.ReadLine();
                    int size = numberofflight.Length;
                    char[] numberchar = numberofflight.ToCharArray();
                    for (int i = 0; i < size; i++)
                    {
                        if (!(numberchar[i] >= 48 && numberchar[i] <= 57))     //number of flight validation
                        {
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine("!!!Invalid.Incorrect type of data!!!");
                            Console.WriteLine("-------------------------------------");
                            Console.ReadLine();
                            goto x;
                        }
                    }
                    if (!(size == 4))
                    {
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("!!Invalid, limit should be four!!");
                        Console.WriteLine("--------------------------------------");
                        Console.ReadLine();
                        goto x;
                    }
                q:
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Enter  date: ");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Enter date: ");
                    dd = Console.ReadLine();
                    int si = dd.Length;
                    if (!(si == 2))
                    {
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("!!Invalid, limit should be two!!");
                        Console.WriteLine("--------------------------------------");
                        goto q;
                    }
                    char[] ddchar = dd.ToCharArray();  //date validation
                    for (int i = 0; i < 2; i++)
                    {
                        if (!(ddchar[i] >= 48 && ddchar[i] <= 57))
                        {
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine("!!!Invalid.Incorrect type of data!!!");
                            Console.WriteLine("-------------------------------------");
                            goto q;
                        }
                    }
                    if (!(si == 2))
                    {
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("!!Invalid, limit should be two!!");
                        Console.WriteLine("--------------------------------------");
                        goto q;
                    }

                    Console.WriteLine("Enter month: ");
                    mm = Console.ReadLine();
                    char[] mmchar = mm.ToCharArray();
                    int siz = mm.Length;
                    if (!(siz == 2))
                    {
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("!!Invalid, limit should be two!!");
                        Console.WriteLine("--------------------------------------");
                        goto q;
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        if (!(mmchar[i] >= 48 && mmchar[i] <= 57))
                        {
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine("!!!Invalid.Incorrect type of data!!!");
                            Console.WriteLine("-------------------------------------");
                            goto q;
                        }
                    }
                    if (!(siz == 2))
                    {
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("!!Invalid, limit should be two!!");
                        Console.WriteLine("--------------------------------------");
                        goto q;
                    }

                    Console.WriteLine("Enter year: ");
                    yy = Console.ReadLine();
                    char[] yychar = yy.ToCharArray();
                    int sizes = yy.Length;
                    if (!(sizes == 2))
                    {
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("!!Invalid, limit should be two!!");
                        Console.WriteLine("--------------------------------------");
                        goto q;
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        if (!(yychar[i] >= 48 && yychar[i] <= 57))
                        {
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine("!!!Invalid.Incorrect type of data!!!");
                            Console.WriteLine("-------------------------------------");
                            goto q;
                        }
                    }
                    if (!(sizes == 2))
                    {
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("!!Invalid, limit should be two!!");
                        Console.WriteLine("--------------------------------------");
                        goto q;
                    }
                    d = int.Parse(dd);
                    m = int.Parse(mm);
                    y = int.Parse(yy);

                    if (isValidDate(d, m, y) == false)

                    {
                        Console.WriteLine("Invalid");
                        goto q;


                    }

                    a = d.ToString();
                    b = m.ToString();
                    c = y.ToString();

                    date = a + "\\" + b + "\\" + c;

                v:
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Enter new destination: ");
                    Console.WriteLine("----------------------------");
                    destination = Console.ReadLine();
                    char[] destinationchar = destination.ToCharArray();
                    for (int i = 0; i < destination.Length; i++)   //destination validation
                    {
                        if (destinationchar[i] >= 97 && destinationchar[i] <= 122)
                        {
                            continue;
                        }
                        else
                            Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine("!!!You entered an invalid character in name!!! ");
                        Console.WriteLine("-----------------------------------------------");
                        goto v;
                    }


                h:
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Enter new departure");
                    Console.WriteLine("----------------------------");
                    departure = Console.ReadLine();
                    char[] departurechar = departure.ToCharArray();                                     //departure validation
                    for (int i = 0; i < departure.Length; i++)
                    {
                        if (departurechar[i] >= 97 && departurechar[i] <= 122)
                        {
                            continue;
                        }
                        else
                            Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine("!!!You entered an invalid character in name!!! ");
                        Console.WriteLine("-----------------------------------------------");
                        goto h;
                    }


                y:
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Enter new price: ");
                    Console.WriteLine("----------------------------");
                    price1 = Console.ReadLine();
                    char[] pricechar = price1.ToCharArray();
                    int s = price1.Length;                     //price validation
                    for (int i = 0; i < s; i++)
                    {
                        if (!(pricechar[i] >= 48 && pricechar[i] <= 57))
                        {
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine("!!!Invalid.Incorrect type of data!!!");
                            Console.WriteLine("-------------------------------------");
                            goto y;
                        }
                    }
                    price = int.Parse(price1);

                f:
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Enter new seats: ");
                    Console.WriteLine("----------------------------");
                    seatnew1 = Console.ReadLine();
                    char[] seatchar = seatnew1.ToCharArray();
                    int sizen = seatnew1.Length;          //seats validation

                    for (int i = 0; i < sizen; i++)
                    {
                        if (!(seatchar[i] >= 48 && seatchar[i] <= 57))
                        {
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine("!!!Invalid.Incorrect type of data!!!");
                            Console.WriteLine("-------------------------------------");
                            goto f;
                        }
                    }
                    seatnew = int.Parse(seatnew1);          //conversion to int

                    if (validflight(numberofflight, flights) == false)
                    {

                        UpdateFlight(numberofflight, date, destination, departure, price, seatnew, flights);
                        success();
                    }
                    else
                        failure();
                    Console.ReadLine();

                    Console.Clear();
                }
                else if (adminOption == "8")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("     MAKE ANNOUNCEMENTS   ");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.WriteLine("----------------------");
                    Console.WriteLine("Enter message: ");
                    Console.WriteLine("----------------------");

                    string mess = Console.ReadLine();
                    GiveMessage(mess, messages);
                    Console.ReadLine();

                    Console.Clear();
                }
                else if (adminOption == "9")
                {

                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {

                    failure();
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            Console.Clear();
        }
        static void ReadBook(List<Book> books)
        {
            string path = "C:\\Users\\ADMIN\\Desktop\\book.txt";
            if (File.Exists(path))

            {
                int seat = 0, price = 0;
                StreamReader fileVar = new StreamReader(path);
                string record;
                while ((record = fileVar.ReadLine()) != null)
                {
                    string name = GetField(record, 1);
                    string number = GetField(record, 2);
                    string date = GetField(record, 3);
                    string destination = GetField(record, 4);
                    string departure = GetField(record, 5);
                    if (int.TryParse(GetField(record, 6), out int parsedPrice))
                    {
                        price = parsedPrice;
                    }
                    if (int.TryParse(GetField(record, 7), out int parsedSeats))
                    {
                        seat= parsedSeats;
                    }
                    Book booked = new Book(name, number, date, destination, departure, price, seat);
                    books.Add(booked);


                }
                fileVar.Close();
            }

            else
            {
                Console.WriteLine("Does not exist");
            }
        }

        static void Main(string[] args)
        {
            int count = 0;

            List <Message> messages= new List <Message>();
            List<MUser> users = new List<MUser>();
            List<Rate> rates = new List<Rate>();
            List<Flights> flights = new List<Flights>();
            List <Book> books=new List<Book>();
            readData(users,ref count);
            ReadMessage(messages);
            ReadFlight(flights);
            ReadRate(rates);
            ReadBook(books);
            string input = "0", password, role, name;
            while (input != "3")
            {
            k:
                Header();
                Login();
                input = Console.ReadLine();
                if (input == "1")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("----------------------");
                    Console.WriteLine("        Sign in       ");
                    Console.WriteLine("----------------------");

                    Console.ResetColor();
                x: Console.WriteLine("----------------------------");
                    Console.WriteLine("Enter user name: ");
                    Console.WriteLine("----------------------------");
                    string name1 = Console.ReadLine();
                    foreach (char c in name1)
                    {
                        if (!((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')))
                        {
                            goto x; ;
                        }
                    }
                v:
                    Console.WriteLine("--------------------");
                    Console.WriteLine("Enter pin: ");
                    Console.WriteLine("--------------------");
                    password = Console.ReadLine();
                    int size = password.Length;
                    foreach (char c in input)
                    {
                        if (!(c >= '0' && c <= '9'))
                        {
                            goto v;
                        }
                    }
                    if (!(size <= 8))
                    {
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("!!Invalid, limit should be between 1 to 8!!");
                        Console.WriteLine("--------------------------------------");
                        goto v;
                    }

                    role = SignIn(name1, password, users);
                    if (role == "admin")
                    {
                        Console.Clear();
                        Console.Clear();

                        Admininterface(flights,messages,rates,books,ref count);
                        Console.Read();
                    }

                    else if (role == "user")
                    {

                        Console.Clear();
                        Userinterface(rates, messages, name1, flights, books);
                        Console.Read();
                    }
                    else if (role == "none")
                    {
                        Console.Read();
                        Console.Clear();

                        goto k;
                    }
                }
                else if (input == "2")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("----------------------");
                    Console.WriteLine("        Sign up       ");
                    Console.WriteLine("----------------------");
                    Console.WriteLine();
                    Console.ResetColor();

                l:

                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Enter user name:            ");
                    Console.WriteLine("----------------------------");
                   name = Console.ReadLine();
                    char[] nameuser1 = name.ToCharArray();

                    bool isValid = true;

                    for (int i = 0; i < name.Length; i++)
                    {
                        if (!((nameuser1[i] >= 'A' && nameuser1[i] <= 'Z') || (nameuser1[i] >= 'a' && nameuser1[i] <= 'z') || nameuser1[i] == ' '))
                        {
                            isValid = false;
                            break;
                        }
                    }

                    if (!isValid)
                    {
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine("!!!You entered an invalid character in name!!! ");
                        Console.WriteLine("-----------------------------------------------");
                        goto l;
                    }
                    else
                    {
                        Console.WriteLine("Name is valid.");
                        // Continue with the rest of your program
                    }

                b:
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine("Enter password in digits (length should not exceed 8): ");
                    Console.WriteLine("--------------------------------------------------");
                    password = Console.ReadLine();
                    char[] passwrd1 = password.ToCharArray();
                    int sisi = password.Length;
                    for (int i = 0; i < sisi; i++)
                    {
                        if (!(passwrd1[i] >= 48 && passwrd1[i] <= 57))
                        {
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine("!!!Invalid.Incorrect type of data!!!");
                            Console.WriteLine("-------------------------------------");
                            goto b;
                        }
                    }
                    if (!(sisi <= 8))
                    {
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("!!Invalid, limit should not exceed 8!!");
                        Console.WriteLine("--------------------------------------");
                        goto b;
                    }

                c:
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Enter role: (Admin or User)");
                    Console.WriteLine("----------------------------");
                    role = Console.ReadLine();
                    role = LowerString(role);
                    if (role != "admin" && role != "user")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("---------------------");
                        Console.WriteLine(" WRONG DATA ENTERED   ");
                        Console.WriteLine("--------------------");
                        Console.WriteLine();
                        Console.ResetColor();
                        goto c;
                    }

                    if (validuser(name, users, ref count))
                    {
                        signup(name, password, role, users, ref count);
                        success();
                    }

                    else
                        failure();
                    Console.Read();
                    Console.Clear();
                }
                else if (input == "3")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("--------------");
                    Console.WriteLine("   Goodbye !   ");
                    Console.WriteLine("--------------");
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.ResetColor();

                }
                else

                {
                    failure();
                    Console.Read();
                    Console.Clear();
                }
            }
        }

    }
}

