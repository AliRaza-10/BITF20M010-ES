using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITF20M010_Assignment_1
{
    internal class Location
    {
        private float latitude;
        private float longitude;
        public Location()
        {
            latitude = 0;
            longitude = 0;
        }
        public Location(float lat, float lon)
        {
            latitude = lat;
            longitude = lon;
        }

        public float[] getLocation()
        {
            return new float[] { this.latitude, this.longitude };
        }

      
        public void setLocation(float lat, float lon)
        {
            this.latitude = lat;
            this.longitude = lon;
        }
    }
}
