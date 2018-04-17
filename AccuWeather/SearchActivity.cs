using Android.App;
using Android.OS;
using Android.Widget;
using System;

namespace AccuWeather
{
    [Activity(Label = "Add City")]
    public class SearchActivity : Activity
    {
        public EditText input;
        public Button search;
        public ListView cityList;

        protected override void OnCreate(Bundle state)
        {
            base.OnCreate(state);
            SetContentView(Resource.Layout.Search);

            input = FindViewById<EditText>(Resource.Id.input);
            search = FindViewById<Button>(Resource.Id.search);
            cityList = FindViewById<ListView>(Resource.Id.cityList);

            search.Click += OnSearchClick;            
        }

        void OnSearchClick(object sender, EventArgs e)
        {
            new GetCities { activity = this }.GetCitiesList(input.Text);
        }

        void OnCityNameClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int position = e.Position;
            // TODO
        }
    }
}