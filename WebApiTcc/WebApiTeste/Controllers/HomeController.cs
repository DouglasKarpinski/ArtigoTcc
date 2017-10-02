using Data.Services.Home;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WebApiTcc.Application.Home;
using WebApiTcc.Models;

namespace WebApiTcc.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IHomeApplication _homeApplication;
        //private readonly IHomeServices _homeServices;

        //public HomeController(IHomeApplication homeApplication, IHomeServices homeServices)
        //{
        //    _homeApplication = homeApplication;
        //    _homeServices = homeServices;
        //}

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

        //public async Task<IActionResult> Get()
        //{
        //    try
        //    {
        //        var retorno =  _homeApplication.Get();

        //        return null;

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}

        //public JsonResult GetUser(string logon, string senha)
        //{
        //    try
        //    {
        //        var result = _homeApplication.GetUser(logon, senha);
                

        //        return null;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}

        //public IActionResult GetBd()
        //{
        //   var retorno = _homeServices.GetBd();

        //    return null;
        //}
    }
}
