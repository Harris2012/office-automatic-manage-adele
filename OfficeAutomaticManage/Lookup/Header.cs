using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canos.OfficeAutomatic.Lookup
{
    public class Header
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("align")]
        public string Align { get; set; }

        [JsonProperty("sortable")]
        public bool Sortable { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
