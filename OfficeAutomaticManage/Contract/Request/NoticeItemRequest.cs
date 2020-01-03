using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Canos.OfficeAutomatic.Contract.Request
{
    /// <summary>
    /// 根据id(或主属性)获取单个通知公告
    /// </summary>
    public class NoticeItemRequest
    {
        /// <summary>
        /// id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
