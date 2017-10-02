using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Services.Estacao;
using Microsoft.AspNetCore.Mvc;
using WebApiTcc.ViewModel.Estacao;


namespace WebApiTcc.Controllers
{
    public class EstacaoController : Controller
    {
        private readonly IEstacaoService _estacaoService;

        public EstacaoController(IEstacaoService estacaoService)
        {
            _estacaoService = estacaoService;
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
            throw new NotImplementedException();
        }

        public IActionResult Edit()
        {
            throw new NotImplementedException();
        }

        public IActionResult Delete()
        {
            throw new NotImplementedException();
        }
    }
}
