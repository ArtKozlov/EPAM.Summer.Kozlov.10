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
            Queue<int> set = new Queue<int>();
            int result = 0;
            for (int i = 5; i < 14; i++)
            {
                set.Enqueue(i);
            }
            set.Clear();
            for (int i = 2; i < 8; i++)
            {
                set.Enqueue(i);
            }
            if (set.Contains(7))
                result = set.Dequeue();

            Assert.AreEqual(expected, result);
        }

    }
}
