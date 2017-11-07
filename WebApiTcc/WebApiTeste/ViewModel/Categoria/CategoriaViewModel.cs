using System.Collections.Generic;
using Data.Services.UnidadeNegocio;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApiTcc.ViewModel.Categoria
{
    public class CategoriaViewModel
    {
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int IdUnidadeNegocio { get; set; }
        public bool Ativo { get; set; }
        public string NomeUnidadeNegocio { get; set; }

        public IEnumerable<Data.Services.UnidadeNegocio.UnidadeNegocio> UnidadeNegocio { get; set; }
    }
}
