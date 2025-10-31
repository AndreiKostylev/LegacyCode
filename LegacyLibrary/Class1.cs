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

        public double ToRadians(double deg)
        {
            return deg * DEGREES_TO_RADIANS;
        }

        public double GetDistance(double lat1, double lon1, double lat2, double lon2)
        {
            double rlat1 = lat1 * DEGREES_TO_RADIANS;
            double rlon1 = lon1 * DEGREES_TO_RADIANS;
            double rlat2 = lat2 * DEGREES_TO_RADIANS;
            double rlon2 = lon2 * DEGREES_TO_RADIANS;

            double dlat = rlat2 - rlat1;
            double dlon = rlon2 - rlon1;
            double a = Math.Sin(dlat / 2) * Math.Sin(dlat / 2) +
                      Math.Cos(rlat1) * Math.Cos(rlat2) *
                      Math.Sin(dlon / 2) * Math.Sin(dlon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return EARTH_RADIUS_KM * c;
        }

        public double GetAzimuth(double lat1, double lon1, double lat2, double lon2)
        {
            double rlat1 = ToRadians(lat1);
            double rlon1 = ToRadians(lon1);
            double rlat2 = ToRadians(lat2);
            double rlon2 = ToRadians(lon2);

            double dlon = rlon2 - rlon1;
            double y = Math.Sin(dlon) * Math.Cos(rlat2);
            double x = Math.Cos(rlat1) * Math.Sin(rlat2) -
                      Math.Sin(rlat1) * Math.Cos(rlat2) * Math.Cos(dlon);

            double azimuthRadians = Math.Atan2(y, x);
            return (azimuthRadians * RADIANS_TO_DEGREES + 360) % 360;
        }

        public double KmToMiles(double km) => km * KM_TO_MILES;
        public double MilesToKm(double miles) => miles * MILES_TO_KM;
        public double MetersToFeet(double meters) => meters * METERS_TO_FEET;
        public double FeetToMeters(double feet) => feet * FEET_TO_METERS;
        public double HectaresToAcres(double hectares) => hectares * HECTARES_TO_ACRES;
        public double AcresToHectares(double acres) => acres * ACRES_TO_HECTARES;
    }
}