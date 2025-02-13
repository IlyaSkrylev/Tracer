using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Core.Tests;

namespace Tracer.Core
{
    public struct ThreadInfoResult
    {
        public int ThreadId { get; set; }
        public int Time { get; set; }
        public List<MethodInfoResult> Methods { get; set; }
    }
}
