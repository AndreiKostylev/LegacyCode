using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyLibrary
{
    public class CoordinateCalculator : IGeoCalculator
    {
        private const double DEGREES_TO_RADIANS = 0.017453292519943295;
        private const double RADIANS_TO_DEGREES = 57.29577951308232;
        private const double EARTH_RADIUS_KM = 6371.0;

        public double CalculateDistanceBetweenPoints(double startLatitude, double startLongitude,
                                                   double endLatitude, double endLongitude)
        {
            ValidateCoordinates(startLatitude, startLongitude, endLatitude, endLongitude);

            double startLatRadians = ConvertDegreesToRadians(startLatitude);
            double startLonRadians = ConvertDegreesToRadians(startLongitude);
            double endLatRadians = ConvertDegreesToRadians(endLatitude);
            double endLonRadians = ConvertDegreesToRadians(endLongitude);

            return CalculateHaversineDistance(startLatRadians, startLonRadians,
                                            endLatRadians, endLonRadians);
        }

        public double CalculateBearing(double startLatitude, double startLongitude,
                                     double endLatitude, double endLongitude)
        {
            ValidateCoordinates(startLatitude, startLongitude, endLatitude, endLongitude);

            double startLatRadians = ConvertDegreesToRadians(startLatitude);
            double startLonRadians = ConvertDegreesToRadians(startLongitude);
            double endLatRadians = ConvertDegreesToRadians(endLatitude);
            double endLonRadians = ConvertDegreesToRadians(endLongitude);

            return CalculateBearingRadians(startLatRadians, startLonRadians,
                                         endLatRadians, endLonRadians);
        }

        public double ConvertDegreesToRadians(double degrees)
        {
            return degrees * DEGREES_TO_RADIANS;
        }

        private double CalculateHaversineDistance(double startLatRad, double startLonRad,
                                                double endLatRad, double endLonRad)
        {
            double latitudeDifference = endLatRad - startLatRad;
            double longitudeDifference = endLonRad - startLonRad;

            double haversineComponent = CalculateHaversineComponent(startLatRad, endLatRad,
                                                                  latitudeDifference, longitudeDifference);

            double angularDistance = 2 * Math.Atan2(Math.Sqrt(haversineComponent),
                                                   Math.Sqrt(1 - haversineComponent));

            return EARTH_RADIUS_KM * angularDistance;
        }

        private double CalculateHaversineComponent(double startLatRad, double endLatRad,
                                                 double latDiff, double lonDiff)
        {
            return Math.Sin(latDiff / 2) * Math.Sin(latDiff / 2) +
                   Math.Cos(startLatRad) * Math.Cos(endLatRad) *
                   Math.Sin(lonDiff / 2) * Math.Sin(lonDiff / 2);
        }

        private double CalculateBearingRadians(double startLatRad, double startLonRad,
                                             double endLatRad, double endLonRad)
        {
            double longitudeDifference = endLonRad - startLonRad;
            double yComponent = Math.Sin(longitudeDifference) * Math.Cos(endLatRad);
            double xComponent = Math.Cos(startLatRad) * Math.Sin(endLatRad) -
                              Math.Sin(startLatRad) * Math.Cos(endLatRad) *
                              Math.Cos(longitudeDifference);

            double bearingRadians = Math.Atan2(yComponent, xComponent);
            return (bearingRadians * RADIANS_TO_DEGREES + 360) % 360;
        }

        private void ValidateCoordinates(double startLat, double startLon, double endLat, double endLon)
        {
            if (Math.Abs(startLat) > 90 || Math.Abs(endLat) > 90)
                throw new ArgumentException("Широта должна быть между -90 и 90 градусами");

            if (Math.Abs(startLon) > 180 || Math.Abs(endLon) > 180)
                throw new ArgumentException("Долгота должна быть между -180 и 180 градусами");
        }
    }
}
