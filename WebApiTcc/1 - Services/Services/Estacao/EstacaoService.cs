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

        public Estacao Post(Estacao estacao)
        {
            try
            {
                return _estacaoRepository.Post(estacao);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Estacao GetById(int idEstacao)
        {
            try
            {
                return _estacaoRepository.GetById(idEstacao);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Estacao Put(Estacao estacao)
        {
            try
            {
                return _estacaoRepository.Put(estacao);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Delete(int idEstacao)
        {
            try
            {
                _estacaoRepository.Delete(idEstacao);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
