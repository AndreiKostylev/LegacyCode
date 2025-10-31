using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyLibrary
{
    public interface IAreaConverter
    {
        double ConvertHectaresToAcres(double hectares);
        double ConvertAcresToHectares(double acres);
    }
}
