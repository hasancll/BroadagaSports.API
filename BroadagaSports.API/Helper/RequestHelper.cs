using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BroadagaSports.API.Helper
{
    public static class RequestHelper
    {
        public static HttpRequestMessage HttpRequestMessage(HttpMethod httpMethod, String url, Object obj = null)
        {
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var json = JsonConvert.SerializeObject(obj, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            var requestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(url),
                Method = httpMethod
            };

            if (json != "null")
            {
                requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            requestMessage.Headers.Add("Ocp-Apim-Subscription-Key", "c60589c5-5aac-47be-ae88-78b6049f677e");
            requestMessage.Headers.Add("languageId", "2");
            requestMessage.Headers.Add("Accept", "application/json");
   
           

            return requestMessage;
        }
        public static async Task<List<T>> GetHttpResponseMultipleAsyn<T>(HttpRequestMessage httpRequestMessage)
        {
            HttpClient httpClient = new HttpClient();

            var response = await httpClient.SendAsync(httpRequestMessage).ConfigureAwait(false);
            var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var responseObject = JsonConvert.DeserializeObject<List<T>>(responseString);

            return responseObject;
        }
        public static async Task<T> GetHttpResponseSingleAsync<T>(HttpRequestMessage httpRequestMessage)
        {
            HttpClient httpClient = new HttpClient();

            String responseString = "";

            try
            {
                var response = await httpClient.SendAsync(httpRequestMessage).ConfigureAwait(false);
                responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {


            }

            var responseObject = JsonConvert.DeserializeObject<T>(responseString);
            return responseObject;
        }
    }
}
