using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AccuWeather
{
    [Activity(Label = "Add City")]
    public class SearchActivity : Activity
    {
        public EditText input;
        public Button search;
        public ListView cityList;
        public Button back;

        public List<CityWeather> searchCityList = new List<CityWeather>();
        public List<CityWeather> selectedCities = new List<CityWeather>();

        protected override void OnCreate(Bundle state)
        {
            base.OnCreate(state);
            SetContentView(Resource.Layout.Search);

            input = FindViewById<EditText>(Resource.Id.input);
            search = FindViewById<Button>(Resource.Id.search);
            cityList = FindViewById<ListView>(Resource.Id.cityList);
            back = FindViewById<Button>(Resource.Id.back);

            search.Click += OnSearchClick;
            cityList.ItemClick += OnCityNameClick;
            back.Click += OnBackClick;
        }

        void OnSearchClick(object sender, EventArgs e)
        {
            new GetCities { activity = this }.GetCitiesList(input.Text);
        }

        void OnCityNameClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int position = e.Position;
            selectedCities.Add(searchCityList[position]);
        }

        void OnBackClick(object sender, EventArgs e)
        {
            var prefs = PreferenceManager.GetDefaultSharedPreferences(this);

            var value = prefs.GetString("cities", JsonConvert.SerializeObject(new List<CityWeather>(), Formatting.Indented));
            var cities = JsonConvert.DeserializeObject<List<CityWeather>>(value);
            cities.AddRange(selectedCities);

            var editor = prefs.Edit();
            editor.PutString("cities", JsonConvert.SerializeObject(cities, Formatting.Indented));
            editor.Apply();

            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}