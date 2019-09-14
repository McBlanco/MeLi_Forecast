using System;
using System.ComponentModel.DataAnnotations;

namespace MeLi_Forecast.Entities.Forecasting
{
    public class ForecastDay
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Day { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(128)]
        public string Weather { get; set; }
    }
}
