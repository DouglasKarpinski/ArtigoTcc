using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.Produto
{
    public interface IProdutoRepository
    {
        IEnumerable<Services.Produto.Produto> GetAll();
    }
}
