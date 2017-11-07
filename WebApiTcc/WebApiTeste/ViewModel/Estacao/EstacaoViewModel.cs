using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTcc.ViewModel.Estacao
{
    public class EstacaoViewModel
    {
        public int IdEstacao { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }

        public IEnumerable<Data.Services.Produto.Produto> Produto { get; set; }
    }
}
