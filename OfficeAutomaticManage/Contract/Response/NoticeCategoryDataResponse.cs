using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Canos.OfficeAutomatic.Contract.Vo;
using Canos.OfficeAutomatic.Lookup;

namespace Canos.OfficeAutomatic.Contract.Response
{
    public class NoticeCategoryDataResponse : BaseResponse
    {
        [JsonProperty("headers")]
        public List<Header> Headers { get; set; }

        [JsonProperty("items")]
        public List<NoticeCategoryExtendedVo> Items { get; set; }
    }
}
