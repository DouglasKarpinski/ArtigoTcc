using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.UnidadeNegocio
{
    public class UnidadeNegocio
    {
        public UnidadeNegocio(string nome)
        {
            Nome = nome;
        }

        public UnidadeNegocio(int idUnidadeNegocio, string nome, int idGrupoEconomico, bool ativo)
        {
            IdUnidadeNegocio = idUnidadeNegocio;
            Nome = nome;
            IdGrupoEconomico = idGrupoEconomico;
            Ativo = ativo;
        }

        public int IdUnidadeNegocio { get; set; }
        public string Nome { get; set; }
        public int IdGrupoEconomico { get; set; }
        public bool Ativo { get; set; }
    }
}
