using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Services.Emotion;

namespace WebApiTcc.ViewModel.Emotion
{
    public class EmotionViewModel
    {
        public FaceRectangleViewModel FaceRetangle { get; set; }

        public ScoresViewModel Scores { get; set; }
    }
}
