using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Estacao
{
    public interface IEstacaoRepository
    {
        IEnumerable<Estacao> GetAll();
        Estacao Post(Estacao estacao);
        Estacao GetById(int idEstacao);
        Estacao Put(Estacao estacao);
        void Delete(int idEstacao);
    }
}
