using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using System.Collections.Generic;
using Newtonsoft.Json;
using Android.Preferences;

namespace AccuWeather
{
    [Activity(Label = "AccuWeather", MainLauncher = true)]
    public class MainActivity : Activity
    {
        public Button addCity;
        public ListView customList;
        public Button refreshData;

        public List<CityWeather> cityWeatherList = new List<CityWeather>();

        protected override void OnCreate(Bundle state)
        {
            base.OnCreate(state);
            SetContentView(Resource.Layout.Main);

            addCity = FindViewById<Button>(Resource.Id.addCity);
            customList = FindViewById<ListView>(Resource.Id.customList);

            addCity.Click += OnAddCityClick;
        }

        protected override void OnResume()
        {
            var prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            var value = prefs.GetString("cities",string.Empty);

            if (value != string.Empty)
            {
                var cities = JsonConvert.DeserializeObject<List<CityWeather>>(value);
                new GetWeather { activity = this }.RefreshData(cities);
            }
            base.OnResume();
        }

        void OnAddCityClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(SearchActivity));
            StartActivity(intent);
        }

        void OnDeleteClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int position = e.Position;

            // TODO
        }
    }
}

