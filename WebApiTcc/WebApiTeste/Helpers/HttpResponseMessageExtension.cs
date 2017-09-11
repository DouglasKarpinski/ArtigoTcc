using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using WebApiTcc.Models;

namespace WebApiTeste.Helpers
{
    public static class HttpResponseMessageExtension
    {
        public static Response<T> GetContent<T>(this HttpResponseMessage response)
        {

            if (response.StatusCode != HttpStatusCode.OK &&
                response.StatusCode != HttpStatusCode.NoContent &&
                response.StatusCode != HttpStatusCode.NotAcceptable &&
                response.StatusCode != HttpStatusCode.InternalServerError)
                return new Response<T>(response.StatusCode, "Ocorreu um erro ao realizar a operação.");

            var request = response.StatusCode == HttpStatusCode.NoContent
                ? new Response<T>(default(T))
                : JsonConvert.DeserializeObject<Response<T>>(response.Content.ReadAsStringAsync().Result);

            request.StatusCode = response.StatusCode;
            return request;
        }

        public static Response GetContent(this HttpResponseMessage response)
        {
            if (response.StatusCode != HttpStatusCode.OK &&
                response.StatusCode != HttpStatusCode.NoContent &&
                response.StatusCode != HttpStatusCode.NotAcceptable &&
                response.StatusCode != HttpStatusCode.InternalServerError)
                return new Response(response.StatusCode, "Ocorreu um erro ao realizar a operação.");

            var request = JsonConvert.DeserializeObject<Response>(response.Content.ReadAsStringAsync().Result);
            request.StatusCode = response.StatusCode;
            return request;
        }

        public static string GetAsString(this HttpResponseMessage response)
        {
            return response.Content.ReadAsStringAsync().Result.Replace(Environment.NewLine, string.Empty);
        }
    }
}
