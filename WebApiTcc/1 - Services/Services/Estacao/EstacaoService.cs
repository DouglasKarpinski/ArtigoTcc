using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Estacao
{
    public class EstacaoService : IEstacaoService
    {
        private readonly IEstacaoRepository _estacaoRepository;

        public EstacaoService(IEstacaoRepository estacaoRepository)
        {
            _estacaoRepository = estacaoRepository;
        }

        public IEnumerable<Estacao> GetAll()
        {
            try
            {
                return _estacaoRepository.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
