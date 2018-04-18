using System;

namespace AccuWeather.API
{
    public class WeatherResponseModel
    {
        public DateTime LocalObservationDateTime { get; set; }
        public int EpochTime { get; set; }
        public string WeatherText { get; set; }
        public int WeatherIcon { get; set; }
        public bool IsDayTime { get; set; }
        public TemperatureObject Temperature { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }

        public class Metric
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Imperial
        {
            public double Value { get; set; }
            public string Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class TemperatureObject
        {
            public Metric Metric { get; set; }
            public Imperial Imperial { get; set; }
        }
    }
}