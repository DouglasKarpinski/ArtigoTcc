using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTcc.ViewModel.Emotion;

namespace WebApiTcc.ViewModel.ConsultaSatisfacao
{
    public class RetornoViewModel
    {
        public int IdEstacao { get; set; }
        public IEnumerable<EmotionViewModel> Emotion { get; set; }
    }
}
