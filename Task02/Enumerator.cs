using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    public class Enumerator<T>: IEnumerator<T>
    {
        private readonly Queue<T> _queue;
        private int _index;

        public Enumerator(Queue<T> queue)
        {
            _queue = queue;
            _index = -1;
        }

        public T Current
        {
            get
            {
                if (_index == -1 || _index == _queue.Count)
                {
                    throw new InvalidOperationException();
                }
                return _queue[_index];
            }
        }
        public bool MoveNext()
        {
            _index++;
            return _index < _queue.Count;
        }

        object System.Collections.IEnumerator.Current
        {
            get { throw new NotImplementedException(); }
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
