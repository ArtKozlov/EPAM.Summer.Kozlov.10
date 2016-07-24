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
    public class DiagonalMatrix<T> : SquareMatrix<T> where T : struct, IEquatable<T>, IFormattable
    {

        /// <summary>
        /// Constructor takes as arguments a two-dimensional array.
        ///  The length should be a square number.
        /// </summary>
        /// <param name="matrix">a two-dimensional array.</param>
        public DiagonalMatrix(T[,] matrix) : base(matrix)
        {
            if (ReferenceEquals(matrix, null))
                throw new ArgumentNullException(nameof(matrix));
            if (!IsSquare(matrix))
                throw new ArgumentException();
            if (!IsDiagonal(matrix))
                throw new ArgumentException();

            Matrix = matrix;
        }
        public override T this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= Matrix.Length || j < 0 || j >= Matrix.Length)
                    throw new ArgumentOutOfRangeException();
                return Matrix[i, j];
            }
            set
            {
                if (i < 0 || i >= Matrix.Length || j < 0 || j >= Matrix.Length)
                    throw new ArgumentOutOfRangeException();
                Matrix[i, j] = value;

                OnChangeElem(this, new ChangeElemEventArgs<T>(i, j, value));
            }
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
