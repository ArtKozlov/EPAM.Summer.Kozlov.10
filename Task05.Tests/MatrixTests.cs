using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task05.Tests
{
    public class MatrixTests
    {
        #region SquareMatrix tests
        [Test]
        public void SquareMatrix_Adding()
        {
            var squareMatrix =
                new SquareMatrix<int>(new int[,]  { { 1, 1, 1}, { 2, 2, 2}, { 3, 3, 3} });
            var squareMatrix2 =
                new SquareMatrix<int>(new int[,] { { 1, 1, 1 }, { 2, 2, 2 }, { 3, 3, 3 } });

            SquareMatrix<int> newMatrix = squareMatrix.Add(squareMatrix2);
            var expectedMatrix = new int[,] { { 1, 1, 1 }, { 2, 2, 2 }, { 3, 3, 3 } };
            CollectionAssert.AreEqual(newMatrix.Matrix, expectedMatrix);
        }


        #endregion

        #region DiagonalMatrix tests
        [Test]
        public void DiagonalMatrix_Adding()
        {
            var diagonalMatrix =
                new DiagonalMatrix<int>(new int[,] { { 3, 0, 0 }, { 0, 5, 0 }, { 0, 0, 2 } });
            var diagonalMatrix2 =
                new DiagonalMatrix<int>(new int[,] { { 9, 0, 0 }, { 0, 6, 0 }, { 0, 0, 4 } });

            DiagonalMatrix<int> newMatrix = (DiagonalMatrix<int>)diagonalMatrix.Add(diagonalMatrix2);
            var expectedMatrix = new int[,] { { 12, 0, 0 }, { 0, 11, 0 }, { 0, 0, 6 } };

            CollectionAssert.AreEqual(newMatrix.Matrix, expectedMatrix);
        }

        #endregion

        #region SymmetricMatrix tests
        [Test]
        public void SymmetricMatrix_Adding()
        {
            var symmetricMatrix =
                new SymmetricMatrix<int>(new int[,] { { 1, 2, 3 }, { 2, 3, 4 }, { 3, 4, 5 } });
            var symmetricMatrix2 =
                new SymmetricMatrix<int>(new int[,] { { 1, 2, 3 }, { 2, 3, 4 }, { 3, 4, 5 } });

            var newMatrix = (SymmetricMatrix<int>)symmetricMatrix.Add(symmetricMatrix2);
            var expectedMatrix = new int[,] { { 2, 4, 5 }, { 4, 6, 8 }, { 6, 8, 10 } };

            CollectionAssert.AreEqual(newMatrix.Matrix, expectedMatrix);
        }

        #endregion
    }
}
