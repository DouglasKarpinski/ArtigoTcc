using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Data.Services.Emotion
{
    public class Emotion
    {
        [JsonProperty(PropertyName = "faceRectangle")]
        public FaceRetangle FaceRetangle { get; set; }

        [JsonProperty(PropertyName = "scores")]
        public Scores Scores { get; set; }
    }
}
