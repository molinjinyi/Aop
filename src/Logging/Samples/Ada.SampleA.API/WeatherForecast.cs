using System;

namespace Ada.SampleA.API
{
    /// <summary>
    /// ��⺆��
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// ����  
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// �A��
        /// </summary>
        public int TemperatureC { get; set; }
        /// <summary>
        /// �z��
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// ����
        /// </summary>
        public string Summary { get; set; }
    }
}
