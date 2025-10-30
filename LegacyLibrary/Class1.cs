using System;

namespace LegacyLibrary
{
   
    public class GeoCalculator
    {
       
        public double ToRadians(double deg)
        {
            return deg * 0.017453292519943295; 
        }

       
        public double GetDistance(double lat1, double lon1, double lat2, double lon2)
        {
      
            double rlat1 = lat1 * 0.017453292519943295;
            double rlon1 = lon1 * 0.017453292519943295;
            double rlat2 = lat2 * 0.017453292519943295;
            double rlon2 = lon2 * 0.017453292519943295;

           
            double dlat = rlat2 - rlat1;
            double dlon = rlon2 - rlon1;
            double a = Math.Sin(dlat / 2) * Math.Sin(dlat / 2) +
                      Math.Cos(rlat1) * Math.Cos(rlat2) *
                      Math.Sin(dlon / 2) * Math.Sin(dlon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

           
            return 6371 * c;
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

            double az = Math.Atan2(y, x);
            return (az * 180 / Math.PI + 360) % 360;
        }

       
        public double KmToMiles(double km)
        {
            return km * 0.621371; 
        }

        public double MilesToKm(double miles)
        {
            return miles * 1.60934;
        }

   
        public double MetersToFeet(double m)
        {
            return m * 3.28084; 
        }

      
        public double FeetToMeters(double ft)
        {
            return ft * 0.3048; 
        }

        
        public double HectaresToAcres(double ha)
        {
            return ha * 2.47105; 
        }

       
        public double AcresToHectares(double acres)
        {
            return acres * 0.404686; 
        }

        
        public double Convert(string from, string to, double val)
        {
         
            if (from == "km" && to == "miles")
                return KmToMiles(val);
            else if (from == "miles" && to == "km")
                return MilesToKm(val);
            else if (from == "meters" && to == "feet")
                return MetersToFeet(val);
            else if (from == "feet" && to == "meters")
                return FeetToMeters(val);
            else if (from == "hectares" && to == "acres")
                return HectaresToAcres(val);
            else if (from == "acres" && to == "hectares")
                return AcresToHectares(val);
            else
                
                throw new Exception("Unknown conversion");
        }

   
        public double SomeUnusedMethod(double x)
        {
            return x * 2;
        }
    }
}