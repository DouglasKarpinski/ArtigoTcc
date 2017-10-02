using System.Collections.Generic;

namespace Data.Services.Produto
{
    public interface IProdutoService
    {
        IEnumerable<Produto> GetAll();
        Produto Post(Produto produto);
        Produto GetById(int id);
        Produto Put(Produto produto);
        void Delete(int id);
    }
}
