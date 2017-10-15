using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Data.Services.Emotion
{
    public class FaceRetangle
    {
        [JsonProperty(PropertyName = "top")]
        public string Top { get; set; }

        [JsonProperty(PropertyName = "left")]
        public string Left { get; set; }

        [JsonProperty(PropertyName = "width")]
        public string Width { get; set; }

        [JsonProperty(PropertyName = "height")]
        public string Height { get; set; }
    }
}
