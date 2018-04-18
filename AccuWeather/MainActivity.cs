using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using System.Collections.Generic;
using AccuWeather.Utils;
using Newtonsoft.Json;
using Android.Preferences;
using Helpers.Models;

namespace AccuWeather
{
    [Activity(Label = "AccuWeather", MainLauncher = true)]
    public class MainActivity : Activity
    {
        public Button AddCity;
        public ListView CustomList;

        public PrefsHelper PrefsHelper;
        public ListViewHelper ListViewHelper;

        public List<CityWeather> CityWeatherList = new List<CityWeather>();

        protected override void OnCreate(Bundle state)
        {
            base.OnCreate(state);
            SetContentView(Resource.Layout.Main);

            PrefsHelper = new PrefsHelper();
            ListViewHelper = new ListViewHelper();

            AddCity = FindViewById<Button>(Resource.Id.addCity);
            CustomList = FindViewById<ListView>(Resource.Id.customList);

            AddCity.Click += OnAddCityClick;
            CustomList.ItemClick += OnItemClick;
        }

        protected override void OnResume()
        {
            var prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            var value = prefs.GetString("cities",string.Empty);

            if (value != string.Empty)
            {
                CityWeatherList = JsonConvert.DeserializeObject<List<CityWeather>>(value);
                ListViewHelper.RefreshData(this , CityWeatherList);
            }
            base.OnResume();
        }

        private void OnAddCityClick(object sender, EventArgs e)
        {
            StartActivity(new Intent(this, typeof(SearchActivity)));
        }

        private void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            CityWeatherList.RemoveAt(e.Position);
            PrefsHelper.RemoveCities(this, e.Position);
            ListViewHelper.RefreshData(this, CityWeatherList);
        }
    }
}

