using System;
using System.ComponentModel.DataAnnotations;

namespace MeLi_Forecast.Entities.Forecasting
{
    public class ForecastDay
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double Day { get; set; }

        [Required]
        public string FerengiPosition { get; set; }

        [Required]
        public double FerengiAngle { get; set; }

        [Required]
        public string BetasoidePosition { get; set; }

        [Required]
        public double BetasoideAngle { get; set; }

        [Required]
        public string VulcanoPosition { get; set; }

        [Required]
        public double VulcanoAngle { get; set; }

        [Required]
        public double TrianglePerimeter { get; set; }

        [Required]
        public bool AreAlignedWithTheSun { get; set; }

        [Required]
        public bool AreAlignedWithoutTheSun { get; set; }

        [Required]
        public bool IsSunInside { get; set; }

        [Required]
        [MaxLength(128)]
        public string Weather { get; set; }
    }
}
