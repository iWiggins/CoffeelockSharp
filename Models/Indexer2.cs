using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeelockSharp.Models
{
    public class Indexer2<T>
    {
        private readonly T[,] data;
        private readonly Indexer<Indexer<T>> idata;

        public Indexer2(int height, int width) :
            this(new T[height, width])
        { }

        public Indexer2(T[,] values)
        {
            data = values;

            idata = new Indexer<Indexer<T>>(Height);

            for(int i = 1; i <= Height; ++i)
            {
                idata[i] = new Indexer<T>(Width);

                for(int j = 1; j <= Width; ++j)
                {
                    idata[i][j] = this[i, j];
                }
            }
        }

        public int Width => data.GetLength(1);
        public int Height => data.GetLength(0);

        public T this[int y, int x]
        {
            get => data[y - 1, x-1];
        }

        public Indexer<T> this[int index]
        {
            get => idata[index];
        }
    }
}
