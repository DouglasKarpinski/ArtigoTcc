using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.ConsultaSatisfacao
{
    public class ConsultaSatisfacaoService : IConsultaSatisfacaoService
    {
        private readonly IConsultaSatisfacaoRepository _consultaSatisfacaoRepository;

        public ConsultaSatisfacaoService(IConsultaSatisfacaoRepository consultaSatisfacaoRepository)
        {
            _consultaSatisfacaoRepository = consultaSatisfacaoRepository;
        }

        public IEnumerable<ConsultaSatisfacao> Get(int idEstacao, DateTime? dataInicial, DateTime? dataFinal)
        {
            var retorno = _consultaSatisfacaoRepository.Get(idEstacao, dataInicial, dataFinal);

            return retorno;
        }
    }
}
