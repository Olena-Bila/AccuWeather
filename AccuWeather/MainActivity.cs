using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

namespace AccuWeather
{
    [Activity(Label = "AccuWeather", MainLauncher = true)]
    public class MainActivity : Activity
    {
        public Button addCity;
        public ListView customList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            addCity = FindViewById<Button>(Resource.Id.addCity);
            customList = FindViewById<ListView>(Resource.Id.customList);

            addCity.Click += OnSearchClick;

            customList.Adapter = new ArrayAdapter<CityWeather>(this, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1 /* , + list of cities */); 
        }

        public void OnSearchClick(object sender, EventArgs e)
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

