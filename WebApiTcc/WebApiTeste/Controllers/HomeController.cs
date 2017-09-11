using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using WebApiTeste.Application.Home;
using WebApiTeste.Models;

namespace WebApiTeste.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeApplication _homeApplication;

        public HomeController(IHomeApplication homeApplication)
        {
            _homeApplication = homeApplication;
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
                var retorno = _homeApplication.Get();
                if (!retorno.IsSuccess)
                    return Error();

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
