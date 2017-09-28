using System.Collections.Generic;

namespace Data.Repository.Produto
{
    public interface IProdutoRepository
    {
        IEnumerable<Services.Produto.Produto> GetAll();
        Services.Produto.Produto Post(Services.Produto.Produto produto);
    }
}
