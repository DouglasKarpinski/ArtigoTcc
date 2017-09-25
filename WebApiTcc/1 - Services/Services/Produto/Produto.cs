using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Produto
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public int IdCategoria { get; set; }
    }
}
