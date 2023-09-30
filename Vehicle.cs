using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITF20M010_Assignment_1
{
    internal class Vehicle
    {
        private string type;
        private string model;
        private string licencePlate;

        public Vehicle(string typ, string mod, string plate)
        {
            type = typ;
            model = mod;
            licencePlate = plate;
        }

        public string getType()
        {
            return type;
        }
        public string getModel()
        {
            return model;
        }
        public string getLicence()
        {
            return licencePlate;
        }

        
        public void setType(string typ)
        {
            type = typ;
        }
        public void setModel(string mod)
        {
            model = mod;
        }
        public void setLicencePlate(string plate)
        {
            licencePlate = plate;
        }
    }
}
