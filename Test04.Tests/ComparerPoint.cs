using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test04.Tests
{
    public struct ComparerPoint: IComparer<Point>
    {
            /// <summary>
            /// Method compare two Points.
            /// </summary>
            public int Compare(Point lhs, Point rhs)
            {
                if (lhs._x > rhs._x)
                    return 1;
                if (lhs._x == rhs._x)
                    return 0;
                return -1;
            }
    }
}
