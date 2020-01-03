using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canos.OfficeAutomatic.Contract.Vo
{
    public abstract class NoticeCategoryVo
    {

        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("remark")]
        public string Remark { get; set; }

        [JsonProperty("dataStatus")]
        public int? DataStatus { get; set; }

        [JsonProperty("createTime")]
        public DateTime? CreateTime { get; set; }

        [JsonProperty("lastUpdateTime")]
        public DateTime? LastUpdateTime { get; set; }
    }
}
