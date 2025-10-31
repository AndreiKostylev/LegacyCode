using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyLibrary
{
    public class AreaConverter : IAreaConverter
    {
        private const double HECTARES_TO_ACRES = 2.47105;
        private const double ACRES_TO_HECTARES = 0.404686;

        public double ConvertHectaresToAcres(double hectares)
        {
            ValidatePositiveValue(hectares, nameof(hectares));
            return hectares * HECTARES_TO_ACRES;
        }

        public double ConvertAcresToHectares(double acres)
        {
            ValidatePositiveValue(acres, nameof(acres));
            return acres * ACRES_TO_HECTARES;
        }

        private void ValidatePositiveValue(double value, string parameterName)
        {
            if (value < 0)
                throw new ArgumentException($"{parameterName} не может быть отрицательным", parameterName);
        }
    }
}
