using System;
using System.Collections.Generic;
using System.Text;

namespace CustomVisionLibrary.Models
{
    public class ImagePredictionResult
    {
        public Guid Id { get; set; }

        public Guid Project { get; set; }

        public Guid Iteration { get; set; }

        public DateTime Created { get; set; }

        public IList<ImageTagPrediction> Predictions { get; set; }
    }
}
