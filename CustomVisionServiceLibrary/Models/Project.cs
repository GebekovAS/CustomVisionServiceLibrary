using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomVisionServiceLibrary.Models
{
    public class Project
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        //public Guid? CurrentIterationId { get; set; }

        [JsonProperty("settings")]
        public ProjectSettings Settings { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("lastModified")]
        public DateTime LastModified { get; set; }

        [JsonProperty("thumbnailUri")]
        public string ThumbnailUri { get; set; }
    }
}
