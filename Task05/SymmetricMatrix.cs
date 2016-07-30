using System;

namespace Task05
{
    public class SymmetricMatrix<T> : AbstractMatrix<T>
    {
        /// <summary>
        /// Constructor takes as arguments a two-dimensional array.
        ///  The length should be a square number.
        /// </summary>
        /// <param name="matrix">a two-dimensional array.</param>
        public SymmetricMatrix(T[,] matrix)
        {
            if (ReferenceEquals(matrix, null))
                throw new ArgumentNullException(nameof(matrix));
            if(!IsSquare(matrix))
                throw new ArgumentException(nameof(matrix));
            if (!IsSymmetric(matrix))
                throw new ArgumentException(nameof(matrix));
            Matrix = matrix;
        }
        protected override T GetValue(int i, int j) => i >= j ? Matrix[i,j] : Matrix[j,i];

        protected override void SetValue(int i, int j, T value)
        {
            if (i >= j) Matrix[i,j] = value;
            else Matrix[j,i] = value;
        }

        protected bool IsSymmetric(T[,] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
                for (int j = 0; j < matrix.Length; j++)
                    if (i != j && !matrix[i, j].Equals(matrix[j, i]))
                        return false;

            return true;
        }

    }
}
