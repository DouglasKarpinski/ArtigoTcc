using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Noticias.Data;
using Noticias.Models;
using Noticias.Models.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Noticias.Controllers
{
    public class CategoriasController : Controller
    {

        private readonly DBNoticias _dbNoticias;

        public CategoriasController(DBNoticias dbNoticias)
        {
            _dbNoticias = dbNoticias;
        }

        public IActionResult Index()
        {
            var retorno = _dbNoticias.Categorias.OrderBy(x => x.Descricao);

            return View(retorno);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
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

                    _dbNoticias.Add(categoria);
                    await _dbNoticias.SaveChangesAsync();

                    return RedirectToAction("Index");
                }

                return View(categoriaViewModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
            

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categoria retorno = await _dbNoticias.Categorias.SingleOrDefaultAsync(x => x.Id == id);

            if (retorno == null)
            {
                return NotFound();
            }

            var categoria = new CategoriaViewModel()
            {
                Id = retorno.Id,
                Descricao = retorno.Descricao
            };

            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoriaViewModel model)
        {
            if (ModelState.IsValid)
            {
                Categoria categoria = await _dbNoticias.Categorias.SingleOrDefaultAsync(x => x.Id == model.Id);

                categoria.Descricao = model.Descricao;

                _dbNoticias.Update(categoria);

                await _dbNoticias.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete()
        {
            return View();
        }
    }
}