using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canos.OfficeAutomatic.Contract.Request
{
    public class NoticeDataRequest : NoticeCountRequest
    {
        public int? PageIndex { get; set; }
    }
}
