using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Canos.OfficeAutomatic.Contract.Vo;

namespace Canos.OfficeAutomatic.Contract.Request
{
    /// <summary>
    /// 根据id(或主属性)更新单个通知分类
    /// </summary>
    public class NoticeCategoryUpdateRequest
    {
        /// <summary>
        /// id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// 主属性
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// item
        /// </summary>
        [JsonProperty("item")]
        public NoticeCategoryBasicVo Item { get; set; }
    }
}
