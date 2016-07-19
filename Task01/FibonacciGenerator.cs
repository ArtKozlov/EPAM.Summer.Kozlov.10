using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public static class FibonacciGenerator
    {
        /// <summary>
        /// A method for generate Fibonacci numbers.
        /// </summary>
        /// <param name="value">The number of Fibonacci numbers.</param>
        /// <returns>The variable type of IEnumerable.</returns>
        public static IEnumerable<int> GetFibonacciNumber (int count)
        {
            if(count <= 0)
                throw new ArgumentException();

            int lhs = 0;
            int rhs = 1;
            int temp;

            yield return 0; 

            for (int i = 0; i < count - 1; i++)
            {
                yield return rhs;
                temp = rhs;
                rhs += lhs;
                lhs = temp;
            }
        }

    }
}
