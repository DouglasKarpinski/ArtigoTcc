using Microsoft.AspNetCore.Mvc;

namespace WebApiTcc.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}