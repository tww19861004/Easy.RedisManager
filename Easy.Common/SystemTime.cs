﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easy.Common
{
    public static class SystemTime
    {
        public static Func<DateTime> UtcDateTimeResolver;

        public static DateTime Now
        {
            get
            {
                var temp = UtcDateTimeResolver;
                return temp == null ? DateTime.Now : temp().ToLocalTime();
            }
        }

        public static DateTime UtcNow
        {
            get
            {
                var temp = UtcDateTimeResolver;
                return temp == null ? DateTime.UtcNow : temp();
            }
        }
    }
}
