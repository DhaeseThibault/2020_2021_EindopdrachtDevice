using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HorecaGhent.Models
{
    public class TrelloBoard
    {
        [JsonProperty(PropertyName = "id")] // name in Json
        public string BoardId { get; set; } // name of property we want to use

        public string Name { get; set; }

        [JsonProperty(PropertyName = "starred")] // name in Json
        public bool IsFavorite { get; set; }
    }
}
