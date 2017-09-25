using Data.Repository.Produto;
using Data.Services.Produto;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTcc.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public IActionResult Index()
        {
            var produto = _produtoService.GetAll();

            return View(produto);
        }

        public IActionResult Create()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Edit()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Delete()
        {
            throw new System.NotImplementedException();
        }
    }
}