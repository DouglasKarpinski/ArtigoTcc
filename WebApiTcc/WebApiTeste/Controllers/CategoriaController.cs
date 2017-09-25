using Data.Services.Categoria;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Principal;
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
                var retorno = _categoriaService.GetAll();

                var categorias = new List<CategoriaViewModel>();
                foreach (var item in retorno)
                {
                    categorias.Add(new CategoriaViewModel()
                    {
                        IdCategoria = item.IdCategoria,
                        Nome = item.Nome,
                        Descricao = item.Descricao,
                        Ativo = item.Ativo,
                        IdUnidadeNegocio = item.IdUnidadeNegocio
                    });
                }
                


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
        public async Task<IActionResult> Post(CategoriaViewModel categoriaViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var categoria = new Categoria()
                    {
                        Nome = categoriaViewModel.Nome,
                        Descricao = categoriaViewModel.Descricao,
                        Ativo = categoriaViewModel.Ativo,
                        IdUnidadeNegocio = categoriaViewModel.IdUnidadeNegocio
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

        public IActionResult Edit(int id)
        {
            try
            {
                var retorno = _categoriaService.GetById(id);
                if (retorno != null)
                {
                    var categoria = new CategoriaViewModel()
                    {

                        IdCategoria = retorno.IdCategoria,
                        Nome = retorno.Nome,
                        Descricao = retorno.Descricao,
                        Ativo = retorno.Ativo,
                        IdUnidadeNegocio = retorno.IdUnidadeNegocio
                    };

                    return View("Edit", categoria);
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Put(CategoriaViewModel categoriaViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var categoria = new Categoria()
                    {
                        IdCategoria = categoriaViewModel.IdCategoria,
                        Nome = categoriaViewModel.Nome,
                        Descricao = categoriaViewModel.Descricao,
                        Ativo = categoriaViewModel.Ativo,
                        IdUnidadeNegocio = categoriaViewModel.IdUnidadeNegocio
                    };

                    var retorno = _categoriaService.Put(categoria);

                    return RedirectToAction("Index");
                }


                return null;
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }


        }

        public IActionResult Delete(int id)
        {
            try
            {
                _categoriaService.Delete(id);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }
    }
}