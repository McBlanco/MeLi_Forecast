using System;
using System.Collections.Generic;
using System.Linq;
using MeLi_Forecast.App.Database;
using MeLi_Forecast.Entities;
using MeLi_Forecast.Entities.Forecasting;
using Microsoft.AspNetCore.Mvc;

namespace MeLi_Forecast.App.Controllers
{
    [Route("api/[controller]")]
    public class ForecastController : Controller
    {
        [HttpGet]
        public ForecastDay Get(uint day)
        {
            ForecastDay result;

            using (var dbContext = new ForecastDbContext())
            {
                dbContext.Database.EnsureCreated();

                result = dbContext.ForecastDays.FirstOrDefault(f => f.Day == day);
                if (result == null)
                    result = new ForecastDay();
            }

            return result;
        }
    }
}
