using NUnit.Framework;
using System;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace UITestProject
{
    [TestFixture]
    public class Tests
    {
        AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = ConfigureApp
                    .Android
                    .Debug()
                    .ApkFile(@"..\..\..\..\AccuWeather\AccuWeather.AccuWeather.apk")
                    .StartApp();
        }

        [Test]
        public void GoToSearchActivity()
        {
            app.Tap(c => c.Marked("addCity"));

            Assert.IsNotEmpty(app.Query(c => c.Marked("search")), "The 'Search' button is displayed.");
        }

        [Test]
        public void MakeSearch()
        {
            String searchQuery = "Kara";

            app.Tap(c => c.Marked("addCity"));
            app.EnterText(c => c.Marked("input"), searchQuery);
            app.Tap(c => c.Marked("search"));

            Assert.IsTrue(app.Query(c => c.Marked("cityList"))[0].Text.StartsWith(searchQuery), "The result list matched search query.");
        }

        [Test]
        public void AddCityToCustomList()
        {
            String searchQuery = "Kharkiv";

            app.Tap(c => c.Marked("addCity"));
            app.EnterText(c => c.Marked("input"), searchQuery);
            app.Tap(c => c.Marked("search"));

            var element = app.Query(c => c.Marked("cityList").Child(0)).FirstOrDefault();
            String cityName = element.Text;

            app.Tap(element.Id);
            app.Tap(c => c.Marked("back"));
            app.WaitForElement(c => c.Marked("customList").Child(0));

            Assert.IsTrue(app.Query(c => c.Marked("cityList"))[0].Text.Contains(cityName), "Correct city is added to custom list.");
        }

        [Test]
        public void RemoveCityFromList()
        {
            String searchQuery = "Kiev";

            app.Tap(c => c.Marked("addCity"));
            app.EnterText(c => c.Marked("input"), searchQuery);
            app.Tap(c => c.Marked("search"));

            var element = app.Query(c => c.Marked("cityList").Child(0)).FirstOrDefault();

            app.Tap(element.Id);
            app.Tap(c => c.Marked("back"));
            app.WaitForElement(c => c.Marked("customList").Child(0));

            var city = app.Query(c => c.Marked("customList").Child(0)).FirstOrDefault();

            app.Tap(city.Id);

            Assert.IsFalse(app.Query(c => c.Marked("customList"))[0].Text.Contains(city.Text), "City is deleted from custom list.");
        }
    }
}

