using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.ConsultaSatisfacao
{
    public class Retorno
    {
        public int IdEstacao { get; set; }
        public List<Emotion.Emotion> Emotion { get; set; }
    }
}
