using MeLi_Forecast.App.Database;
using MeLi_Forecast.Entities.Forecasting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeLi_Forecast.Job
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateData();

            using (var dbContext = new ForecastDbContext())
            {
                dbContext.Database.EnsureCreated();

                var drougthDays = dbContext.ForecastDays.Where(f => f.Weather == "drought").ToList();
                var optimumDays = dbContext.ForecastDays.Where(f => f.Weather == "optimum pressure and temperature").ToList();
                var rainyDays = dbContext.ForecastDays.OrderBy(f => f.Day).Where(f => f.Weather == "rainy" || f.Weather == "lot of rain").ToList();
                var rainiestDay = dbContext.ForecastDays.OrderByDescending(f => f.TrianglePerimeter).First();

                //Get rainy periods
                int rainyPeriods = 0;
                for (int i = 0; i < rainyDays.Count; i++)
                {
                    if(i + 1 < rainyDays.Count)
                    {
                        if (rainyDays.ElementAt(i + 1).Day == (rainyDays.ElementAt(i).Day + 1))
                            rainyPeriods++;
                    }
                }

                Console.WriteLine($"Drought periods: {drougthDays.Count}");
                Console.WriteLine($"Optimum pressure and temperature periods: {optimumDays.Count}");
                Console.WriteLine($"Rainy periods: {rainyPeriods}");
                Console.WriteLine($"Rainiest day: {rainiestDay.Day}");
                Console.ReadKey(true);
            }
        }

        static void GenerateData()
        {
            using (var dbContext = new ForecastDbContext())
            {
                dbContext.Database.EnsureCreated();

                if (!dbContext.ForecastDays.Any())
                {
                    Entities.SolarSystems.MeLi.MeLiSolarSystem meliSolarSystem = new Entities.SolarSystems.MeLi.MeLiSolarSystem();
                    for (int i = 0; i < (365 * 10); i++)
                    {
                        ForecastDay forecastDay = new ForecastDay();
                        forecastDay.Day = i;
                        forecastDay.FerengiPosition = meliSolarSystem.FerengiPlanet.GetPosition(i).ToString();
                        forecastDay.FerengiAngle = meliSolarSystem.FerengiPlanet.GetAngle(i);
                        forecastDay.BetasoidePosition = meliSolarSystem.BetasoidePlanet.GetPosition(i).ToString();
                        forecastDay.BetasoideAngle = meliSolarSystem.BetasoidePlanet.GetAngle(i);
                        forecastDay.VulcanoPosition = meliSolarSystem.VulcanoPlanet.GetPosition(i).ToString();
                        forecastDay.VulcanoAngle = meliSolarSystem.VulcanoPlanet.GetAngle(i);
                        forecastDay.AreAlignedWithTheSun = meliSolarSystem.AreAlignedWithTheSun((uint)i);
                        forecastDay.AreAlignedWithoutTheSun = meliSolarSystem.AreAlignedWithoutTheSun((uint)i);
                        forecastDay.IsSunInside = meliSolarSystem.IsSunInside((uint)i);
                        forecastDay.Weather = meliSolarSystem.GetWeather((uint)i);
                        forecastDay.TrianglePerimeter = meliSolarSystem.GetTrianglePerimeter((uint)i);
                        dbContext.ForecastDays.Add(forecastDay);
                    }
                    dbContext.SaveChanges();
                }
            }
        }
    }
}