using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace LinqVSRawCode
{
    public static class Measurement
    {
        private const int DefaultTryCount = 10;
        private static double baseline;

        public static void Run(string title, Func<object> action)
        {
            Run(title, false, DefaultTryCount, action);
        }

        public static void Run(string title, int tryCount, Func<object> action)
        {
            Run(title, false, tryCount, action);
        }

        public static void Run(string title, bool isBaseline, Func<object> action)
        {
            Run(title, isBaseline, DefaultTryCount, action);
        }

        public static void Run(string title, bool isBaseline, int tryCount, Func<object> action)
        {
            Console.Write("  {0,-17} ", title + ":");
            object result = null;
            Stopwatch bestTimer = null;
            
            for (int i = 0; i < tryCount; i++) {
                for (int j = 0; j < 5; j++) {
                    Thread.Sleep(10);
                    GC.WaitForPendingFinalizers();
                    GC.GetTotalMemory(true);
                }
                var timer = new Stopwatch();
                timer.Start();
                result = action.Invoke();
                timer.Stop();
                if (bestTimer==null || bestTimer.Elapsed > timer.Elapsed)
                    bestTimer = timer;
            }
            
            double time = bestTimer.Elapsed.TotalMilliseconds;
            if (time < 0.05) {
                // Too short, let's use average instead of min time
                for (int j = 0; j < 5; j++) {
                    Thread.Sleep(10);
                    GC.WaitForPendingFinalizers();
                    GC.GetTotalMemory(true);
                }
                var timer = new Stopwatch();
                timer.Start();
                int tryCount2 = tryCount*10;
                for (int i = tryCount2; i > 0; i--)
                    result = action.Invoke();
                timer.Stop();
                time = timer.Elapsed.TotalMilliseconds / tryCount2;
            }

            bool timeInMS = time >= 0.1;
            Console.Write("{0,8:F3}{1}", timeInMS ? time : time * 1000, timeInMS ? "ms" : "ns");

            if (isBaseline) {
                baseline = time;
                Console.Write(", baseline");
            }
            else if (baseline!=null)
                Console.Write(", x{0,5:F2}", time / baseline);
            Console.WriteLine();
            
            if (result is IEnumerable<int> && !(result is List<int>))
                Console.WriteLine("    Enumerator:    {0}", (result as IEnumerable<int>).GetEnumerator().GetType().Name);
            else if (result is IEnumerable<string>)
                Console.WriteLine("    Enumerator:    {0}", (result as IEnumerable<string>).GetEnumerator().GetType().Name);
        }
    }
}
