using System;
using System.Collections.Generic;
using System.Text;

namespace MapGenerator
{    
    class Pair<T>
    {
        public T X;
        public T Y;

        public Pair()
        {

        }

        public Pair(T X, T Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
