﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Data.Services.Emotion;
using Data.Services.Estacao;
using Microsoft.AspNetCore.Mvc;
using WebApiTcc.ViewModel.Emotion;
using WebApiTcc.ViewModel.Estacao;

namespace WebApiTcc.Controllers
{
    public class EmotionController : Controller
    {
        private readonly IEmotionService _emotionService;
        private readonly IEstacaoService _estacaoService;
        
        public EmotionController(IEmotionService emotionService, IEstacaoService estacaoService)
        {
            _emotionService = emotionService;
            _estacaoService = estacaoService;
        }

        public ActionResult Index()
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

            return View("Index", estacao);
        }

        public ActionResult PostDemonstration(string file, int? idEstacao)
        {
            try
            {
                var request = _emotionService.Demonstracao(file, idEstacao);

                if (request == null)
                    return BadRequest();

                var model = request.Select(item => new EmotionViewModel
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
                }).ToList();

                ViewBag.File = file;

                return PartialView("_Resultado", model);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message} \nException: {e.InnerException} \nOnde: {e.StackTrace}");
            }
        }
    }
}
