using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Canos.OfficeAutomatic.Contract.Vo;

namespace Canos.OfficeAutomatic.Contract.Response
{
    public class NoticeEmptyResponse : BaseResponse
    {

        [JsonProperty("category")]
        public List<MetaNoticeCategoryVo> Category { get; set; }
    }
}
