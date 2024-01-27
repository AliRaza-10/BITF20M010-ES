using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITF20M010_Assignment_1
{
    internal class Passenger
    {
        private string name;
        private string phoneNumber;

        public Passenger(string nam, string phone)
        {
            name = nam;
            phoneNumber = phone;
        }
        public void setPassenger(string nam, string phone)
        {
            this.name = nam;
            this.phoneNumber = phone;
        }

        public string getName()
        {
            return name;
        }

        public string getPhoneNumber()
        {
            return phoneNumber;
        }
    }
}
