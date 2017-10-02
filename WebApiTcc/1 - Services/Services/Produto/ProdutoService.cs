using Data.Repository.Produto;
using System;
using System.Collections.Generic;

namespace Data.Services.Produto
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<Produto> GetAll()
        {
            try
            {
                return _produtoRepository.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Produto Post(Produto produto)
        {
            return _produtoRepository.Post(produto);
            return null;
        }

        public Produto GetById(int idProduto)
        {
            try
            {
                return _produtoRepository.GetById(idProduto);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Produto Put(Produto produto)
        {
            try
            {
                return _produtoRepository.Put(produto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Delete(int idProduto)
        {
            try
            {
                _produtoRepository.Delete(idProduto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
