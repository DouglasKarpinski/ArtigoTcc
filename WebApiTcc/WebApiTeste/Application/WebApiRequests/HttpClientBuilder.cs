using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebApiTcc.Application.WebApiRequests
{
    public static class HttpClientBuilder
    {
        public static HttpClient BuildHttpClient(string uri, int requestTimeOut)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(uri),
                Timeout = new TimeSpan(0, requestTimeOut, 0)
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public static HttpClient BuildHeader(HttpClient httpClient, string headerName, object headerValue)
        {
            httpClient.DefaultRequestHeaders.Add(headerName, headerValue?.ToString());
            return httpClient;
        }
    }
}
