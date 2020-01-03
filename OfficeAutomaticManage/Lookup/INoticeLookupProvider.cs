using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canos.OfficeAutomatic.Lookup
{
    public interface INoticeLookupProvider
    {
        List<Header> Headers { get; }
    }
}
