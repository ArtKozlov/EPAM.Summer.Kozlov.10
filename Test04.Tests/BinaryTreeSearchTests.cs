using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task04;

namespace Test04.Tests
{
    public class BinaryTreeSearchTests
    {

        #region Book tests

        [Test]
        public void BinaryTreeSearchPreOrderrWithBookComparer()
        {
            var binaryTree =
                new BinaryTreeSearch<Book>(new Book[]
                {
                    new Book("author", "ttt", 5, 2015), new Book("author", "ttt", 4, 2015),
                    new Book("author", "ttt", 3, 2015),
                    new Book("author", "ttt", 6, 2015), new Book("author", "ttt", 7, 2015)
                });
            var expected = new Book[]
            {
                new Book("author", "ttt", 5, 2015), new Book("author", "ttt", 4, 2015),
                new Book("author", "ttt", 6, 2015),
                new Book("author", "ttt", 3, 2015), new Book("author", "ttt", 7, 2015)
            };

            CollectionAssert.AreEqual(expected, binaryTree.PreOrder());
        }

        [Test]
        public void BinaryTreeSearchPreOrderrWithBookCustomComparer()
        {
            var binaryTree =
                new BinaryTreeSearch<Book>(new Book[]
                {
                    new Book("eee", "title", 5, 2015), new Book("bbb", "title", 5, 2015),
                    new Book("a", "title", 5, 2015),
                    new Book("fff", "title", 5, 2015), new Book("ggg", "title", 5, 2015)
                }, new CompareByAuthor());

            var expected = new Book[]
            {
                new Book("aaa", "title", 5, 2015), new Book("bbb", "title", 5, 2015), new Book("e", "title", 5, 2015),
                new Book("fff", "title", 5, 2015), new Book("ggg", "title", 5, 2015)
            };

            CollectionAssert.AreEqual(expected, binaryTree.PreOrder());
        }

        [Test]
        public void BinaryTreeSearchPostOrderWithBookComparer()
        {
            var binaryTree =
                new BinaryTreeSearch<Book>(new Book[]
                {
                    new Book("author", "ttt", 5, 2015), new Book("author", "ttt", 4, 2015),
                    new Book("author", "ttt", 3, 2015),
                    new Book("author", "ttt", 6, 2015), new Book("author", "ttt", 7, 2015)
                });
            var expected = new Book[]
            {
                new Book("author", "ttt", 5, 2015), new Book("author", "ttt", 4, 2015),
                new Book("author", "ttt", 6, 2015),
                new Book("author", "ttt", 3, 2015), new Book("author", "ttt", 7, 2015)
            };

            CollectionAssert.AreEqual(expected, binaryTree.PostOrder());
        }

        [Test]
        public void BinaryTreeSearchPostOrderWithBookCustomComparer()
        {
            var binaryTree =
                new BinaryTreeSearch<Book>(new Book[]
                {
                    new Book("eee", "title", 5, 2015), new Book("bbb", "title", 5, 2015),
                    new Book("a", "title", 5, 2015),
                    new Book("fff", "title", 5, 2015), new Book("ggg", "title", 5, 2015)
                }, new CompareByAuthor());

            var expected = new Book[]
            {
                new Book("aaa", "title", 5, 2015), new Book("bbb", "title", 5, 2015), new Book("e", "title", 5, 2015),
                new Book("fff", "title", 5, 2015), new Book("ggg", "title", 5, 2015)
            };

            CollectionAssert.AreEqual(expected, binaryTree.PostOrder());
        }

        [Test]
        public void BinaryTreeSearchInOrderWithBookComparer()
        {
            var binaryTree =
                new BinaryTreeSearch<Book>(new Book[]
                {
                    new Book("author", "ttt", 5, 2015), new Book("author", "ttt", 4, 2015),
                    new Book("author", "ttt", 3, 2015),
                    new Book("author", "ttt", 6, 2015), new Book("author", "ttt", 7, 2015)
                });
            var expected = new Book[]
            {
                new Book("author", "ttt", 5, 2015), new Book("author", "ttt", 4, 2015),
                new Book("author", "ttt", 6, 2015),
                new Book("author", "ttt", 3, 2015), new Book("author", "ttt", 7, 2015)
            };

            CollectionAssert.AreEqual(expected, binaryTree.InOrder());
        }

        [Test]
        public void BinaryTreeSearchInOrderWithBookCustomComparer()
        {
            var binaryTree =
                new BinaryTreeSearch<Book>(new Book[]
                {
                    new Book("eee", "title", 5, 2015), new Book("bbb", "title", 5, 2015),
                    new Book("a", "title", 5, 2015),
                    new Book("fff", "title", 5, 2015), new Book("ggg", "title", 5, 2015)
                }, new CompareByAuthor());

            var expected = new Book[]
            {
                new Book("aaa", "title", 5, 2015), new Book("bbb", "title", 5, 2015), new Book("e", "title", 5, 2015),
                new Book("fff", "title", 5, 2015), new Book("ggg", "title", 5, 2015)
            };

            CollectionAssert.AreEqual(expected, binaryTree.InOrder());
        }

        #endregion

        #region Point tests

        [Test]
        public void BinaryTreeSearchPreOrderWithPointComparer()
        {
            var binaryTree =
                new BinaryTreeSearch<Point>(
                    new Point[] { new Point(3, 3), new Point(2, 2), new Point(1, 1), new Point(4, 4) });
            var expected = new Point[] { new Point(3, 3), new Point(2, 2), new Point(1, 1), new Point(4, 4) };

            CollectionAssert.AreEqual(expected, binaryTree.PreOrder());
        }

        [Test]
        public void BinaryTreeSearchPostOrderWithPointComparer()
        {
            var binaryTree =
                new BinaryTreeSearch<Point>(
                    new Point[] { new Point(3, 3), new Point(2, 2), new Point(1, 1), new Point(4, 4) });
            var expected = new Point[] { new Point(1, 1), new Point(2, 2), new Point(4, 4), new Point(3, 3) };

            CollectionAssert.AreEqual(expected, binaryTree.PostOrder());
        }

        [Test]
        public void BinaryTreeSearchInOrderWithPointComparer()
        {
            var binaryTree =
                new BinaryTreeSearch<Point>(
                    new Point[] { new Point(3, 3), new Point(2, 2), new Point(1, 1), new Point(4, 4) },
                    new ComparerPoint());
            var expected = new Point[] { new Point(1, 1), new Point(2, 2), new Point(3, 3), new Point(4, 4) };

            CollectionAssert.AreEqual(expected, binaryTree.InOrder());
        }

        #endregion

        #region Int tests

        [Test]
        public void BinaryTreeSearchPreOrderWithIntComparer()
        {
            var binaryTree = new BinaryTreeSearch<int>(new int[] {5, 2, 8, 1, 3, 4, 7, 9, 6});
            var expected = new int[] {5, 2, 1, 3, 4, 8, 7, 6, 9};

            CollectionAssert.AreEqual(expected, binaryTree.PreOrder());
        }


        [Test]
        public void BinaryTreeSearchPostOrderWithIntComparer()
        {
            var binaryTree = new BinaryTreeSearch<int>(new int[] {5, 2, 8, 1, 3, 4, 7, 9, 6});
            var expected = new int[] {1, 4, 3, 2, 6, 7, 9, 8, 5};

            CollectionAssert.AreEqual(expected, binaryTree.PostOrder());
        }

        [Test]
        public void BinaryTreeSearchInOrderWithIntComparer()
        {
            var binaryTree = new BinaryTreeSearch<int>(new int[] {6, 5, 4, 3, 2, 1, 10, 9, 8, 7});
            var expected = new int[] {6, 5, 10, 4, 9, 3, 8, 2, 7, 1};

            CollectionAssert.AreEqual(expected, binaryTree.InOrder());
        }

        #endregion

        #region String tests


        [Test]
        public void BinaryTreeSearchPreOrderWithStringComparer()
        {
            var binaryTree = new BinaryTreeSearch<string>(new string[] {"aaa", "bbb", "ccc", "ddd"});
            var expected = new string[] {"aaa", "bbb", "ccc", "ddd"};

            CollectionAssert.AreEqual(expected, binaryTree.PreOrder());
        }

        [Test]
        public void BinaryTreeSearchPostOrderWithStringComparer()
        {
            var binaryTree = new BinaryTreeSearch<string>(new string[] {"aaa", "bbb", "ccc", "ddd"});
            var expected = new string[] {"ddd", "ccc", "bbb", "aaa"};

            CollectionAssert.AreEqual(expected, binaryTree.PostOrder());
        }

        [Test]
        public void BinaryTreeSearchInOrderWithStringComparer()
        {
            var binaryTree = new BinaryTreeSearch<string>(new string[] {"bbb", "ccc", "ddd", "aaa", "zzz"});
            var expected = new string[] {"bbb", "aaa", "ccc", "ddd", "zzz"};

            CollectionAssert.AreEqual(expected, binaryTree.InOrder());
        }

        #endregion

    }
}