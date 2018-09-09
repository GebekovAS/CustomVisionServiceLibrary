using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomVisionServiceLibrary.Models
{
    public class ProjectSettings
    {
        [JsonProperty("domainId")]
        public Guid DomainId { get; set; }
    }
}
