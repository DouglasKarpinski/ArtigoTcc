using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Data.Services.Emotion
{
    public class Scores
    {
        [JsonProperty(PropertyName = "anger")]
        public string Anger { get; set; }

        [JsonProperty(PropertyName = "contempt")]
        public string Contempt { get; set; }

        [JsonProperty(PropertyName = "disgust")]
        public string Disgust { get; set; }

        [JsonProperty(PropertyName = "fear")]
        public string Fear { get; set; }

        [JsonProperty(PropertyName = "happiness")]
        public string Happiness { get; set; }

        [JsonProperty(PropertyName = "neutral")]
        public string Neutral { get; set; }

        [JsonProperty(PropertyName = "sadness")]
        public string Sadness { get; set; }

        [JsonProperty(PropertyName = "surprise")]
        public string Surprise { get; set; }
    }
}
