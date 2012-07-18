using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqVSRawCode
{
    public class Test
    {
        static void Main(string[] args)
        {
            new Test().RunWithWarmup(int.Parse(args.FirstOrDefault() ?? "1000000"));
        }

        private void RunWithWarmup(int iterationCount)
        {
            Console.WriteLine("Iteration count: {0}", iterationCount);
            Console.WriteLine("Warmup...");
            var standardOut = Console.Out;
            Console.SetOut(TextWriter.Null);
            Run(Math.Max(Math.Min(1000000, iterationCount), iterationCount / 10));

            Console.SetOut(standardOut);
            Console.WriteLine("  Done.");
            Run(iterationCount);
        }

        private void Run(int iterationCount)
        {
            var rnd = new Random();
            int max = 1000;
            int border = max / 2;
            var array = Enumerable.Range(0, iterationCount)
                .Select(i => rnd.Next(max))
                .ToArray();
            var list = array.ToList();
            var sequence = new ArrayToSequenceWrapper<int>(array);
            IEnumerable<int> resultSequence;
            var set = new HashSet<int>(array.Take(border).Distinct());

            Console.WriteLine("\r\nArray.Where():");
            using (new Measurement("  For loop").SetBaseline()) {
                for (int i = 0; i < array.Length; i++) {
                    int v = array[i];
                    if (v < border)
                        Noop(v);
                }
            }
            using (new Measurement("  Foreach loop")) {
                foreach (var v in array) {
                    if (v < border)
                        Noop(v);
                }
            }
            using (new Measurement("  LINQ")) {
                resultSequence = array.Where(v => v < border);
                foreach (var item in resultSequence)
                    Noop(item);
            }
            DumpEnumeratorType(resultSequence);

            Console.WriteLine("\r\nArray.Where().Select():");
            using (new Measurement("  For loop").SetBaseline()) {
                for (int i = 0; i < array.Length; i++) {
                    int v = array[i];
                    if (v < border)
                        Noop(v + 1);
                }
            }
            using (new Measurement("  Foreach loop")) {
                foreach (var v in array) {
                    if (v < border)
                        Noop(v + 1);
                }
            }
            using (new Measurement("  LINQ")) {
                resultSequence =
                    from v in array
                    where v < border
                    select v + 1;
                foreach (var item in resultSequence)
                    Noop(item);
            }
            DumpEnumeratorType(resultSequence);

            Console.WriteLine("\r\nArray.Where().Select().ToList():");
            using (new Measurement("  For loop").SetBaseline()) {
                var result = new List<int>();
                for (int i = 0; i < array.Length; i++) {
                    int v = array[i];
                    if (v < border)
                        result.Add(v + 1);
                }
            }
            using (new Measurement("  Foreach loop")) {
                var result = new List<int>();
                foreach (var v in array) {
                    if (v < border)
                        result.Add(v + 1);
                }
            }
            using (new Measurement("  LINQ")) {
                resultSequence = 
                    from v in array
                    where v < border
                    select v + 1;
                var result = resultSequence.ToList();
            }
            DumpEnumeratorType(resultSequence);

            Console.WriteLine("\r\nList.Where().Select().ToList():");
            using (new Measurement("  For loop").SetBaseline()) {
                var result = new List<int>();
                var count = list.Count;
                for (int i = 0; i < count; i++) {
                    int v = list[i];
                    if (v < border)
                        result.Add(v + 1);
                }
            }
            using (new Measurement("  Foreach loop")) {
                var result = new List<int>();
                foreach (var v in list) {
                    if (v < border)
                        result.Add(v + 1);
                }
            }
            using (new Measurement("  LINQ")) {
                resultSequence = 
                    from v in list
                    where v < border
                    select v + 1;
                var result = resultSequence.ToList();
            }
            DumpEnumeratorType(resultSequence);

            Console.WriteLine("\r\nSequence.Where().Select().ToList():");
            using (new Measurement("  Foreach loop").SetBaseline()) {
                var result = new List<int>();
                foreach (var v in sequence) {
                    if (v < border)
                        result.Add(v + 1);
                }
            }
            using (new Measurement("  LINQ")) {
                resultSequence = 
                    from v in sequence
                    where v < border
                    select v + 1;
                var result = resultSequence.ToList();
            }
            DumpEnumeratorType(resultSequence);

            Console.WriteLine("\r\nSequence.Where(HashSet.Contains).Select().ToList():");
            using (new Measurement("  Foreach loop").SetBaseline()) {
                var result = new List<int>();
                foreach (var v in sequence) {
                    if (set.Contains(v))
                        result.Add(v + 1);
                }
            }
            using (new Measurement("  LINQ")) {
                resultSequence = 
                    from v in sequence
                    where set.Contains(v)
                    select v + 1;
                var result = resultSequence.ToList();
            }
            DumpEnumeratorType(resultSequence);
        }

        private static void DumpEnumeratorType(IEnumerable<int> resultSequence)
        {
            Console.WriteLine("    Enumerator:    {0}", resultSequence.GetEnumerator().GetType().Name);
        }

        private static void Noop(int item)
        {
            if (item==int.MinValue)
                Noop(item);
        }
    }
}
