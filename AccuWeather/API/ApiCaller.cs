using AccuWeather.Interfaces;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace AccuWeather.API
{
    public class ApiCaller : IApiCaller
    {
        public async Task<string> DoApiCall(string requestUrl)
        {
            WebRequest request = WebRequest.Create(requestUrl);
            using (var response = await request.GetResponseAsync())
            {
                using (var stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    return reader.ReadToEnd();
                }
            }
        }

    }
}