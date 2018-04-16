using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;
using System.Collections.Generic;

namespace AccuWeather
{
    class SearchActivity
    {
        [Activity(Label = "Add City")]
        public class MainActivity : Activity
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

                cityList.Adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1 /* , + list of cities */);
            }

            void OnSearchClick(object sender, EventArgs e)
            {
                new GetCities { activity = this }.GetCitiesList();
            }

            void OnDeleteClick(object sender, AdapterView.ItemClickEventArgs e)
            {
                int position = e.Position;

                // TODO
            }
        }
}