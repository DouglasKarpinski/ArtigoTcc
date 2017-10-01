using System.Collections.Generic;

namespace Data.Services.Produto
{
    public interface IProdutoRepository
    {
        IEnumerable<Data.Services.Produto.Produto> GetAll();
    }
}
