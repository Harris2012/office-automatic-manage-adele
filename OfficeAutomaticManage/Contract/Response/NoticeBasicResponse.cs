using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Canos.OfficeAutomatic.Contract.Vo;

namespace Canos.OfficeAutomatic.Contract.Response
{
    public class NoticeBasicResponse : BaseResponse
    {
        [JsonProperty("item")]
        public NoticeBasicVo Item { get; set; }
    }
}
