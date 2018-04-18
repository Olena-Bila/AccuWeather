using System;
using System.Threading.Tasks;

namespace AccuWeather.Interfaces
{
    public interface IApiCaller
    {
        Task<string> DoApiCall(String requestUrl);
    }
}