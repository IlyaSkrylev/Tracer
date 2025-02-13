using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Core;
using Tracer.Serialization.Abstractions;

namespace Tracer.Serialization
{
    internal class TraceResultSerializer : ITraceResultSerializer
    {
        string ITraceResultSerializer.Format => throw new NotImplementedException();

        void ITraceResultSerializer.Serialize(TraceResult traceResult, Stream to)
        {
            throw new NotImplementedException();
        }
    }
}
