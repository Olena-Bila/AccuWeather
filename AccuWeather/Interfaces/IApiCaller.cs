using System;

namespace AccuWeather.Interfaces
{
    public interface IApiCaller
    {
        String DoApiCall(String requestUrl);
    }
}