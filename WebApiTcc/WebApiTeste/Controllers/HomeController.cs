using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebApiTcc.Application.Home;
using WebApiTcc.Models;
using WebApiTcc.Services.Home;

namespace WebApiTcc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeApplication _homeApplication;
        private readonly IHomeServices _homeServices;

        public HomeController(IHomeApplication homeApplication, IHomeServices homeServices)
        {
            _homeApplication = homeApplication;
            _homeServices = homeServices;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       

        public async Task<IActionResult> Get()
        {
            try
            {
                string retValue = "";
                using (var client = new HttpClient())
                {
                    var ecomerce = "http://localhost:30019";
                    var resourceEcommerce = "api/ping";

                    var azure = "http://emotionwebapi.azurewebsites.net";
                    var resourceAzure = "api/emotion";

                    client.BaseAddress = new Uri(azure);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(resourceAzure);
                    if (response.IsSuccessStatusCode)
                    {
                        retValue = await response.Content.ReadAsStringAsync();
                    }
                }
                return View("Index", retValue);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public JsonResult GetUser(string logon, string senha)
        {
            try
            {
                var result = _homeApplication.GetUser(logon, senha);
                

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
