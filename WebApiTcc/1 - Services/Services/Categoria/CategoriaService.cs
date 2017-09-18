using Data.Repository.Categoria;
using System;
using System.Collections.Generic;

namespace Data.Services.Categoria
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }


        public IEnumerable<Categoria> GetAll()
        {
            try
            {
                var retorno = _categoriaRepository.GetAll();

                return retorno;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Categoria Post(Categoria categoria)
        {
            try
            {
                 _categoriaRepository.Post(categoria);

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
