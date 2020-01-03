using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canos.OfficeAutomatic.Contract.Vo
{
    public class NoticeExtendedVo : NoticeVo
    {

        [JsonProperty("category")]
        public MetaNoticeCategoryVo Category { get; set; }
    }
}
