using AccuWeather.API;
using Android.Widget;
using System;
using System.Collections.Generic;

namespace AccuWeather
{
    public class GetWeather
    {
        public MainActivity activity { get; set; }

        public async void RefreshData(List<CityWeather> cities)
        {
            ApiCaller caller = new ApiCaller();
            ApiHelper apiHelper = new ApiHelper();
            apiHelper.ApiCaller = caller;

            List<String> result = new List<String>();

            foreach (CityWeather city in cities)
            {
                WeatherResponseModel apiResponse = await apiHelper.GetWeatherApiResponse(city.CityKey, Constants.apiKey);
                String temperature = apiResponse.Temperature.Metric.Value.ToString();
                String weather = apiResponse.WeatherText;

                result.Add($"{city.CityName} Temperature: {temperature} Weather: {weather}");
            }

            activity.customList.Adapter = new ArrayAdapter<String>(activity, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, result);
        }
    }
}