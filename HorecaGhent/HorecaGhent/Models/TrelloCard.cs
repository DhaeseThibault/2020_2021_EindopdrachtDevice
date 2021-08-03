using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HorecaGhent.Models
{
    public class TrelloCard
    {
        [JsonProperty(PropertyName = "name")] // name in Json
        public string Name { get; set; }

        [JsonProperty(PropertyName = "closed")] // name in Json
        public bool IsClosed { get; set; }
    }
}
