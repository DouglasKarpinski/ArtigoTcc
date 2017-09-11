using WebApiTcc.Application.WebApiRequests;
using WebApiTcc.Models;
using WebApiTeste.Application;
using WebApiTeste.Helpers;

namespace WebApiTcc.Application.Home
{
    public class HomeApplication : SharedApplication, IHomeApplication
    {
        private string Api => "api/Ping";

        public Response Get()
        {
            return new WebApiRequest("http://192.168.7.10:30019/")
                .AddResource(Api)
                .Get()
                .GetContent();
        }
    }
}
