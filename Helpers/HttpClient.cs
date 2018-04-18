using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AccuWeather.Utils;
using Helpers.Models;
using Newtonsoft.Json;

namespace Helpers
{
    public class HttpHelper
    {
        public IHttpClient Client { get; set; }

        public async Task<List<CityModel>> GetCities(string query, string apiKey)
        {
            var urlParams = $"?apikey={apiKey}&q={query}";
            var responseFromServer = await Client.GetRequest(string.Concat(Constants.BaseUrl, Constants.Locations, urlParams));
            return JsonConvert.DeserializeObject<List<CityModel>>(responseFromServer);
        }

        public async Task<Weather> GetWeather(string cityKey, string apiKey)
        {
            var urlParams = $"currentconditions/v1/{cityKey}?apikey={apiKey}";
            var responseFromServer = await Client.GetRequest(string.Concat(Constants.BaseUrl, urlParams));
            return JsonConvert.DeserializeObject<List<Weather>>(responseFromServer).FirstOrDefault();
        }
    }

    public class HttpCLient : IHttpClient
    {
        public async Task<string> GetRequest(string requestUrl)
        {
            var request = WebRequest.Create(requestUrl);
            using (var response = await request.GetResponseAsync())
            {
                using (var stream = response.GetResponseStream())
                {
                    return new StreamReader(stream).ReadToEnd();
                }
            }
        }
    }

    public interface IHttpClient
    {
        Task<string> GetRequest(string requestUrl);
    }
}