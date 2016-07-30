using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace Task05
{
    public class DiagonalMatrix<T> : AbstractMatrix<T>
    {
        /// <summary>
        /// Constructor takes as arguments a two-dimensional array.
        ///  The length should be a square number.
        /// </summary>
        /// <param name="matrix">a two-dimensional array.</param>
        public DiagonalMatrix(T[,] matrix)
        {
            if (ReferenceEquals(matrix, null))
                throw new ArgumentNullException(nameof(matrix));
            if (!IsSquare(matrix))
                throw new ArgumentException();
            if (!IsDiagonal(matrix))
                throw new ArgumentException();

            Matrix = matrix;
        }

        protected override T GetValue(int i, int j) => i == j ? Matrix[i,j] : default(T);

        protected override void SetValue(int i, int j, T value)
        {
            if (i == j) Matrix[i,j] = value;
            throw new ArgumentException("We try to set value on non-diagonal line");
        }

        protected bool IsDiagonal(T[,] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    if (i != j && !matrix[i, j].Equals(default(T)))
                        return false;
                }
            }
            return true;
        }

    }
}
