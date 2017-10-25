using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Services.ConsultaSatisfacao;
using Data.Services.Estacao;
using Microsoft.AspNetCore.Mvc;
using WebApiTcc.ViewModel.ConsultaSatisfacao;
using WebApiTcc.ViewModel.Estacao;

namespace WebApiTcc.Controllers
{
    public class ConsultaSatisfacaoController : Controller
    {
        private readonly IEstacaoService _estacaoService;
        private readonly IConsultaSatisfacaoService _consultaSatisfacaoService;

        public ConsultaSatisfacaoController(IEstacaoService estacaoService, IConsultaSatisfacaoService consultaSatisfacao)
        {
            _estacaoService = estacaoService;
            _consultaSatisfacaoService = consultaSatisfacao;
        }

        public ActionResult Index()
        {
            try
            {
                var estacaoRequest = _estacaoService.GetAll();
                var estacao = new List<EstacaoViewModel>();

                if (estacaoRequest != null && estacaoRequest.Any())
                {
                    foreach (var item in estacaoRequest.Where(x => x.Ativo))
                    {
                        estacao.Add(new EstacaoViewModel
                        {
                            IdEstacao = item.IdEstacao,
                            Nome = item.Nome,
                            Descricao = item.Descricao,
                            Ativo = item.Ativo,
                            IdProduto = item.IdProduto,
                            NomeProduto = item.NomeProduto
                        });
                    }
                }

                return View("Index", new ConsultaSatisfacaoViewModel {ComboEstacao = estacao});
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message} \nException: {e.InnerException} \nOnde: {e.StackTrace}");
            }
        }

        public ActionResult Post(ConsultaSatisfacaoViewModel consultaSatisfacao)
        {
            try
            {
                var consultaSatisfacaoRequest = _consultaSatisfacaoService.Get(consultaSatisfacao.IdEstacao, consultaSatisfacao.DataInicial, consultaSatisfacao.DataInicial);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message} \nException: {e.InnerException} \nOnde: {e.StackTrace}");
            }
        }
    }
}
