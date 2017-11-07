using Data.Services.Categoria;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Services.UnidadeNegocio;
using WebApiTcc.ViewModel.Categoria;

namespace WebApiTcc.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IUnidadeNegocioService _unidadeNegocioService;


        public CategoriaController(ICategoriaService categoriaService, IUnidadeNegocioService unidadeNegocioService)
        {
            _categoriaService = categoriaService;
            _unidadeNegocioService = unidadeNegocioService;
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
                        IdUnidadeNegocio = item.IdUnidadeNegocio,
                        NomeUnidadeNegocio = item.NomeUnidadeNegocio
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
            var listUnidadeNegocio = _unidadeNegocioService.GetAll();

            var categoria = new CategoriaViewModel()
            {
                UnidadeNegocio = listUnidadeNegocio
            };
            return View("Create", categoria);
        }

        [HttpPost]
        public IActionResult Post(Categoria categoriaViewModel)
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

                }
                return RedirectToAction("Index");

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
                    var listUnidadeNegocio = _unidadeNegocioService.GetAll();

                    var categoria = new CategoriaViewModel()
                    {

                        IdCategoria = retorno.IdCategoria,
                        Nome = retorno.Nome,
                        Descricao = retorno.Descricao,
                        Ativo = retorno.Ativo,
                        IdUnidadeNegocio = retorno.IdUnidadeNegocio,
                        UnidadeNegocio = listUnidadeNegocio
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
            catch (Exception)
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
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
    }
}