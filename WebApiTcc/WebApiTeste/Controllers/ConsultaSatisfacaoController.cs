using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Services.ConsultaSatisfacao;
using Data.Services.Estacao;
using Microsoft.AspNetCore.Mvc;
using WebApiTcc.ViewModel.ConsultaSatisfacao;
using WebApiTcc.ViewModel.Emotion;
using WebApiTcc.ViewModel.Estacao;
using WebApiTcc.ViewModel.Produto;

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

                return View("Index", new ConsultaSatisfacaoViewModel { ComboEstacao = estacao });
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
                var consultaSatisfacaoRequest = _consultaSatisfacaoService.Get(consultaSatisfacao.IdEstacao, consultaSatisfacao.DataInicial, consultaSatisfacao.DataFinal);

                if (consultaSatisfacaoRequest != null)
                {
                    var model = new ConsultaSatisfacaoViewModel
                    {
                        Retorno = new RetornoViewModel
                        {
                            IdEstacao = consultaSatisfacaoRequest.IdEstacao,
                            Estacao = new EstacaoViewModel
                            {
                              IdEstacao  = consultaSatisfacaoRequest.Estacao.IdEstacao,
                              Nome = consultaSatisfacaoRequest.Estacao.Nome,
                              Descricao = consultaSatisfacaoRequest.Estacao.Descricao,
                              Produto = new ProdutoViewModel
                              {
                                  IdProduto = consultaSatisfacaoRequest.Estacao.IdProduto,
                                  Nome = consultaSatisfacaoRequest.Estacao.Produto.Nome,
                                  Descricao = consultaSatisfacaoRequest.Estacao.Produto.Descricao
                              }
                            },
                            Emotion = consultaSatisfacaoRequest.Emotion.Select(item => new EmotionViewModel
                            {
                                FaceRetangle = new FaceRectangleViewModel
                                {
                                    Height = decimal.Parse(item.FaceRetangle.Height),
                                    Left = decimal.Parse(item.FaceRetangle.Left),
                                    Top = decimal.Parse(item.FaceRetangle.Top),
                                    Width = decimal.Parse(item.FaceRetangle.Width)
                                },
                                Scores = new ScoresViewModel
                                {
                                    Anger = item.Scores.Anger,
                                    Contempt = item.Scores.Contempt,
                                    Disgust = item.Scores.Disgust,
                                    Fear = item.Scores.Fear,
                                    Happiness = item.Scores.Happiness,
                                    Neutral = item.Scores.Neutral,
                                    Sadness = item.Scores.Sadness,
                                    Surprise = item.Scores.Surprise
                                }
                            })
                        }
                    };

                    return PartialView("_Retorno", model);
                }

                return PartialView("_Retorno", new ConsultaSatisfacaoViewModel());
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message} \nException: {e.InnerException} \nOnde: {e.StackTrace}");
            }
        }
    }
}
