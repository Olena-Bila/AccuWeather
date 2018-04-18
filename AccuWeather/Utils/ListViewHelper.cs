using System.Collections.Generic;
using System.Linq;
using Android.Widget;
using Helpers;
using Helpers.Models;

namespace AccuWeather.Utils
{
    public class ListViewHelper
    {
        private readonly HttpHelper _httpHelper = new HttpHelper { Client = new HttpCLient() };

        public async void GetCitiesList(SearchActivity activity, string query)
        {
            var response = await _httpHelper.GetCities(query, Constants.ApiKey);
            response.ForEach(x => activity.SearchCityList.Add(new CityWeather { CityKey = x.Key, CityName = x.LocalizedName }));

            activity.CityList.Adapter = new ArrayAdapter
            (
                activity, Android.Resource.Layout.SimpleListItem1,
                Android.Resource.Id.Text1,
                response.Select(x => x.LocalizedName).ToArray()
            );
        }

        public async void RefreshData(MainActivity activity , List<CityWeather> cities)
        {
            var result = new List<string>();
            foreach (var city in cities)
            {
                var apiResponse = await _httpHelper.GetWeather(city.CityKey, Constants.ApiKey);
                var temperature = apiResponse.Temperature.Metric.Value;
                var weather = apiResponse.WeatherText;
                result.Add($"{city.CityName} Temperature: {temperature} Weather: {weather}");
            }

            activity.CustomList.Adapter = new ArrayAdapter<string>
            (
                activity,
                Android.Resource.Layout.SimpleListItem1,
                Android.Resource.Id.Text1, result
            );
        }
    }
}