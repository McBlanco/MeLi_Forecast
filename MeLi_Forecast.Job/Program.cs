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
                        dbContext.ForecastDays.Add(forecastDay);
                    }
                    dbContext.SaveChanges();
                }
            }
        }
    }
}