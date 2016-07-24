using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05
{
    public class ChangeElemEventArgs<T> : EventArgs
    {
        public int I { get; private set; }
        public int J { get; private set; }
        private T _elem;

        public ChangeElemEventArgs(int i, int j, T elem)
        {
            I = i;
            J = j;
            _elem = elem;
        }
    }
}
