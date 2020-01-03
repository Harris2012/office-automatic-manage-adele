using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Canos.OfficeAutomatic.Utility
{
    public static class TimeConvertor
    {
        public static readonly DateTime TimeBase = new DateTime(1970, 1, 1);

        private static readonly int MillsSecondBase = 10000;

        public static DateTime FromMilliTicks(long millsTicks)
        {
            return new DateTime(TimeBase.Ticks + millsTicks * MillsSecondBase).ToLocalTime();
        }

        public static long ToMilliTicks(DateTime time)
        {
            return (time.ToUniversalTime() - TimeBase).Ticks / MillsSecondBase;
        }
    }
}
