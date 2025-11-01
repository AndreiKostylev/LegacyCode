using System;
using System.ComponentModel;

namespace LegacyLibrary
{

    public class GeoCalculator : IGeoCalculator, ILengthConverter, IAreaConverter, IUniversalConverter
    {
        private readonly CoordinateCalculator _coordinateCalculator;
        private readonly LengthConverter _lengthConverter;
        private readonly AreaConverter _areaConverter;
        private readonly UniversalConversionService _conversionService;

        public GeoCalculator()
        {
            _coordinateCalculator = new CoordinateCalculator();
            _lengthConverter = new LengthConverter();
            _areaConverter = new AreaConverter();
            _conversionService = new UniversalConversionService(_lengthConverter, _areaConverter);
        }


        public double GetDistance(double lat1, double lon1, double lat2, double lon2)
            => _coordinateCalculator.CalculateDistanceBetweenPoints(lat1, lon1, lat2, lon2);

        public double GetAzimuth(double lat1, double lon1, double lat2, double lon2)
            => _coordinateCalculator.CalculateBearing(lat1, lon1, lat2, lon2);

        public double ToRadians(double deg)
            => _coordinateCalculator.ConvertDegreesToRadians(deg);

        public double KmToMiles(double km)
            => _lengthConverter.ConvertKilometersToMiles(km);

        public double MilesToKm(double miles)
            => _lengthConverter.ConvertMilesToKilometers(miles);

        public double MetersToFeet(double m)
            => _lengthConverter.ConvertMetersToFeet(m);

        public double FeetToMeters(double ft)
            => _lengthConverter.ConvertFeetToMeters(ft);
        public double HectaresToAcres(double ha)
            => _areaConverter.ConvertHectaresToAcres(ha);

        public double AcresToHectares(double acres)
            => _areaConverter.ConvertAcresToHectares(acres);
        public double Convert(string from, string to, double val)
            => _conversionService.Convert(from, to, val);
        public double CalculateDistanceBetweenPoints(double startLatitude, double startLongitude,
                                                   double endLatitude, double endLongitude)
            => _coordinateCalculator.CalculateDistanceBetweenPoints(startLatitude, startLongitude,
                                                                  endLatitude, endLongitude);

        public double CalculateBearing(double startLatitude, double startLongitude,
                                     double endLatitude, double endLongitude)
            => _coordinateCalculator.CalculateBearing(startLatitude, startLongitude,
                                                    endLatitude, endLongitude);

        public double ConvertDegreesToRadians(double degrees)
            => _coordinateCalculator.ConvertDegreesToRadians(degrees);

        public double ConvertKilometersToMiles(double kilometers)
            => _lengthConverter.ConvertKilometersToMiles(kilometers);

        public double ConvertMilesToKilometers(double miles)
            => _lengthConverter.ConvertMilesToKilometers(miles);

        public double ConvertMetersToFeet(double meters)
            => _lengthConverter.ConvertMetersToFeet(meters);

        public double ConvertFeetToMeters(double feet)
            => _lengthConverter.ConvertFeetToMeters(feet);

        public double ConvertHectaresToAcres(double hectares)
            => _areaConverter.ConvertHectaresToAcres(hectares);

        public double ConvertAcresToHectares(double acres)
            => _areaConverter.ConvertAcresToHectares(acres);
    }
}