using System;
using System.Collections.Generic;
using System.Text;
using Data.Repository.Produto;

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
    }
}
