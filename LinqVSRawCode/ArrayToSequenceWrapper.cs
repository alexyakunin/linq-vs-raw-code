using System.Collections;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;

namespace LinqVSRawCode
{
    public class ArrayToSequenceWrapper<T> : IEnumerable<T>
    {
        private T[] array;

        public ArrayToSequenceWrapper(T[] array)
        {
            this.array = array;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in array)
                yield return item;
        }
    }
}