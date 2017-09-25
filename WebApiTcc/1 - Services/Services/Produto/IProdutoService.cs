using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Produto
{
    public interface IProdutoService
    {
        IEnumerable<Produto> GetAll();
    }
}
