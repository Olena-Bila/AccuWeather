using System;

namespace AccuWeather
{
    class CityWeather
    {
        public CityWeather(String city, String weather, String temperature)
        {
            CityName = city;
            Weather = weather;
            Temperature = temperature;
        }

        public String CityName { get; set; }
        public String Weather { get; set; }
        public String Temperature { get; set; }
    }
}