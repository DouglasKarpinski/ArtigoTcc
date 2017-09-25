using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTcc.ViewModel.Produto
{
    public class ProdutoViewModel
    {
        public int IdProduto { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public int IdCategoria { get; set; }
    }
}
