using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeelockSharp.Models
{
    public class Indexer<T> : IEnumerable<T>
    {
        private readonly T[] data;

        public Indexer(int width)
        {
            data = new T[width];
        }

        public Indexer(IEnumerable<T> values)
        {
            data = values.ToArray();
        }

        public T this[int index]
        {
            get => data[index - 1];
            set => data[index - 1] = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)data).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }
    }
}
