using AccuWeather.API;
using Android.Widget;
using System;
using System.Collections.Generic;

namespace AccuWeather
{
    public class GetWeather
    {
        public MainActivity activity { get; set; }

        public void RefreshData(List<CityWeather> cities)
        {
            ApiCaller caller = new ApiCaller();
            ApiHelper apiHelper = new ApiHelper();
            apiHelper.ApiCaller = caller;

            const String apiKey = "x1mNSJUlJjip9UcRz2rRBU4RpKByCFHR";

            List<String> result = new List<String>();

            foreach (CityWeather city in cities)
            {
                WeatherResponseModel apiResponse = apiHelper.GetWeatherApiResponse(city.CityKey, apiKey);
                String temperature = apiResponse.Temperature.Metric.Value.ToString();
                String weather = apiResponse.WeatherText;

                result.Add($"{city.CityName} Temperature: {temperature} Weather: {weather}");
            }

            activity.customList.Adapter = new ArrayAdapter<String>(activity, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, result);
        }
    }
}