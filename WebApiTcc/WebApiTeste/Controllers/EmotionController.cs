using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTcc.Controllers
{
    public class EmotionController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PostDemonstration(string file)
        {
            return Ok();
        }
    }
}
