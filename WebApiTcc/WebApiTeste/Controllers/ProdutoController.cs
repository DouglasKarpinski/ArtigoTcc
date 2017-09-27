using Data.Services.Produto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApiTcc.ViewModel.Produto;

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
            var produtos = new List<ProdutoViewModel>();

            foreach (var item in produto)
            {
                produtos.Add(new ProdutoViewModel()
                {
                    IdProduto = item.IdProduto,
                    Nome = item.Nome,
                    Descricao = item.Descricao,
                    Ativo = item.Ativo,
                    IdCategoria = item.IdCategoria,
                    NomeCategoria = item.NomeCategoria
                });
            }

            return View(produtos);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        public IActionResult Post(ProdutoViewModel produtoViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var produto = new Produto()
                    {
                        Nome = produtoViewModel.Nome,
                        Descricao = produtoViewModel.Descricao,
                        Ativo = produtoViewModel.Ativo,
                        IdCategoria = produtoViewModel.IdCategoria
                    };

                    var retorno = _produtoService.Post(produto);

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
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