using AccuWeather.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccuWeather.API
{
    public class ApiHelper
    {
        public IApiCaller ApiCaller { get; set; }

        public async Task<List<SearchCityResponseModel>> GetCitySearchApiResponse(String query, String apiKey)
        {
            String responseFromServer = await ApiCaller.DoApiCall($@"http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey={apiKey}&q={query}");
            return JsonConvert.DeserializeObject<List<SearchCityResponseModel>>(responseFromServer);
        }

        public async Task<WeatherResponseModel> GetWeatherApiResponse(String cityKey, String apiKey)
        {
            String responseFromServer = await ApiCaller.DoApiCall($@"http://dataservice.accuweather.com/currentconditions/v1/{cityKey}?apikey={apiKey}");
            return (JsonConvert.DeserializeObject<List<WeatherResponseModel>>(responseFromServer)).FirstOrDefault();
        }
    }
}