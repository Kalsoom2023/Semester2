using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check.data
{
        public class MUser
        {
            public MUser(string username, string password, string role)
            {
                Username = username;
                Password = password;
                Role = role;
            }
        public string LowerString(string role)
        {
            string smaller = role.ToLower();

            return smaller;
        }
        public string Username;
            public string Password;
            public string Role;

        }
        
        public class Message
        {
            public Message(string message)
            {
                 messageData = message;
            }
            public string messageData;
        }
    public class Rate
    {
        public Rate(string names,string rates)
        {
            name = names;
            rating= rates;
        }
        public string name;
        public string rating;
    }
    public class Flights
    {
        public Flights(string flightno, string flightdate, string flightdestination, string flightdeparture, int flightprice, int flightseats)
        {
            flightNo = flightno;
            flightDate = flightdate;
            flightDeparture = flightdeparture;
            flightDestination = flightdestination;
            flightPrice = flightprice;
            flightSeats = flightseats;
        }
        public bool isValidDate(int dd, int mm, int yy)
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
        public string flightNo;
        public string flightDate;
        public string flightDeparture;
        public string flightDestination;
        public int flightPrice;
        public int flightSeats;



    }
    public class Book
    {
        public Book(string names,string numbers,string dates,string dep,string des,int p,int s)
        {
            name = names;
            bookednumber= numbers;
            bookeddate= dates;
            bookeddestination= des;
            bookeddeparture= dep;
            bookedprice = p;
            bookedseats= s;
        }
        public string name;
        public string bookednumber;
        public string bookeddate;
        public string bookeddestination;
        public string bookeddeparture;
        public int bookedprice;
        public int bookedseats;
    }
    }




