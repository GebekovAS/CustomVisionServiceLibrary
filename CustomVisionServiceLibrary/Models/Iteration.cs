using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomVisionServiceLibrary.Models
{
    public class Iteration
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("isDefault")]
        public bool IsDefault { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("create")]
        public DateTime Created { get; set; }

        [JsonProperty("lastModified")]
        public DateTime LastModified { get; set; }

        [JsonProperty("trainedAt")]
        public DateTime? TrainedAt { get; set; }

        [JsonProperty("projectId")]
        public Guid ProjectId { get; set; }

        [JsonProperty("exportable")]
        public bool Exportable { get; set; }

        [JsonProperty("domainId")]
        public Guid DomainId { get; set; }

        
    }
}
