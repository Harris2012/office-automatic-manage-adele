using Canos.OfficeAutomatic.Contract.Vo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canos.OfficeAutomatic.Contract.Response
{
    public class MetaNoticeCategorySelectedItemsResponse : BaseResponse
    {
        [JsonProperty("items")]
        public List<MetaNoticeCategoryVo> Items { get; set; }
    }
}
