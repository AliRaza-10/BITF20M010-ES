using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITF20M010_Assignment_1
{
    internal class Driver
    {
        private int ID;
        private string name;
        private int age;
        private string gender;
        private string address;
        private string phoneNumber;
        private Location currentLocation;
        private Vehicle vehicle;
        private List<int> rating;
        private int ratingsCount;
        private bool availability;

        public Driver(string nam, int ag, string gend, string addrs, string phone, Location loc, Vehicle veh, bool avail)
        {
            ID = Admin.getUniqueID();
            name = nam;
            age = ag;
            gender = gend;
            address = addrs;
            phoneNumber = phone;
            currentLocation = loc;
            vehicle = veh;
            availability = avail;
            rating = new List<int>();
            ratingsCount = 0;
        }

 
        public int getID()
        {
            return this.ID;
        }

        public string getVehicleType()
        {
            return vehicle.getType();
        }

        public bool getAvailability()
        {
            return this.availability;
        }

        public string getName()
        {
            return name;
        }

        public int getAge()
        {
            return age;
        }

        public string getGender()
        {
            return gender;
        }

        public string getModel()
        {
            return vehicle.getModel();
        }

        public string getLicence()
        {
            return vehicle.getLicence();
        }

        public int getRating()
        {
            int listSize = rating.Count;
            int totalRating = 0;
            foreach (int ratingItem in rating)
            {
                totalRating += ratingItem;
            }
            return totalRating / listSize;
        }

        public Location getCurrentLocation()
        {
            return currentLocation;
        }

       
        public void setAge(int a)
        {
            age = a;
        }

        public void setVehicle(string typ, string mod, string plate)
        {
            vehicle.setType(typ);
            vehicle.setModel(mod);
            vehicle.setLicencePlate(plate);
        }

        
        public void updateAvailability()
        {
            if (availability)
            {
                availability = false;
            }
            else
            {
                availability = true;
            }

            Console.WriteLine("Availability Changed !!!");
        }

        
        public void updateLocation(float lat, float lon)
        {
            currentLocation.setLocation(lat, lon);
        }

        public void addRatings(int rate)
        {
            rating.Add(rate);
            ratingsCount++;
        }
    }
}
