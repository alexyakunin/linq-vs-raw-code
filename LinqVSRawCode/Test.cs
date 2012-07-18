using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace LinqVSRawCode
{
    public class Test
    {
        static void Main(string[] args)
        {
            var unprecessedArgs = args.AsEnumerable();
            var iterationCount = 1000000;
            if (unprecessedArgs.Any()) {
                iterationCount = int.Parse(unprecessedArgs.First());
                unprecessedArgs = unprecessedArgs.Skip(1);
            }
            if (unprecessedArgs.Any())
                Measurement.DisplayEnumeratorType = bool.Parse(unprecessedArgs.First());
            new Test().Run(iterationCount);
        }

        private unsafe void Run(int iterationCount)
        {
            Console.WriteLine("Iteration count: {0}", iterationCount);
            var rnd = new Random();
            int max = 1000;
            int border = max / 2;
            
            // Big set
            var array = Enumerable.Range(0, iterationCount)
                .Select(i => rnd.Next(max))
                .ToArray();
            var list = array.ToList();
            var sequence = array.AsEnumerable();
            var dictionary = new Dictionary<int, int>(array.Length);
            for (int k = 0; k < array.Length; k++)
                dictionary[k] = array[k];

            // Small set
            var smallArray = array.Distinct().Take(Math.Min(border, iterationCount/10)).ToArray();
            var smallSet = new HashSet<int>(smallArray);

            // Mid set
            var midArray = array.Take(Math.Max(1, (int) Math.Round((double) array.Length / smallArray.Length))).ToArray();

            Console.WriteLine(); 
            Console.WriteLine("Array.Where():");
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
            Measurement.Run("Unsafe loop", () => {
                int result = 0;
                fixed (int* src = array) {
                    int* vEndPtr = src + array.Length;
                    for (int* vPtr = src; vPtr != vEndPtr; vPtr++)
                        if (*vPtr < border)
                            result = *vPtr;
                }
                return (object) result;
            });
            Measurement.Run("LINQ", () => {
                var src = array;
                var result = src.Where(v => v < border);
                foreach (var item in result);
                return result;
            });

            Console.WriteLine(); 
            Console.WriteLine("Array.Where().Select():");
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
            Measurement.Run("Unsafe loop", () => {
                int result = 0;
                fixed (int* src = array) {
                    int* vEndPtr = src + array.Length;
                    for (int* vPtr = src; vPtr != vEndPtr; vPtr++)
                        if (*vPtr < border)
                            result = 1 + *vPtr;
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

            Console.WriteLine(); 
            Console.WriteLine("Array.Where().Select().ToList():");
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
            Measurement.Run("Unsafe loop", () => {
                var result = new List<int>();
                fixed (int* src = array) {
                    int* vEndPtr = src + array.Length;
                    for (int* vPtr = src; vPtr != vEndPtr; vPtr++)
                        if (*vPtr < border)
                            result.Add(1 + *vPtr);
                }
                return result;
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

            Console.WriteLine(); 
            Console.WriteLine("List.Where().Select().ToList():");
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

            Console.WriteLine(); 
            Console.WriteLine("Sequence.Where().Select().ToList():");
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

            Console.WriteLine(); 
            Console.WriteLine("Array.Where(HashSet.Contains).Select().ToList():");
            Measurement.Run("Foreach loop", true, () => {
                var src = array;
                var result = new List<int>();
                foreach (var v in src) {
                    if (smallSet.Contains(v))
                        result.Add(v + 1);
                }
                return result;
            });
            Measurement.Run("LINQ", () => {
                var src = array;
                var result = 
                    from v in src
                    where smallSet.Contains(v)
                    select v + 1;
                result.ToList();
                return result;
            });

            Console.WriteLine(); 
            Console.WriteLine("Array.Select(StringBuilder.Append(int.ToString)):");
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

            Console.WriteLine(); 
            Console.WriteLine("Array.Where(Method).Select(Method).ToList():");
            Measurement.Run("Foreach loop", true, () => {
                var src = array;
                var result = new List<int>();
                foreach (var v in src)
                    if (BoolNoop(v))
                        result.Add(Noop(v));
                return result;
            });
            Measurement.Run("LINQ", () => {
                var src = array;
                var result = src.Where(BoolNoop).Select(Noop);
                result.ToList();
                return result;
            });

            Console.WriteLine(); 
            Console.WriteLine("Array.Where(v => Array.Contains(v + 1)).ToList():");
            Measurement.Run("Nested foreach", true, () => {
                var src = midArray;
                var result = new List<int>();
                foreach (var v in src) {
                    int vPlus1 = v + 1;
                    foreach (var v1 in smallArray) {
                        if (vPlus1==v1) {
                            result.Add(v);
                            break;
                        }
                    }
                }
                return result;
            });
            Measurement.Run("LINQ", () => {
                var src = midArray;
                var result = src.Where(v => smallArray.Contains(v + 1));
                result.ToList();
                return result;
            });

            Console.WriteLine(); 
            Console.WriteLine("Array.SelectMany(Array).ToList():");
            Measurement.Run("Nested foreach", true, () => {
                var src = midArray;
                var result = new List<int>();
                foreach (var v in src)
                    foreach (var v1 in smallArray)
                        result.Add(v1);
                return result;
            });
            Measurement.Run("LINQ", () => {
                var src = midArray;
                var result = src.SelectMany(v => smallArray);
                result.ToList();
                return result;
            });

            Console.WriteLine(); 
            Console.WriteLine("Dictionary.Where().Select():");
            Measurement.Run("Foreach loop", true, () => {
                var src = dictionary;
                int result = 0;
                foreach (var pair in src)
                    if (pair.Value < border)
                        result = pair.Key;
                return (object) result;
            });
            Measurement.Run("LINQ", () => {
                var src = dictionary;
                var result = 
                    from pair in src
                    where pair.Value < border
                    select pair.Key;
                foreach (var item in result);
                return result;
            });

            Console.WriteLine(); 
            Console.WriteLine("LINQ only: List.Where().Where():");
            Measurement.Run(".Where(a && b)", true, () => {
                var src = list;
                var result = src.Where(i => i < border && (i + 10) < border);
                foreach (var item in result);
                return result;
            });
            Measurement.Run(".Where(a).Where(b)", () => {
                var src = list;
                var result = src.Where(i => i < border).Where(i => (i + 10) < border);
                foreach (var item in result);
                return result;
            });
            Measurement.Run("where a where b", () => {
                var src = list;
                var result = 
                    from i in src
                    where i < border 
                    where (i + 10) < border
                    select i;
                foreach (var item in result);
                return result;
            });
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private int Noop(int i)
        {
            if (i < 0) // Always false, but this prevents CLR optimizer to remove this method call
                Noop(i);
            return i;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool BoolNoop(int i)
        {
            if (i < 0)
                Noop(i);
            return i >= 0;
        }
    }
}
