using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.ConsultaSatisfacao
{
    public interface IConsultaSatisfacaoRepository
    {
        IEnumerable<ConsultaSatisfacao> Get(int idEstacao, DateTime? dataInicial, DateTime? dataFinal);
    }
}
