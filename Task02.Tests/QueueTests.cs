using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task02.Tests
{
    public class QueueTests
    {
        [TestCase(2)]
        public void QueueTest(int expected)
        {
            Queue<int> queue = new Queue<int>();
            int result = 0;
            for (int i = 5; i < 14; i++)
            {
                queue.Enqueue(i);
            }
            queue.Clear();
            for (int i = 2; i < 8; i++)
            {
                queue.Enqueue(i);
            }
            if (queue.Contains(7))
                result = queue.Dequeue();

            Assert.AreEqual(expected, result);
        }

    }
}
