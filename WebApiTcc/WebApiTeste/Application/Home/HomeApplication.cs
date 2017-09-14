using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;
using WebApiTcc.Models;
using WebApiTcc.ViewModel.Seguranca;
using WebApiTcc.ViewModel.Usuario;

namespace WebApiTcc.Application.Home
{
    public class HomeApplication : SharedApplication, IHomeApplication
    {
        string uri = new UriApi().Ecommerce;
        string uriAzure = new UriApi().Azure;

        public Response Get()
        {
            string x = null;
            var client = new RestClient(uriAzure);
            var request = new RestRequest("api/emotion", Method.GET);
            request.RequestFormat = DataFormat.Json;

            client.ExecuteAsync(request, response =>
             {
                 if (response.StatusCode == HttpStatusCode.OK)
                 {
                     x = JsonConvert.DeserializeObject<string>(response.Content);
                 }
                 else
                 {
                     Console.WriteLine("Erro");
                 }
             });

            return null;
        }

        public Response<UsuarioViewModel> GetUser(string logon, string senha)
        {
            UsuarioLogado x = new UsuarioLogado();
            var client = new RestClient(uri);
            var request = new RestRequest("api/token/", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new
            {
                logon = logon,
                senha = senha
            });

            client.ExecuteAsync(request, response =>
           {
               x = JsonConvert.DeserializeObject<UsuarioLogado>(response.Content);
           });

            x.ToString();
            return null;
        }
    }
}
