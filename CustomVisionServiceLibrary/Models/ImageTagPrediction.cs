using System;

namespace CustomVisionServiceLibrary.Models
{
    public class ImageTagPrediction
    {
        public double Probability { get; set; }

        public Guid TagId { get; set; }

        public string TagName { get; set; }

        public ImageRegion Region { get; set; }  
    }
}
