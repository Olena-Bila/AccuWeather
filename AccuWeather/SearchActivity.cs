using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;
using System.Collections.Generic;
using AccuWeather.Utils;
using Helpers.Models;

namespace AccuWeather
{
    [Activity(Label = "Add City")]
    public class SearchActivity : Activity
    {
        public Button Back;
        public Button Search;
        public EditText Input;
        public ListView CityList;

        public PrefsHelper PrefsHelper;
        public ListViewHelper ListViewHelper;

        public List<CityWeather> SearchCityList = new List<CityWeather>();
        public List<CityWeather> SelectedCities = new List<CityWeather>();

        protected override void OnCreate(Bundle state)
        {
            base.OnCreate(state);
            SetContentView(Resource.Layout.Search);

            PrefsHelper = new PrefsHelper();;
            ListViewHelper = new ListViewHelper();;

            Back = FindViewById<Button>(Resource.Id.back);
            Input = FindViewById<EditText>(Resource.Id.input);
            Search = FindViewById<Button>(Resource.Id.search);
            CityList = FindViewById<ListView>(Resource.Id.cityList);

            Back.Click += OnBackClick;
            Search.Click += OnSearchClick;
            CityList.ItemClick += OnCityNameClick;
        }

        private void OnSearchClick(object sender, EventArgs e)
        {
            ListViewHelper.GetCitiesList(this, Input.Text);
        }

        private void OnCityNameClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            SelectedCities.Add(SearchCityList[e.Position]);
            Toast.MakeText(this, "City is added to your list", ToastLength.Long).Show();
        }

        private void OnBackClick(object sender, EventArgs e)
        {
            PrefsHelper.AddCities(this, SelectedCities);
            StartActivity(new Intent(this, typeof(MainActivity)));
        }
    }
}