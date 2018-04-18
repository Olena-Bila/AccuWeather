using System;

namespace AccuWeather
{
    public class CityWeather
    {
        public CityWeather(String key, String city = null, String weather = null, String temperature = null)
        {
            CityKey = key;
            CityName = city;
            Weather = weather;
            Temperature = temperature;
        }

        public String CityKey { get; set; }
        public String CityName { get; set; }
        public String Weather { get; set; }
        public String Temperature { get; set; }        
    }
}