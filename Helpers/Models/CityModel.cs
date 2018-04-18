namespace Helpers.Models
{
    public class CityModel
    {
        public int Version { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string LocalizedName { get; set; }
        public Country CountryInfo { get; set; }
        public AdministrativeArea AdminArea { get; set; }

        public class Country
        {
            public string Id { get; set; }
            public string LocalizedName { get; set; }
        }

        public class AdministrativeArea
        {
            public string Id { get; set; }
            public string LocalizedName { get; set; }
        }
    }
}