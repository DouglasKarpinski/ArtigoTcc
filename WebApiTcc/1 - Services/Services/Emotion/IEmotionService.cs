using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Emotion
{
    public interface IEmotionService
    {
        IList<Emotion> Demonstracao(string file, int? idEstacao);
    }
}
