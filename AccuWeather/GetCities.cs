using AccuWeather.API;
using Android.Widget;
using System;
using System.Collections.Generic;

namespace AccuWeather
{
    public class GetCities
    {
        public SearchActivity activity { get; set; }

        public void GetCitiesList(String query)
        {
            ApiCaller caller = new ApiCaller();
            ApiHelper apiHelper = new ApiHelper();
            apiHelper.ApiCaller = caller;

            const String apiKey = "eEGAfmLFDCzpMpam7FJLzkQG7xRlG0Ac";
            String searchQuery = query;

            List<SearchCityResponseModel> responseFromServer = apiHelper.GetCitySearchApiResponse(searchQuery, apiKey);

            List<String> cities = new List<String>();

            foreach (SearchCityResponseModel city in responseFromServer)
            {
                cities.Add(city.LocalizedName);
            }

            activity.cityList.Adapter = new ArrayAdapter<String>(activity, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, cities);
        }
    }
}