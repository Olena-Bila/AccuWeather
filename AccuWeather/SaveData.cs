using System.Collections.Generic;
using Android.Content;
using Android.Preferences;
using Newtonsoft.Json;

namespace AccuWeather
{
    public class SaveData
    {
        public void SaveCityList(Context activity, List<CityWeather> citiesList)
        {
            var prefs = PreferenceManager.GetDefaultSharedPreferences(activity);
            var cities = GetCollection(activity);
            cities.AddRange(citiesList);

            var editor = prefs.Edit();
            editor.PutString("cities", JsonConvert.SerializeObject(cities, Formatting.Indented));
            editor.Apply();
        }

        public void RemoveFromList(Context activity, int cityIndex)
        {
            var prefs = PreferenceManager.GetDefaultSharedPreferences(activity);
            var cities = GetCollection(activity);
            cities.RemoveAt(cityIndex);

            var editor = prefs.Edit();
            editor.PutString("cities", JsonConvert.SerializeObject(cities, Formatting.Indented));
            editor.Apply();
        }

        public List<CityWeather> GetCollection(Context activity)
        {
            var prefs = PreferenceManager.GetDefaultSharedPreferences(activity);
            var value = prefs.GetString("cities", JsonConvert.SerializeObject(new List<CityWeather>(), Formatting.Indented));
            return JsonConvert.DeserializeObject<List<CityWeather>>(value);
        }
    }
}