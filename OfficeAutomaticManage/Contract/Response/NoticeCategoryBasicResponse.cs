using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Canos.OfficeAutomatic.Contract.Vo;

namespace Canos.OfficeAutomatic.Contract.Response
{
    public class NoticeCategoryBasicResponse : BaseResponse
    {
        [JsonProperty("item")]
        public NoticeCategoryBasicVo Item { get; set; }
    }
}
