using System;
using System.Collections.Generic;

namespace Task04
{
    public sealed class Book: IEquatable<Book>, IComparable<Book>, IComparer<Book>
    {
        private string _author;
        private string _title;
        private int _pages;
        private int _yearOfPublish;

        public string Author
        {
            get { return _author; }
            private set
            {
                if (ReferenceEquals(value, null))
                   throw new ArgumentNullException();
                _author = value;
            }
        }

        public string Title
        {
            get { return _title; }
            private set
            {
                if (ReferenceEquals(value, null))
                    throw new ArgumentNullException();
                _title = value;
            }
        }

        public int Pages
        {
            get { return _pages; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException();
                _pages = value;
            }
        }

        public int YearOfPublish
        {
            get { return _yearOfPublish; }
            private set
            {
                if (value < 0 || value > DateTime.Today.Year)
                    throw new ArgumentException();
                _yearOfPublish = value;
            }

        }
        /// <summary>
        /// The constructor receives 4 fields as parameters: author, title, number of pages and year of publication of the book.
        /// </summary>
        public Book(string author, string title, int pages, int yearOfPublish)
        {
            Author = author;
            Title = title;
            Pages = pages;
            YearOfPublish = yearOfPublish;
        }

        #region implements interfaces
        /// <summary>
        /// Method compare two books.
        /// </summary>
        /// <param name="other">This is book from which we will compare.</param>
        public bool Equals(Book other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqulsPropertys(ref other);
        }
        /// <summary>
        /// Separation of logic comparison method.
        /// </summary>
        /// <param name="other">This is ref of book from which we will compare.</param>
        private bool EqulsPropertys(ref Book other)
        {
            if (other.Author != Author)
                return false;
            if (other.Title == Title)
                return false;
            if (other.Pages == Pages)
                return false;
            if (other.YearOfPublish == YearOfPublish)
                return false;
            return true;
        }
        public int CompareTo(Book other)
        {
            if (ReferenceEquals(null, other))
                throw new ArgumentNullException();
            if (other.Pages < Pages) return 1;
            if (other.Pages > Pages) return -1;
            return 0;
        }
        #endregion

        #region implements object methods
        /// <summary>
        /// Override Equals method of object method.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            Book book = obj as Book;
            if (ReferenceEquals(null, book)) return false;
            return Equals(book);
        }
        /// <summary>
        /// Override GetHashCode method of object method.
        /// </summary>
        /// <returns>returns a hashcode.</returns>
        public override int GetHashCode() => (Pages*YearOfPublish*Title.GetHashCode()*Author.GetHashCode()).GetHashCode();

        public int Compare(Book x, Book y)
        {
            if (ReferenceEquals(null, x) || ReferenceEquals(null, y))
                throw new ArgumentNullException();
            return x.CompareTo(y);
        }

        /// <summary>
        /// Override ToString method of object method.
        /// </summary>
        /// <returns>returns a string value.</returns>
        public override string ToString() => $"Book {Title} published in {YearOfPublish} by {Author} and has {Pages} pages.";
        #endregion


    }
}
