using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helpers;
using Helpers.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        private string weatherResponse = "[{\"LocalObservationDateTime\":\"2018-04-18T18:45:00+03:00\",\"EpochTime\":1524066300,\"WeatherText\":\"Partly sunny\",\"WeatherIcon\":3,\"IsDayTime\":true,\"Temperature\":{\"Metric\":{\"Value\":17.2,\"Unit\":\"C\",\"UnitType\":17},\"Imperial\":{\"Value\":63.0,\"Unit\":\"F\",\"UnitType\":18}},\"MobileLink\":\"http://m.accuweather.com/en/ua/kharkiv/323903/current-weather/323903?lang=en-us\",\"Link\":\"http://www.accuweather.com/en/ua/kharkiv/323903/current-weather/323903?lang=en-us\"}]";
        private string citiesResponse = "[{\"Version\":1,\"Key\":\"101841\",\"Type\":\"City\",\"Rank\":11,\"LocalizedName\":\"Hefei\",\"Country\":{ \"ID\":\"CN\", \"LocalizedName\":\"China\"},\"AdministrativeArea\":{\"ID\":\"AH\",\"LocalizedName\":\"Anhui\"}}]";

        [TestMethod]
        public async void GetWeatherTest()
        {
            var clientMock = new Mock<HttpCLient>();
            clientMock.Setup(x => x.GetRequest(It.IsAny<string>())).Returns(Task.FromResult(weatherResponse));

            var httpHelper = new HttpHelper { Client = clientMock.Object };
            var response = await httpHelper.GetWeather("cityKey", "apiKey");

            Assert.IsTrue(response == JsonConvert.DeserializeObject<List<Weather>>(weatherResponse).FirstOrDefault());
        }

        [TestMethod]
        public async void GetCitiesTest()
        {
            var clientMock = new Mock<HttpCLient>();
            clientMock.Setup(x => x.GetRequest(It.IsAny<string>())).Returns(Task.FromResult(citiesResponse));

            var httpHelper = new HttpHelper { Client = clientMock.Object };
            var response = await httpHelper.GetCities("query", "apiKey");

            Assert.IsTrue(response == JsonConvert.DeserializeObject<List<CityModel>>(citiesResponse));
        }
    }
}
