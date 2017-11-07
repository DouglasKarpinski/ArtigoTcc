using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.UnidadeNegocio
{
    public class UnidadeNegocioService : IUnidadeNegocioService
    {
        private readonly IUnidadeNegocioRepository _unidadeNegocioRepository;

        public UnidadeNegocioService(IUnidadeNegocioRepository unidadeNegocioRepository)
        {
            _unidadeNegocioRepository = unidadeNegocioRepository;
        }

        public IEnumerable<UnidadeNegocio> GetAll()
        {
            return _unidadeNegocioRepository.GetAll();
        }
    }
}
