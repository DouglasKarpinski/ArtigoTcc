using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Estacao
{
    public class Estacao
    {
        public int IdEstacao { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
    }
}
