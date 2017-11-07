using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Data.Repository.Produto;
using Data.Services.Estacao;
using Newtonsoft.Json;

namespace Data.Services.ConsultaSatisfacao
{
    public class ConsultaSatisfacaoService : IConsultaSatisfacaoService
    {
        private readonly IConsultaSatisfacaoRepository _consultaSatisfacaoRepository;
        private readonly IEstacaoRepository _estacaoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private const string _emotionWebApi = "http://emotionwebapi.azurewebsites.net/api/emotion/";
        private readonly string _token = "tokenzao RU1PVElPTldFQkFQSUxFT05BUkRPRURPVUdMQVNUQ0MyMDE3";

        public ConsultaSatisfacaoService(IConsultaSatisfacaoRepository consultaSatisfacaoRepository, IEstacaoRepository estacaoRepository, IProdutoRepository produtoRepository)
        {
            _consultaSatisfacaoRepository = consultaSatisfacaoRepository;
            _estacaoRepository = estacaoRepository;
            _produtoRepository = produtoRepository;
        }

        public Retorno Get(int idEstacao, DateTime? dataInicial, DateTime? dataFinal)
        {
            var produtoEstacaoImagem = _consultaSatisfacaoRepository.Get(idEstacao, dataInicial, dataFinal);

            if (produtoEstacaoImagem.Any())
            {
                var client = new HttpClient();

                client.DefaultRequestHeaders.Add("Authorization", _token);

                var content = JsonConvert.SerializeObject(produtoEstacaoImagem);
                var buffer = Encoding.UTF8.GetBytes(content);

                var byteContent = new ByteArrayContent(buffer);

                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = client.PostAsync(_emotionWebApi, byteContent).Result;

                if (!response.IsSuccessStatusCode)
                    throw new HttpRequestException("Ops...............Algo errado aconteceu, verifique!");

                var responseContent = response.Content.ReadAsStringAsync().Result;

                var retorno =  JsonConvert.DeserializeObject<Retorno>(responseContent);

                retorno.Estacao = _estacaoRepository.GetById(idEstacao);

                retorno.Estacao.Produto = _produtoRepository.GetById(retorno.Estacao.IdProduto);

                return retorno;
            }

            return null;
        }
    }
}
