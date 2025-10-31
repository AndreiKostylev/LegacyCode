using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyLibrary
{
    public class UniversalConversionService : IUniversalConverter
    {
        private readonly ILengthConverter _lengthConverter;
        private readonly IAreaConverter _areaConverter;

        private readonly Dictionary<string, Func<double, double>> _conversionMap;

        public UniversalConversionService(ILengthConverter lengthConverter, IAreaConverter areaConverter)
        {
            _lengthConverter = lengthConverter;
            _areaConverter = areaConverter;

            _conversionMap = new Dictionary<string, Func<double, double>>
            {
                ["km_to_miles"] = _lengthConverter.ConvertKilometersToMiles,
                ["miles_to_km"] = _lengthConverter.ConvertMilesToKilometers,
                ["meters_to_feet"] = _lengthConverter.ConvertMetersToFeet,
                ["feet_to_meters"] = _lengthConverter.ConvertFeetToMeters,
                ["hectares_to_acres"] = _areaConverter.ConvertHectaresToAcres,
                ["acres_to_hectares"] = _areaConverter.ConvertAcresToHectares
            };
        }

        public double Convert(string fromUnit, string toUnit, double value)
        {
            string conversionKey = $"{fromUnit.ToLower()}_to_{toUnit.ToLower()}";

            if (_conversionMap.ContainsKey(conversionKey))
            {
                return _conversionMap[conversionKey](value);
            }

            throw new ArgumentException($"Неизвестная конвертация: из '{fromUnit}' в '{toUnit}'");
        }
    }
}
