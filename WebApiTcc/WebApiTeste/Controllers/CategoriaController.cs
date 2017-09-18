using Data.Services.Categoria;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApiTcc.ViewModel.Categoria;

namespace WebApiTcc.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;


        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public IActionResult Index()
        {
            try
            {
                var categorias = _categoriaService.GetAll();

                return View("Index", categorias);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoriaViewModel categoriaViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var categoria = new Categoria()
                    {
                        Descricao = categoriaViewModel.Descricao
                    };

                    var retorno = _categoriaService.Post(categoria);

                    return RedirectToAction("Index");
                }

                return View(categoriaViewModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }


        }
    }
}