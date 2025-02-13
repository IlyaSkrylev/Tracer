﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tracer.Core;
using Tracer.Core.Abstractions;

namespace Tracer.Example
{
    class Program
    {
        private static void Main(string[] args)
        {
            ITracer tracer = new Core.Tracer();

            Thread[] threads = new Thread[5];
            for (int i = 0; i < threads.Length; i++)
            {
                int threadIndex = i;
                threads[i] = new Thread(() => threadFunc(threadIndex, tracer));
                threads[i].Start();
            }

            foreach (Thread thread in threads) thread.Join();

            var traceResult = tracer.GetTraceResult();
            ShowResults(traceResult);
        }

        private static void threadFunc(int threadIndex, ITracer _tracer)
        {
            var foo = new Foo(_tracer);
            foo.MyMethod();
            foo.MyMethod();
        }

        private static void ShowResults(TraceResult traceResult)
        {
            foreach (var threadRes in traceResult.ThreadInfoResults)
            {
                Console.WriteLine("id: " + threadRes.ThreadId);
                Console.WriteLine("time: " + threadRes.Time);
                Console.WriteLine("Methods: ");
                foreach (var methodResults in threadRes.Methods)
                {
                    ShowMethodsResults(methodResults, 0);
                }
            }
        }

        private static void ShowMethodsResults(MethodInfoResult methodRes, int nesting)
        {
            string substr = "        ";
            for (int i = 0; i < nesting; i++)
                substr += "        ";
            Console.WriteLine(substr + "class: " + methodRes.ClassName);
            Console.WriteLine(substr + "method: " + methodRes.MethodName);
            Console.WriteLine(substr + "time: " + methodRes.Time);
            if (methodRes.Methods.Count > 0)
                Console.WriteLine(substr + "Methods: ");
            foreach(var methodResults in methodRes.Methods)
            { 

                ShowMethodsResults(methodResults, ++nesting); 
            }
        }
    }

    public class Foo
    {
        private Bar _bar;
        private ITracer _tracer;

        internal Foo(ITracer tracer)
        {
            _tracer = tracer;
            _bar = new Bar(_tracer);
        }

        public void MyMethod()
        {
            _tracer.StartTrace();
            Thread.Sleep(200);
            _bar.InnerMethod();
            Thread.Sleep(500);
            _tracer.StopTrace();
        }
    }

    public class Bar
    {
        private ITracer _tracer;

        internal Bar(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void InnerMethod()
        {
            _tracer.StartTrace();
            Thread.Sleep(200);
            _tracer.StopTrace();
        }
    }
}
