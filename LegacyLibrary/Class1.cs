using System;

namespace LegacyLibrary
{

    public class GeoCalculator
    {
        private const double DEGREES_TO_RADIANS = 0.017453292519943295;
        private const double RADIANS_TO_DEGREES = 57.29577951308232;
        private const double EARTH_RADIUS_KM = 6371.0;

        private const double KM_TO_MILES = 0.621371;
        private const double MILES_TO_KM = 1.60934;
        private const double METERS_TO_FEET = 3.28084;
        private const double FEET_TO_METERS = 0.3048;

        private const double HECTARES_TO_ACRES = 2.47105;
        private const double ACRES_TO_HECTARES = 0.404686;

        public double ConvertDegreesToRadians(double degrees)
        {
            return degrees * DEGREES_TO_RADIANS;
        }

        public double CalculateDistanceBetweenPoints(double startLatitude, double startLongitude,
                                                   double endLatitude, double endLongitude)
        {
            double startLatRadians = startLatitude * DEGREES_TO_RADIANS;
            double startLonRadians = startLongitude * DEGREES_TO_RADIANS;
            double endLatRadians = endLatitude * DEGREES_TO_RADIANS;
            double endLonRadians = endLongitude * DEGREES_TO_RADIANS;

            double latitudeDifference = endLatRadians - startLatRadians;
            double longitudeDifference = endLonRadians - startLonRadians;

            double haversineComponent = Math.Sin(latitudeDifference / 2) * Math.Sin(latitudeDifference / 2) +
                                      Math.Cos(startLatRadians) * Math.Cos(endLatRadians) *
                                      Math.Sin(longitudeDifference / 2) * Math.Sin(longitudeDifference / 2);

            double angularDistance = 2 * Math.Atan2(Math.Sqrt(haversineComponent),
                                                   Math.Sqrt(1 - haversineComponent));

            return EARTH_RADIUS_KM * angularDistance;
        }

        public double CalculateBearing(double startLatitude, double startLongitude,
                                     double endLatitude, double endLongitude)
        {
            double startLatRadians = ConvertDegreesToRadians(startLatitude);
            double startLonRadians = ConvertDegreesToRadians(startLongitude);
            double endLatRadians = ConvertDegreesToRadians(endLatitude);
            double endLonRadians = ConvertDegreesToRadians(endLongitude);

            double longitudeDifference = endLonRadians - startLonRadians;
            double yComponent = Math.Sin(longitudeDifference) * Math.Cos(endLatRadians);
            double xComponent = Math.Cos(startLatRadians) * Math.Sin(endLatRadians) -
                              Math.Sin(startLatRadians) * Math.Cos(endLatRadians) *
                              Math.Cos(longitudeDifference);

            double bearingRadians = Math.Atan2(yComponent, xComponent);
            return (bearingRadians * RADIANS_TO_DEGREES + 360) % 360;
        }

        public double KmToMiles(double km) => km * KM_TO_MILES;
        public double MilesToKm(double miles) => miles * MILES_TO_KM;
        public double MetersToFeet(double meters) => meters * METERS_TO_FEET;
        public double FeetToMeters(double feet) => feet * FEET_TO_METERS;
        public double HectaresToAcres(double hectares) => hectares * HECTARES_TO_ACRES;
        public double AcresToHectares(double acres) => acres * ACRES_TO_HECTARES;
    }
}