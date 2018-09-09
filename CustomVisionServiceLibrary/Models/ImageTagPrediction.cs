using Newtonsoft.Json;
using System;

namespace CustomVisionServiceLibrary.Models
{
    public class ImageTagPrediction
    {
        [JsonProperty("probability")]
        public double Probability { get; set; }

        [JsonProperty("tagId")]
        public Guid TagId { get; set; }

        [JsonProperty("tagName")]
        public string TagName { get; set; }

        [JsonProperty("boundingBox")]
        public BoundingBox BoundingBox { get; set; }  
    }
}
