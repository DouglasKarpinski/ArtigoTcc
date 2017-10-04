using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Data.Services.Emotion;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTcc.Controllers
{
    public class EmotionController : Controller
    {
        private readonly IEmotionService _emotionService;
        
        public EmotionController(IEmotionService emotionService)
        {
            _emotionService = emotionService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PostDemonstration(string file)
        {
            try
            {
                var request = _emotionService.Demonstracao(file);

                if (request == null)
                    return BadRequest();

                return Ok(request);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message} \nException: {e.InnerException} \nOnde: {e.StackTrace}");
            }
        }
    }
}
