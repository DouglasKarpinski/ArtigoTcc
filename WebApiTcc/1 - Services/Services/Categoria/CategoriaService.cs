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
                return _categoriaRepository.Post(categoria);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Categoria GetById(int idCategoria)
        {
            try
            {
                return _categoriaRepository.GetById(idCategoria);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Categoria Put(Categoria categoria)
        {
            try
            {
                return _categoriaRepository.Put(categoria);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _categoriaRepository.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
