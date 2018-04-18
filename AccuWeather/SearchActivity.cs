using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
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

            Toast.MakeText(this, "City is added to your list", ToastLength.Long).Show();
        }

        void OnBackClick(object sender, EventArgs e)
        {
            SaveData SaveData = new SaveData();
            SaveData.SaveCityList(this, selectedCities);

            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}