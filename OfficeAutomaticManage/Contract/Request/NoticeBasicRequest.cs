using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canos.OfficeAutomatic.Contract.Request
{
    /// <summary>
    /// 根据`id`或`主属性(需要带上级，如果有)`获取单个通知公告
    /// </summary>
    public class NoticeBasicRequest
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
    }
}
