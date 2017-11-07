using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebApiTcc.ViewModel.Emotion;
using WebApiTcc.ViewModel.Estacao;

namespace WebApiTcc.ViewModel.ConsultaSatisfacao
{
    public class RetornoViewModel
    {
        public int IdEstacao { get; set; }

        public EstacaoViewModel Estacao { get; set; }
        public IEnumerable<EmotionViewModel> Emotion { get; set; }

        public double QuantidadeImagensCapturadas => Emotion.Count();

        public double MediaRaiva => Emotion.Sum(x => double.Parse(x.Scores.Anger, NumberStyles.Float | NumberStyles.AllowExponent, CultureInfo.InvariantCulture)) / QuantidadeImagensCapturadas;
        public double MediaDesprezo => Emotion.Sum(x => double.Parse(x.Scores.Contempt, NumberStyles.Float | NumberStyles.AllowExponent, CultureInfo.InvariantCulture)) / QuantidadeImagensCapturadas;
        public double MediaDesgosto => Emotion.Sum(x => double.Parse(x.Scores.Disgust, NumberStyles.Float | NumberStyles.AllowExponent, CultureInfo.InvariantCulture)) / QuantidadeImagensCapturadas;
        public double MediaMedo => Emotion.Sum(x => double.Parse(x.Scores.Fear, NumberStyles.Float | NumberStyles.AllowExponent, CultureInfo.InvariantCulture)) / QuantidadeImagensCapturadas;
        public double MediaFelicidade => Emotion.Sum(x => double.Parse(x.Scores.Happiness, NumberStyles.Float | NumberStyles.AllowExponent, CultureInfo.InvariantCulture)) / QuantidadeImagensCapturadas;
        public double MediaNeutro => Emotion.Sum(x => double.Parse(x.Scores.Neutral, NumberStyles.Float | NumberStyles.AllowExponent, CultureInfo.InvariantCulture)) / QuantidadeImagensCapturadas;
        public double MediaTristeza => Emotion.Sum(x => double.Parse(x.Scores.Sadness, NumberStyles.Float | NumberStyles.AllowExponent, CultureInfo.InvariantCulture)) / QuantidadeImagensCapturadas;
        public double MediaSurpresa => Emotion.Sum(x => double.Parse(x.Scores.Surprise, NumberStyles.Float | NumberStyles.AllowExponent, CultureInfo.InvariantCulture)) / QuantidadeImagensCapturadas;
    }
}
