using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canos.OfficeAutomatic.Contract.Vo
{
    public class NoticeBasicVo : NoticeVo
    {

        [JsonProperty("category")]
        public string Category { get; set; }
    }
}
