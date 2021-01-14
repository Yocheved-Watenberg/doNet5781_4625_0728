using System;

namespace BL
{
    internal class GeoCoordinate
    {
        private double longitude;
        private double latitude;

        public GeoCoordinate(double longitude, double latitude)
        {
            this.longitude = longitude;
            this.latitude = latitude;
        }

        internal double GetDistanceTo(GeoCoordinate eCoord)
        {
            return Math.Sqrt((Math.Pow(longitude - eCoord.longitude, 2)) + (Math.Pow(latitude - eCoord.latitude, 2)));
        }
    }
}