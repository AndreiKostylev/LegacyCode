using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyLibrary
{
    public interface IGeoCalculator
    {
        double CalculateDistanceBetweenPoints(double startLatitude, double startLongitude,
                                            double endLatitude, double endLongitude);
        double CalculateBearing(double startLatitude, double startLongitude,
                              double endLatitude, double endLongitude);
        double ConvertDegreesToRadians(double degrees);
    }
}
