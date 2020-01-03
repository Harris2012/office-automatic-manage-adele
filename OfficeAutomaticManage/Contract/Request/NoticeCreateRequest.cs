using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Canos.OfficeAutomatic.Contract.Vo;

namespace Canos.OfficeAutomatic.Contract.Request
{
    public class NoticeCreateRequest
    {

        [JsonProperty("item")]
        public NoticeBasicVo Item { get; set; }
    }
}
