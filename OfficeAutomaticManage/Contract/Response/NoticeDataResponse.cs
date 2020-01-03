using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Canos.OfficeAutomatic.Contract.Vo;
using Canos.OfficeAutomatic.Lookup;

namespace Canos.OfficeAutomatic.Contract.Response
{
    public class NoticeDataResponse : BaseResponse
    {
        [JsonProperty("headers")]
        public List<Header> Headers { get; set; }

        [JsonProperty("items")]
        public List<NoticeExtendedVo> Items { get; set; }
    }
}
