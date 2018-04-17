using AccuWeather.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AccuWeather.API
{
    public class ApiHelper
    {
        public IApiCaller ApiCaller { get; set; }

        public List<SearchCityResponseModel> GetCitySearchApiResponse(String query, String apiKey)
        {
            String responseFromServer = ApiCaller.DoApiCall($@"http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey={apiKey}&q={query}");

            List<SearchCityResponseModel> responseModels = (JsonConvert.DeserializeObject<List<SearchCityResponseModel>>(responseFromServer));

            return responseModels;
        }
    }
}