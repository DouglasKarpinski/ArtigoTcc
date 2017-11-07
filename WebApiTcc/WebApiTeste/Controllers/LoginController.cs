using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Services.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebApiTcc.ViewModel.Usuario;

namespace WebApiTcc.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public ActionResult Index()
        {

            return View();
        }

        public IActionResult Post(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                var usuario = new Usuario()
                {
                    Nome = usuarioViewModel.Nome,
                    Senha = usuarioViewModel.Senha
                };
                var retorno = _loginService.Post(usuario);

                if (retorno == null)
                   return RedirectToAction("Error");


                return RedirectToAction("About", "home");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Error()
        {
            return View("ErrorPage");
        }
    }
}
