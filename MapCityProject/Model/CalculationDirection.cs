using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapCityProject.Model
{
    internal class CalculationDirection
    {
        public double CalculateDistance(float[] startCoordinates, float[] endCoordinates)
        {
            double R = 6371; // Radius of the Earth in meters
            double lat1 = DegreesToRadians(startCoordinates[0]);
            double lat2 = DegreesToRadians(endCoordinates[0]);
            double deltaLat = DegreesToRadians(endCoordinates[0] - startCoordinates[0]);
            double deltaLon = DegreesToRadians(endCoordinates[1] - startCoordinates[1]);
            double a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = R * c; // in meters
            return distance;
        }
        private double DegreesToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }
    }
}
