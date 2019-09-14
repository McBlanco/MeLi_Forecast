using System;
using System.Collections.Generic;
using System.Linq;
using MeLi_Forecast.App.Database;
using MeLi_Forecast.Entities.Forecasting;
using Microsoft.AspNetCore.Mvc;

namespace MeLi_Forecast.App.Controllers
{
    [Route("api/[controller]")]
    public class ForecastController : Controller
    {
        [HttpGet]
        public IEnumerable<ForecastDay> Get()
        {
            List<ForecastDay> result = new List<ForecastDay>();

            using (var dbContext = new ForecastDbContext())
            {
                dbContext.Database.EnsureCreated();

                if (!dbContext.ForecastDays.Any())
                {
                    dbContext.ForecastDays.AddRange(new ForecastDay[]
                        {
                             new ForecastDay{ Weather="Sunny", Day=1, Date=DateTime.Now },
                             new ForecastDay{ Weather="Cloudy", Day=2, Date=DateTime.Now },
                             new ForecastDay{ Weather="Windy", Day=3, Date=DateTime.Now }
                        });
                    dbContext.SaveChanges();
                }

                foreach(ForecastDay forecastDay in dbContext.ForecastDays)
                {
                    result.Add(forecastDay);
                }
            }

            return result;
        }
    }
}
