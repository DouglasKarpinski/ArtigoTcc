using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace Data.Services.ConsultaSatisfacao
{
    public class ConsultaSatisfacaoService : IConsultaSatisfacaoService
    {
        private readonly IConsultaSatisfacaoRepository _consultaSatisfacaoRepository;
        private const string _emotionWebApi = "http://localhost:51988/api/emotion";
        private readonly string _token = "tokenzao RU1PVElPTldFQkFQSUxFT05BUkRPRURPVUdMQVNUQ0MyMDE3";

        public ConsultaSatisfacaoService(IConsultaSatisfacaoRepository consultaSatisfacaoRepository)
        {
            _consultaSatisfacaoRepository = consultaSatisfacaoRepository;
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

                return JsonConvert.DeserializeObject<Retorno>(responseContent);
            }

            return null;
        }
    }
}
