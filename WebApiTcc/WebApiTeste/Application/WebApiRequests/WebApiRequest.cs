//using Newtonsoft.Json;
//using System;
//using System.Net;
//using System.Net.Http;
//using System.Net.Http.Formatting;
//using System.Text;
//using System.Text.RegularExpressions;

//namespace WebApiTcc.Application.WebApiRequests
//{
//    public class WebApiRequest
//    {
//        private readonly HttpClient _httpClient;
//        private readonly StringBuilder _resource;

//        public WebApiRequest(string serverUrl, int timeOutMinutes) : this(serverUrl)
//        {
//            _httpClient.Timeout = new TimeSpan(0, timeOutMinutes, 0);
//        }

//        public WebApiRequest(string serverUrl)
//        {
//            _httpClient = HttpClientBuilder.BuildHttpClient(serverUrl, 1);
//            _resource = new StringBuilder(256);
//        }

//        public WebApiRequest AddHeader(string headerName, object headerValue)
//        {
//            if (headerName == "Authorization")
//                headerValue = "Bearer " + headerValue;

//            HttpClientBuilder.BuildHeader(_httpClient, headerName, headerValue);
//            return this;
//        }

//        public WebApiRequest AddResource(object resourceName)
//        {
//            _resource.Append(resourceName).Append("/");
//            return this;
//        }

//        public WebApiRequest AddParameter(object parameterValue)
//        {
//            _resource.Append(parameterValue).Append("/");
//            return this;
//        }

//        public WebApiRequest CreateQuery()
//        {
//            _resource.Append("?");
//            return this;
//        }

//        public WebApiRequest AddQueryParameter(string parameterName, object parameterValue)
//        {
//            var d = parameterValue as Decimal?;
//            var dt = parameterValue as DateTime?;
//            _resource.Append(parameterName).Append("=");

//            if (d != null)
//                _resource.Append(Regex.Replace(d.Value.ToString(), @"(?<=\d)\,(?=\d)", ".", RegexOptions.Compiled));
//            else if (dt != null)
//                _resource.Append(string.Format("{0:yyyy-MM-dd}%20{0:HH}%3A{0:mm}%3A{0:ss}", dt));
//            else
//                _resource.Append(parameterValue);

//            _resource.Append("&");

//            return this;
//        }

//        public HttpResponseMessage Get()
//        {
//            try
//            {
//                return _httpClient.GetAsync(_resource.ToString()).Result;
//            }
//            catch (Exception ex)
//            {
//                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
//                {
//                    Content = new ObjectContent(ex.GetType(), ex, JsonMediaTypeFormatter)
//                };
//            }
//        }

//        public HttpResponseMessage Post<T>(T form)
//        {
//            try
//            {
//                return _httpClient.PostAsync(_resource.ToString(), form, JsonMediaTypeFormatter).Result;
//            }
//            catch (Exception ex)
//            {
//                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
//                {
//                    Content = new ObjectContent(ex.GetType(), ex, JsonMediaTypeFormatter)
//                };
//            }
//        }

//        public HttpResponseMessage Put<T>(T form)
//        {
//            try
//            {
//                return _httpClient.PutAsync(_resource.ToString(), form, JsonMediaTypeFormatter).Result;
//            }
//            catch (Exception ex)
//            {
//                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
//                {
//                    Content = new ObjectContent(ex.GetType(), ex, JsonMediaTypeFormatter)
//                };
//            }
//        }

//        public HttpResponseMessage Delete()
//        {
//            try
//            {
//                return _httpClient.DeleteAsync(_resource.ToString()).Result;

//            }
//            catch (Exception ex)
//            {
//                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
//                {
//                    Content = new ObjectContent(ex.GetType(), ex, JsonMediaTypeFormatter)
//                };
//            }
//        }

//        private static readonly JsonMediaTypeFormatter JsonMediaTypeFormatter = new JsonMediaTypeFormatter
//        {

//            SerializerSettings = new JsonSerializerSettings
//            {
//                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
//                NullValueHandling = NullValueHandling.Include
//            }
//        };
//    }
//}

