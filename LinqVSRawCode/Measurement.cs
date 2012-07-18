using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LinqVSRawCode
{
    public class Measurement : IDisposable
    {
        public string Title { get; set; }
        public bool IsBaseline { get; set; }
        private Stopwatch stopwatch;
        private static Stopwatch baseline;

        public Measurement(string title)
        {
            for (int i = 0; i < 5; i++) {
                GC.WaitForPendingFinalizers();
                GC.GetTotalMemory(true);
            }
            Title = title;
            Console.Write("{0,-17} ", title + ":");
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        public Measurement SetBaseline(bool isBaseline = true)
        {
            IsBaseline = isBaseline;
            return this;
        }

        public void Dispose()
        {
            stopwatch.Stop();
            Console.Write("{0,7:F2}ms", stopwatch.Elapsed.TotalMilliseconds);
            if (IsBaseline) {
                baseline = stopwatch;
                Console.Write(", baseline");
            }
            else if (baseline!=null)
                Console.Write(", x{0,5:F2}", (stopwatch.Elapsed.TotalMilliseconds / baseline.Elapsed.TotalMilliseconds));
            Console.WriteLine();
        }
    }
}
