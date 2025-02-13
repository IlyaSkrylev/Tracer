using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Core
{
    public struct TraceResult
    {
        public List<ThreadInfoResult> ThreadInfoResults { get; set; }
    }
}
