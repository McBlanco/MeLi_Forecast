using System;

namespace MeLi_Forecast.Job
{
    class Program
    {
        static void Main(string[] args)
        {
            Entities.SolarSystems.MeLi.MeLiSolarSystem meliSolarSystem = new Entities.SolarSystems.MeLi.MeLiSolarSystem();

            for (uint day = 0; day < 1000; day++)
            {
                Console.WriteLine($"Day {day}");
                Console.WriteLine($"Vulcano Position {meliSolarSystem.VulcanoPlanet.GetPosition(meliSolarSystem.VulcanoPlanet.GetAngle(day))}, Angle {meliSolarSystem.VulcanoPlanet.GetAngle(day)}");
                Console.WriteLine($"Ferengi Position {meliSolarSystem.FerengiPlanet.GetPosition(meliSolarSystem.FerengiPlanet.GetAngle(day))}, Angle {meliSolarSystem.FerengiPlanet.GetAngle(day)}");
                Console.WriteLine($"Betasoide Position {meliSolarSystem.BetasoidePlanet.GetPosition(meliSolarSystem.BetasoidePlanet.GetAngle(day))}, Angle {meliSolarSystem.BetasoidePlanet.GetAngle(day)}");
                Console.WriteLine($"Are aligned with the sun: {meliSolarSystem.AreAlignedWithTheSun(day)}");
                Console.WriteLine($"Are alighned without the sun: {meliSolarSystem.AreAlignedWithoutTheSun(day)}");
                Console.WriteLine($"Are aligned with sun inside: {meliSolarSystem.AreAlignedWithSunInside(day)}");
                Console.WriteLine($"Is sun incenter: {meliSolarSystem.IsSunIncenter(day)}");
                Console.ReadKey(true);
            }
        }

    }
}
