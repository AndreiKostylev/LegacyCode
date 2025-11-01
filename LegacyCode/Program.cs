
using System;
using GeoLibrary;
using LegacyLibrary;

namespace GeoLibrary.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== GeoLibrary Демонстрация ===\n");

            var calculator = new GeoCalculator();
            var coordinateCalculator = new CoordinateCalculator();
            var lengthConverter = new LengthConverter();
            var areaConverter = new AreaConverter();

            DemonstrateCoordinateCalculations(calculator);
            DemonstrateCoordinateCalculationsNew(coordinateCalculator);
            DemonstrateLengthConversions(calculator);
            DemonstrateLengthConversionsNew(lengthConverter);
            DemonstrateAreaConversions(calculator);
            DemonstrateAreaConversionsNew(areaConverter);
            DemonstrateUniversalConverter(calculator);
            DemonstrateValidationIssues(calculator);

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void DemonstrateCoordinateCalculations(GeoCalculator calculator)
        {
            Console.WriteLine("1. Расчет координат (старый API):");

            try
            {
                double moscowLat = 55.7558;
                double moscowLon = 37.6173;
                double spbLat = 59.9343;
                double spbLon = 30.3351;

                double distance = calculator.GetDistance(moscowLat, moscowLon, spbLat, spbLon);
                double azimuth = calculator.GetAzimuth(moscowLat, moscowLon, spbLat, spbLon);

                Console.WriteLine($"   Москва → Санкт-Петербург:");
                Console.WriteLine($"     Расстояние: {distance:F2} км");
                Console.WriteLine($"     Азимут: {azimuth:F2}°");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   Ошибка при расчете координат: {ex.Message}");
            }

            Console.WriteLine();
        }

        static void DemonstrateCoordinateCalculationsNew(CoordinateCalculator calculator)
        {
            Console.WriteLine("2. Расчет координат (новый API):");

            try
            {
                double moscowLatitude = 55.7558;
                double moscowLongitude = 37.6173;
                double stPetersburgLatitude = 59.9343;
                double stPetersburgLongitude = 30.3351;

                double distance = calculator.CalculateDistanceBetweenPoints(
                    moscowLatitude, moscowLongitude, stPetersburgLatitude, stPetersburgLongitude);

                double bearing = calculator.CalculateBearing(
                    moscowLatitude, moscowLongitude, stPetersburgLatitude, stPetersburgLongitude);

                Console.WriteLine($"   Москва → Санкт-Петербург:");
                Console.WriteLine($"     Расстояние: {distance:F2} км");
                Console.WriteLine($"     Азимут: {bearing:F2}°");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   Ошибка при расчете координат: {ex.Message}");
            }

            Console.WriteLine();
        }

        static void DemonstrateLengthConversions(GeoCalculator calculator)
        {
            Console.WriteLine("3. Конвертация длины (старый API):");

            try
            {
                double kilometers = 100;
                double meters = 1000;

                double kilometersToMiles = calculator.KmToMiles(kilometers);
                double metersToFeet = calculator.MetersToFeet(meters);

                Console.WriteLine($"   {kilometers} км = {kilometersToMiles:F2} миль");
                Console.WriteLine($"   {meters} метров = {metersToFeet:F2} футов");

                double milesToKm = calculator.MilesToKm(kilometersToMiles);
                double feetToMeters = calculator.FeetToMeters(metersToFeet);

                Console.WriteLine($"   Обратная проверка:");
                Console.WriteLine($"     {kilometersToMiles:F2} миль = {milesToKm:F2} км");
                Console.WriteLine($"     {metersToFeet:F2} футов = {feetToMeters:F2} метров");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   Ошибка при конвертации длины: {ex.Message}");
            }

            Console.WriteLine();
        }

        static void DemonstrateLengthConversionsNew(LengthConverter converter)
        {
            Console.WriteLine("4. Конвертация длины (новый API):");

            try
            {
                double kilometers = 100;
                double meters = 1000;

                double kilometersToMiles = converter.ConvertKilometersToMiles(kilometers);
                double metersToFeet = converter.ConvertMetersToFeet(meters);

                Console.WriteLine($"   {kilometers} км = {kilometersToMiles:F2} миль");
                Console.WriteLine($"   {meters} метров = {metersToFeet:F2} футов");

                double milesToKm = converter.ConvertMilesToKilometers(kilometersToMiles);
                double feetToMeters = converter.ConvertFeetToMeters(metersToFeet);

                Console.WriteLine($"   Обратная проверка:");
                Console.WriteLine($"     {kilometersToMiles:F2} миль = {milesToKm:F2} км");
                Console.WriteLine($"     {metersToFeet:F2} футов = {feetToMeters:F2} метров");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   Ошибка при конвертации длины: {ex.Message}");
            }

            Console.WriteLine();
        }

        static void DemonstrateAreaConversions(GeoCalculator calculator)
        {
            Console.WriteLine("5. Конвертация площади (старый API):");

            try
            {
                double hectares = 50;
                double acres = calculator.HectaresToAcres(hectares);
                double backToHectares = calculator.AcresToHectares(acres);

                Console.WriteLine($"   {hectares} гектаров = {acres:F2} акров");
                Console.WriteLine($"   Обратная проверка:");
                Console.WriteLine($"     {acres:F2} акров = {backToHectares:F2} гектаров");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   Ошибка при конвертации площади: {ex.Message}");
            }

            Console.WriteLine();
        }

        static void DemonstrateAreaConversionsNew(AreaConverter converter)
        {
            Console.WriteLine("6. Конвертация площади (новый API):");

            try
            {
                double hectares = 50;
                double acres = converter.ConvertHectaresToAcres(hectares);
                double backToHectares = converter.ConvertAcresToHectares(acres);

                Console.WriteLine($"   {hectares} гектаров = {acres:F2} акров");
                Console.WriteLine($"   Обратная проверка:");
                Console.WriteLine($"     {acres:F2} акров = {backToHectares:F2} гектаров");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   Ошибка при конвертации площади: {ex.Message}");
            }

            Console.WriteLine();
        }

        static void DemonstrateUniversalConverter(GeoCalculator calculator)
        {
            Console.WriteLine("7. Универсальный конвертер:");

            try
            {
                double kmToMiles = calculator.Convert("km", "miles", 100);
                double hectaresToAcres = calculator.Convert("hectares", "acres", 10);

                Console.WriteLine($"   100 км → {kmToMiles:F2} миль");
                Console.WriteLine($"   10 гектаров → {hectaresToAcres:F2} акров");

                Console.WriteLine("   Попытка неизвестной конвертации...");
                double unknownConversion = calculator.Convert("unknown", "miles", 100);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   Ошибка при универсальной конвертации: {ex.Message}");
            }

            Console.WriteLine();
        }

        static void DemonstrateValidationIssues(GeoCalculator calculator)
        {
            Console.WriteLine("8. Тестирование валидации:");

            try
            {
                Console.WriteLine("   Тест с невалидными координатами (широта 200°):");
                double invalidDistance = calculator.GetDistance(200, 500, 100, 200);
                Console.WriteLine($"     Результат: {invalidDistance:F2} км");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"     Ошибка: {ex.Message}");
            }

            try
            {
                Console.WriteLine("   Тест с отрицательными значениями:");
                double negativeResult = calculator.KmToMiles(-100);
                Console.WriteLine($"     Результат: {negativeResult:F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"     Ошибка: {ex.Message}");
            }

            Console.WriteLine();
        }
    }
}