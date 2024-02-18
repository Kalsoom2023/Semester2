using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemNo1.bl
{
    public class Angle
    {


        public int degree;
        public float min;
        public char direction;
        public Angle(int degree, float min, char direction)
        {
            this.degree = degree;
            this.min = min;
            this.direction = direction;
        }
        public string setString()
        {
            return degree + "\u00b0" + min + "'" + direction;
        }


    }
    public class Ship
    {
        public string number;
        public Angle latitude, longitude;
        public Ship(string number, Angle latitude, Angle longitude)
        {
            this.number = number;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public void printSerial()
        {
            Console.WriteLine("Ship serial Number is:" + number);
        }
        public void printPosition()
        {
            Console.WriteLine("Ship is at " + latitude.setString() + " And " + longitude.setString());
        }
        public void ChangePosition(Angle newLatitude, Angle newLongitude)
        {
            latitude = newLatitude;
            longitude = newLongitude;
            Console.WriteLine("Ship's position updated successfully.");
        }
    }
}