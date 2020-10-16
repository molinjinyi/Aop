using System;

namespace Ada.SampleA.API
{
    /// <summary>
    /// Ììšâº†½é
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// ÈÕÆÚ  
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// ÈAÊÏ
        /// </summary>
        public int TemperatureC { get; set; }
        /// <summary>
        /// ”zÊÏ
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// º†½é
        /// </summary>
        public string Summary { get; set; }
    }
}
