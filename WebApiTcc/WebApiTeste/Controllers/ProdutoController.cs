﻿using Data.Services.Produto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Data.Services.Categoria;
using WebApiTcc.ViewModel.Produto;

namespace WebApiTcc.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly ICategoriaService _categoriaService;

        public ProdutoController(IProdutoService produtoService, ICategoriaService categoriaService)
        {
            _produtoService = produtoService;
            _categoriaService = categoriaService;
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
            var listCategorias = _categoriaService.GetAll();
            var produto = new ProdutoViewModel()
            {
                Categoria = listCategorias
            };
            return View("Create", produto);
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

        public IActionResult Edit(int id)
        {
            try
            {
                var retorno = _produtoService.GetById(id);
                if (retorno != null)
                {
                    var listCategorias = _categoriaService.GetAll();
                    var produto = new ProdutoViewModel()
                    {

                        IdProduto = retorno.IdProduto,
                        Nome = retorno.Nome,
                        Descricao = retorno.Descricao,
                        Ativo = retorno.Ativo,
                        IdCategoria = retorno.IdCategoria,
                        Categoria = listCategorias
                    };

                    return View("Edit", produto);
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Put(ProdutoViewModel produtoViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var produto = new Produto()
                    {
                        IdProduto = produtoViewModel.IdProduto,
                        Nome = produtoViewModel.Nome,
                        Descricao = produtoViewModel.Descricao,
                        Ativo = produtoViewModel.Ativo,
                        IdCategoria = produtoViewModel.IdCategoria
                    };

                    var retorno = _produtoService.Put(produto);
                }

                return RedirectToAction("Index");
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
                _produtoService.Delete(id);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }
    }
}