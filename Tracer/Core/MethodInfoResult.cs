using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Core
{
    public struct MethodInfoResult
    {
        public string MethodName {  get; set; }
        public string ClassName { get; set; }
        public int Time {  get; set; }
        public List<MethodInfoResult> Methods { get; set; }
    }
}
