using RestSharp;
using System;
using System.Net;
using WebApiTcc.Models;
using WebApiTcc.ViewModel.Usuario;

namespace WebApiTcc.Application.Home
{
    public class HomeApplication : SharedApplication, IHomeApplication
    {
        string uri = new UriApi().Ecommerce;

        public Response<UsuarioViewModel> GetUser(string logon, string senha)
        {
            var client = new RestClient(uri);
            var request = new RestRequest("api/token/", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new
            {
                logon = logon,
                senha = senha
            });

            client.ExecuteAsync(request, Response =>
            {
                if (Response.StatusCode == HttpStatusCode.OK)
                {

                }
                else
                {
                    Console.WriteLine("Erro");
                }
            });

            return null;
        }
    }
}
