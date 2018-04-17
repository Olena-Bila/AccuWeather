using System;

namespace AccuWeather.API
{
    public class SearchCityResponseModel
    {
        public int Version { get; set; }
        public String Key { get; set; }
        public String Type { get; set; }
        public int Rank { get; set; }
        public String LocalizedName { get; set; }
        public Country CountryInfo { get; set; }
        public AdministrativeArea AdminArea { get; set; }

        public class Country
        {
            public String ID { get; set; }
            public String LocalizedName { get; set; }
        }

        public class AdministrativeArea
        {
            public String ID { get; set; }
            public String LocalizedName { get; set; }
        }
    }
}