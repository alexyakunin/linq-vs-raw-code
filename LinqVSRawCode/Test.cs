using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqVSRawCode
{
    public class Test
    {
        static void Main(string[] args)
        {
            new Test().Run(int.Parse(args.FirstOrDefault() ?? "1000000"));
        }

        private void Run(int iterationCount)
        {
            Console.WriteLine("Iteration count: {0}", iterationCount);
            var rnd = new Random();
            int max = 1000;
            int border = max / 2;
            var array = Enumerable.Range(0, iterationCount)
                .Select(i => rnd.Next(max))
                .ToArray();
            var list = array.ToList();
            var sequence = new ArrayToSequenceWrapper<int>(array);
            var set = new HashSet<int>(array.Take(border).Distinct());

            Console.WriteLine("\r\nArray.Where():");
            Measurement.Run("For loop", true, () => {
                var src = array;
                int result = 0;
                for (int i = 0; i < src.Length; i++) {
                    int v = src[i];
                    if (v < border)
                        result = v;
                }
                return (object) result;
            });
            Measurement.Run("Foreach loop", () => {
                var src = array;
                int result = 0;
                foreach (var v in src) {
                    if (v < border)
                        result = v;
                }
                return (object) result;
            });
            Measurement.Run("LINQ", () => {
                var src = array;
                var result = src.Where(v => v < border);
                foreach (var item in result);
                return result;
            });

            Console.WriteLine("\r\nArray.Where().Select():");
            Measurement.Run("For loop", true, () => {
                var src = array;
                int result = 0;
                for (int i = 0; i < src.Length; i++) {
                    int v = src[i];
                    if (v < border)
                        result = v + 1;
                }
                return (object) result;
            });
            Measurement.Run("Foreach loop", () => {
                var src = array;
                int result = 0;
                foreach (var v in src) {
                    if (v < border)
                        result = v + 1;
                }
                return (object) result;
            });
            Measurement.Run("LINQ", () => {
                var src = array;
                var result =
                    from v in src
                    where v < border
                    select v + 1;
                foreach (var item in result);
                return result;
            });

            Console.WriteLine("\r\nArray.Where().Select().ToList():");
            Measurement.Run("For loop", true, () => {
                var src = array;
                var result = new List<int>();
                for (int i = 0; i < src.Length; i++) {
                    int v = src[i];
                    if (v < border)
                        result.Add(v + 1);
                }
                return result;
            });
            Measurement.Run("Foreach loop", () => {
                var src = array;
                var result = new List<int>();
                foreach (var v in src) {
                    if (v < border)
                        result.Add(v + 1);
                }
                return (object) result;
            });
            Measurement.Run("LINQ", () => {
                var src = array;
                var result = 
                    from v in src
                    where v < border
                    select v + 1;
                result.ToList();
                return result;
            });

            Console.WriteLine("\r\nList.Where().Select().ToList():");
            Measurement.Run("For loop", true, () => {
                var src = list;
                var result = new List<int>();
                var count = src.Count;
                for (int i = 0; i < count; i++) {
                    int v = src[i];
                    if (v < border)
                        result.Add(v + 1);
                }
                return result;
            });
            Measurement.Run("Foreach loop", () => {
                var src = list;
                var result = new List<int>();
                foreach (var v in src) {
                    if (v < border)
                        result.Add(v + 1);
                }
                return result;
            });
            Measurement.Run("LINQ", () => {
                var src = list;
                var result = 
                    from v in src
                    where v < border
                    select v + 1;
                result.ToList();
                return result;
            });

            Console.WriteLine("\r\nSequence.Where().Select().ToList():");
            Measurement.Run("Foreach loop", true, () => {
                var src = sequence;
                var result = new List<int>();
                foreach (var v in src) {
                    if (v < border)
                        result.Add(v + 1);
                }
                return result;
            });
            Measurement.Run("LINQ", () => {
                var src = sequence;
                var result = 
                    from v in src
                    where v < border
                    select v + 1;
                result.ToList();
                return result;
            });

            Console.WriteLine("\r\nSequence.Where(HashSet.Contains).Select().ToList():");
            Measurement.Run("Foreach loop", true, () => {
                var src = sequence;
                var result = new List<int>();
                foreach (var v in src) {
                    if (set.Contains(v))
                        result.Add(v + 1);
                }
                return result;
            });
            Measurement.Run("LINQ", () => {
                var src = sequence;
                var result = 
                    from v in src
                    where set.Contains(v)
                    select v + 1;
                result.ToList();
                return result;
            });

            Console.WriteLine("\r\nArray.Select(StringBuilder.Append(int.ToString)):");
            Measurement.Run("Foreach loop", true, () => {
                var src = array;
                var result = new StringBuilder();
                foreach (var v in src)
                    result.Append(v.ToString());
                return result;
            });
            Measurement.Run("LINQ", () => {
                var src = array;
                var result = src.Select(i => i.ToString());
                var sb = new StringBuilder();
                foreach (var item in result)
                    sb.Append(item);
                return result;
            });
        }

        private static void Noop(bool value = false)
        {
            if (value)
                Noop(value);
        }
    }
}
