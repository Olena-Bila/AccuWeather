using AccuWeather.Interfaces;
using System;
using System.IO;
using System.Net;

namespace AccuWeather.API
{
    public class ApiCaller : IApiCaller
    {
        public String DoApiCall(String requestUrl)
        {
            WebRequest request = WebRequest.Create(requestUrl);
            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String responseFromServer = reader.ReadToEnd();

            return responseFromServer;
        }
    }
}