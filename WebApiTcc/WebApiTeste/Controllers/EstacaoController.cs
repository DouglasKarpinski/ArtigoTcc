using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Services.Estacao;
using Data.Services.Produto;
using Microsoft.AspNetCore.Mvc;
using WebApiTcc.ViewModel.Estacao;
using WebApiTcc.ViewModel.Produto;


namespace WebApiTcc.Controllers
{
    public class EstacaoController : Controller
    {
        private readonly IEstacaoService _estacaoService;
        private readonly IProdutoService _produtoService;

        public EstacaoController(IEstacaoService estacaoService, IProdutoService produtoService)
        {
            _estacaoService = estacaoService;
            _produtoService = produtoService;
        }

        public IActionResult Index()
        {
            try
            {
                var retorno = _estacaoService.GetAll();

                var estacao = new List<EstacaoViewModel>();
                foreach (var item in retorno)
                {
                    estacao.Add(new EstacaoViewModel()
                    {
                        IdEstacao = item.IdEstacao,
                        Nome = item.Nome,
                        Descricao = item.Descricao,
                        Ativo = item.Ativo,
                        IdProduto = item.IdProduto,
                        NomeProduto= item.NomeProduto
                    });
                }

                return View("Index", estacao);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IActionResult Create()
        {
            var listProduto = _produtoService.GetAll();
            var estacao = new EstacaoViewModel()
            {
                Produtos = listProduto
            };
            return View("Create", estacao);
        }

        public IActionResult Post(ProdutoViewModel produtoViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var estacao = new Estacao()
                    {
                        Nome = produtoViewModel.Nome,
                        Descricao = produtoViewModel.Descricao,
                        Ativo = produtoViewModel.Ativo,
                        IdProduto = produtoViewModel.IdProduto
                    };

                    var retorno = _estacaoService.Post(estacao);

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
                var retorno = _estacaoService.GetById(id);
                if (retorno != null)
                {
                    var listProduto = _produtoService.GetAll();
                    var estacao = new EstacaoViewModel()
                    {

                        IdEstacao = retorno.IdEstacao,
                        Nome = retorno.Nome,
                        Descricao = retorno.Descricao,
                        Ativo = retorno.Ativo,
                        IdProduto = retorno.IdProduto,
                        Produtos = listProduto
                    };

                    return View("Edit", estacao);
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Put(EstacaoViewModel estacaoViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var estacao = new Estacao()
                    {
                        IdEstacao = estacaoViewModel.IdEstacao,
                        Nome = estacaoViewModel.Nome,
                        Descricao = estacaoViewModel.Descricao,
                        Ativo = estacaoViewModel.Ativo,
                        IdProduto = estacaoViewModel.IdProduto
                    };

                    var retorno = _estacaoService.Put(estacao);
                }

                return RedirectToAction("Index");
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
                _estacaoService.Delete(id);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }

    }
}
