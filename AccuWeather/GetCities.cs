﻿using AccuWeather.API;
using Android.Widget;
using System;
using System.Collections.Generic;

namespace AccuWeather
{
    public class GetCities
    {
        public SearchActivity activity { get; set; }

        public async void GetCitiesList(String query)
        {
            ApiCaller caller = new ApiCaller();
            ApiHelper apiHelper = new ApiHelper();
            apiHelper.ApiCaller = caller;
                        
            String searchQuery = query;

            List<SearchCityResponseModel> responseFromServer = await apiHelper.GetCitySearchApiResponse(searchQuery, Constants.apiKey);
            List<String> cities = new List<String>();

            foreach (SearchCityResponseModel city in responseFromServer)
            {
                activity.searchCityList.Add(new CityWeather(city.Key, city.LocalizedName));
                cities.Add(city.LocalizedName);
            }           

            activity.cityList.Adapter = new ArrayAdapter(activity, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, cities);
        }
    }
}