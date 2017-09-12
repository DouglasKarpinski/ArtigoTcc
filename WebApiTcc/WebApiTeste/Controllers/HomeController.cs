using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
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

        public ActionResult Get()
        {
            try
            {
                //testa api externa
                var retorno = _homeApplication.Get();
                if (!retorno.IsSuccess)
                    return Error();

                //testa banco azure
                var retornoData = _homeServices.Get();


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
