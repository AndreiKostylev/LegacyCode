using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyLibrary
{
    public class LengthConverter : ILengthConverter
    {
        private const double KM_TO_MILES = 0.621371;
        private const double MILES_TO_KM = 1.60934;
        private const double METERS_TO_FEET = 3.28084;
        private const double FEET_TO_METERS = 0.3048;

        public double ConvertKilometersToMiles(double kilometers)
        {
            ValidatePositiveValue(kilometers, nameof(kilometers));
            return kilometers * KM_TO_MILES;
        }

        public double ConvertMilesToKilometers(double miles)
        {
            ValidatePositiveValue(miles, nameof(miles));
            return miles * MILES_TO_KM;
        }

        public double ConvertMetersToFeet(double meters)
        {
            ValidatePositiveValue(meters, nameof(meters));
            return meters * METERS_TO_FEET;
        }

        public double ConvertFeetToMeters(double feet)
        {
            ValidatePositiveValue(feet, nameof(feet));
            return feet * FEET_TO_METERS;
        }

        private void ValidatePositiveValue(double value, string parameterName)
        {
            if (value < 0)
                throw new ArgumentException($"{parameterName} не может быть отрицательным", parameterName);
        }
    }
}
