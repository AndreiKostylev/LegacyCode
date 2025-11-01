using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyLibrary
{
    public interface ILengthConverter
    {
        double ConvertKilometersToMiles(double kilometers);
        double ConvertMilesToKilometers(double miles);
        double ConvertMetersToFeet(double meters);
        double ConvertFeetToMeters(double feet);
    }
}
