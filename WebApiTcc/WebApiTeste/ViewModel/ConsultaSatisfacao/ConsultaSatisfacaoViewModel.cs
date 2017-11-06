using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Services.ConsultaSatisfacao;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApiTcc.ViewModel.Estacao;

namespace WebApiTcc.ViewModel.ConsultaSatisfacao
{
    public class ConsultaSatisfacaoViewModel
    {

        public int IdEstacao { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }

        public RetornoViewModel Retorno { get; set; }

        public IEnumerable<EstacaoViewModel> ComboEstacao { get; set; }
    }
}
