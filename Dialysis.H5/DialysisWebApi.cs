using Dialysis.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.Memory;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace Dialysis.H5
{
    /// <summary>
    /// 调用WebApi
    /// </summary>
    public class DialysisWebApi
    {
        private const string UserName = "basic";
        private const string Password = "U2hlbkhhbzpwYXNzIUAjMTIz";
        private const string DefaultUrl = "http://www.ushen365.com:60001";
        private string _baseUrl;

        public DialysisWebApi()
        {

        }

        public DialysisWebApi(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<T> ExecuteAsync<T>(RestRequest request) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(string.IsNullOrEmpty(_baseUrl) ? DefaultUrl : _baseUrl);
            //client.Authenticator = new HttpBasicAuthenticator(UserName, Password);

            var taskCompletionSource = new TaskCompletionSource<T>();
            client.ExecuteAsync<T>(request, (response) =>
            {
                if (response.ErrorException != null)
                {
                    const string message = "Error retrieving response.  Check inner details for more info.";
                    LogHelper.WriteError(message, response.ErrorException);
                    throw response.ErrorException;
                }
                taskCompletionSource.SetResult(response.Data);
            });

            return await taskCompletionSource.Task;
        }
    }
}
