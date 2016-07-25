using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    public class CompareByAuthor: IComparer<Book>
    {
        /// <summary>
        /// Method use author property of books for compare.
        /// </summary>
        public int Compare(Book lhs, Book rhs)
        {
            if (ReferenceEquals(null, lhs) || ReferenceEquals(null, rhs))
                throw new ArgumentNullException();
            if (String.CompareOrdinal(lhs.Author, rhs.Author) == 1)
                return 1;
            if (String.CompareOrdinal(lhs.Author, rhs.Author) == 0)
                return 0;
            return -1;
        }

    }
}
