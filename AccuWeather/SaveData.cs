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

            var value = prefs.GetString("cities", JsonConvert.SerializeObject(new List<CityWeather>(), Formatting.Indented));
            var cities = JsonConvert.DeserializeObject<List<CityWeather>>(value);
            cities.AddRange(citiesList);

            var editor = prefs.Edit();
            editor.PutString("cities", JsonConvert.SerializeObject(cities, Formatting.Indented));
            editor.Apply();
        }
    }
}