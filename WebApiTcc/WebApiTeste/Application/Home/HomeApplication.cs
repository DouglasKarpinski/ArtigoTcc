using WebApiTeste.Helpers;
using WebApiTeste.Models;

namespace WebApiTeste.Application.Home
{
    public class HomeApplication : SharedApplication, IHomeApplication
    {
        private string Api => "api/Ping";

        public Response Get()
        {
            return new WebApiRequests.WebApiRequest("http://192.168.7.10:30019/")
                .AddResource(Api)
                .Get()
                .GetContent();
        }
    }
}
