using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomVisionServiceLibrary.Models
{
    public class PerTagPerformance
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("precision")]
        public double Precision { get; set; }

        [JsonProperty("precisionStdDeviation")]
        public double PrecisionStdDeviation { get; set; }

        [JsonProperty("recall")]
        public double Recall { get; set; }

        [JsonProperty("recallStdDeviation")]
        public double RecallStdDeviation { get; set; }

        [JsonProperty("averagePrecision")]
        public double AveragePrecision { get; set; }
    }
}
