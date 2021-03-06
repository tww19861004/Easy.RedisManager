﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easy.Common
{
    public class Tracer
    {
        public static ITracer Instance = new NullTracer();

        public class NullTracer : ITracer
        {
            public void WriteDebug(string error) { }

            public void WriteDebug(string format, params object[] args) { }

            public void WriteWarning(string warning) { }

            public void WriteWarning(string format, params object[] args) { }

            public void WriteError(Exception ex) { }

            public void WriteError(string error) { }

            public void WriteError(string format, params object[] args) { }

        }

        public class ConsoleTracer : ITracer
        {
            public void WriteDebug(string error)
            {
                PclExport.Instance.WriteLine(error);
            }

            public void WriteDebug(string format, params object[] args)
            {
                PclExport.Instance.WriteLine(format, args);
            }

            public void WriteWarning(string warning)
            {
                PclExport.Instance.WriteLine(warning);
            }

            public void WriteWarning(string format, params object[] args)
            {
                PclExport.Instance.WriteLine(format, args);
            }

            public void WriteError(Exception ex)
            {
                PclExport.Instance.WriteLine(ex.ToString());
            }

            public void WriteError(string error)
            {
                PclExport.Instance.WriteLine(error);
            }

            public void WriteError(string format, params object[] args)
            {
                PclExport.Instance.WriteLine(format, args);
            }
        }
    }

    public static class TracerExceptions
    {
        public static T Trace<T>(this T ex) where T : Exception
        {
            Tracer.Instance.WriteError(ex);
            return ex;
        }
    }
}
