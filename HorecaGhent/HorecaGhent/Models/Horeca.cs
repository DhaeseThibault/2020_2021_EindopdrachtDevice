using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HorecaGhent.Models
{
    public class Horeca
    {
        public string Name { get; set; }
        public string Offer { get; set; }
        public string Kitchen { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string SiteURL { get; set; }
        public string ImageURL { get; set; }


        [JsonExtensionData]
        private Dictionary<string, JToken> _fieldData = new Dictionary<string, JToken>();

        [OnDeserialized]
        private void ProcessExtraJsonData(StreamingContext context)
        {
            JToken fieldData = (JToken)_fieldData["fields"];
            Name = (string)fieldData.SelectToken("naam");
            Offer = (string)fieldData.SelectToken("aanbod");
            Kitchen = (string)fieldData.SelectToken("keuken");
            Address = (string)fieldData.SelectToken("adres");
            ZipCode = (int)fieldData.SelectToken("postcode");
            City = (string)fieldData.SelectToken("gemeente");
            PhoneNumber = (string)fieldData.SelectToken("telefoonnummer");
            SiteURL = (string)fieldData.SelectToken("link");
            ImageURL = (string)fieldData.SelectToken("image_path");
        }
    }
}
