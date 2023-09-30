using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITF20M010_Assignment_1
{
    internal class Ride
    {
        private Location startLocation;
        private Location endLocation;
        private float price = 0;
        private Driver driver;
        private Passenger passenger;

        public void assignPassenger(string nam, string phone)
        {
            passenger = new Passenger(nam, phone);
        }

        public void assignDriver(Driver d)
        {
            driver = d;
        }

        public void setLocations(Location startLoc, Location endLoc)
        {
            startLocation = startLoc;
            endLocation = endLoc;
        }

        public float calculatePrice(string vehicle)
        {
            float num1 = ((float)endLocation.getLocation()[0] - (float)startLocation.getLocation()[0]) * ((float)endLocation.getLocation()[0] - (float)startLocation.getLocation()[0]);
            float num2 = ((float)endLocation.getLocation()[1] - (float)startLocation.getLocation()[1]) * ((float)endLocation.getLocation()[1] - (float)startLocation.getLocation()[1]);

            float distance = (float)Math.Sqrt(num2 + num1);
            float fuelPrice = 335;
            if (vehicle == "bike" || vehicle== "Bike")
            {
                price = ((distance * fuelPrice) / 50);
                price = price + price / 20;
                return price;
            }

            else if (vehicle == "rickshaw" || vehicle == "Rickshaw")
            {
                price = ((distance * fuelPrice) / 35);
                price = price + price / 10;
                return price;
            }

            else
            {
                price = ((distance * fuelPrice) / 15);
                price = price + price / 5;
                return price;
            }
        }

        public bool bookRide(Location startLoc, Location endLoc, Passenger pas, string vehicleType)
        {
            Driver dr = Admin.giveNearestDriver(startLoc, vehicleType);
            if (dr == null)
            {
                return false;
            }

            passenger = pas;
            driver = dr;
            startLocation = startLoc;
            endLocation = endLoc;

            return true;
        }

        public void addDriversRating(int rating)
        {
            driver.addRatings(rating);
        }

    }
}
