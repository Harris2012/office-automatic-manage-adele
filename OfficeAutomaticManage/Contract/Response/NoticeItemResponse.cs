using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Canos.OfficeAutomatic.Contract.Vo;

namespace Canos.OfficeAutomatic.Contract.Response
{
    public class NoticeItemResponse : BaseResponse
    {
        [JsonProperty("item")]
        public NoticeExtendedVo Item { get; set; }
    }
}
