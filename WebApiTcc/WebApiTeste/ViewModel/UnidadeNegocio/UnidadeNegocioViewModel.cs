using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTcc.ViewModel.UnidadeNegocio
{
    public class UnidadeNegocioViewModel
    {
        public int IdUnidadeNegocio { get; set; }
        public string Nome { get; set; }
        public int IdGrupoEconomico { get; set; }
        public bool Ativo { get; set; }
    }
}
