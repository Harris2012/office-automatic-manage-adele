using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canos.OfficeAutomatic.Lookup.Implement
{
    public class NoticeLookupProvider : INoticeLookupProvider
    {
        public List<Header> Headers { get; private set; }

        public NoticeLookupProvider()
        {
            Headers = new List<Header>();

            Headers.Add(new Header { Text = "编号", Value = "id" });
            Headers.Add(new Header { Text = "标题", Value = "title" });
            Headers.Add(new Header { Text = "正文", Value = "body" });
            Headers.Add(new Header { Text = "分类", Value = "category" });
            Headers.Add(new Header { Text = "创建时间", Value = "createTime" });
            Headers.Add(new Header { Text = "最后更新时间", Value = "lastUpdateTime" });
        }
    }
}
