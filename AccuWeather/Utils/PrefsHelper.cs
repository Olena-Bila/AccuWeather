using System.Collections.Generic;
using Android.Content;
using Android.Preferences;
using Helpers.Models;
using Newtonsoft.Json;

namespace AccuWeather.Utils
{
    public class PrefsHelper
    {
        public void AddCities(Context context, List<CityWeather> citiesList)
        {
            var prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            var cities = GetCities(prefs, context);
            cities.AddRange(citiesList);
            SaveCities(prefs, cities);
        }

        public void RemoveCities(Context context, int cityIndex)
        {
            var prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            var cities = GetCities(prefs, context);
            cities.RemoveAt(cityIndex);

            SaveCities(prefs, cities);
        }

        public List<CityWeather> GetCities(ISharedPreferences prefs, Context context)
        {
            var value = prefs.GetString("cities", JsonConvert.SerializeObject(new List<CityWeather>(), Formatting.Indented));
            return JsonConvert.DeserializeObject<List<CityWeather>>(value);
        }

        public void SaveCities(ISharedPreferences prefs, List<CityWeather> cities)
        {
            var editor = prefs.Edit();
            editor.PutString("cities", JsonConvert.SerializeObject(cities, Formatting.Indented));
            editor.Apply();
        }
    }
}