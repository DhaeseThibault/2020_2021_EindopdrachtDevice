using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HorecaGhent.Models
{
    public class TrelloList
    {
        [JsonProperty(PropertyName = "id")]     // name in Json
        public string ListId { get; set; }      // name of property we want to use
        public string Name { get; set; }
    }
}
