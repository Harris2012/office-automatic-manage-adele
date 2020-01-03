using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Canos.OfficeAutomatic.Contract.Vo;

namespace Canos.OfficeAutomatic.Contract.Request
{
    /// <summary>
    /// 根据id(或主属性)更新单个通知公告
    /// </summary>
    public class NoticeUpdateRequest
    {
        /// <summary>
        /// id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// item
        /// </summary>
        [JsonProperty("item")]
        public NoticeBasicVo Item { get; set; }
    }
}
