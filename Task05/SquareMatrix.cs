using System;

namespace Task05
{
    public class SquareMatrix<T>: AbstractMatrix<T>
    {

        /// <summary>
        /// Constructor takes as arguments a two-dimensional array.
        ///  The length should be a square number.
        /// </summary>
        /// <param name="matrix">a two-dimensional array.</param>
        public SquareMatrix(T[,] matrix)
        {
            if (ReferenceEquals(matrix, null))
                throw new ArgumentNullException(nameof(matrix));
            if (!IsSquare(matrix))
                throw new ArgumentException(nameof(matrix));
            Matrix = matrix;
        }

        public SquareMatrix(int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size));
            Size = size;
            Matrix = new T[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                    Matrix[i, j] = default(T);
            }

        }
        /// <summary>
        /// Determines whether the specified square matrix is equal to the current square matrix.
        /// </summary>
        /// <param name="other">The square matrix to compare with the current square matrix.</param>
        /// <returns>true if the specified square matrix  is equal to the current square matrix; otherwise, false.</returns>
        public bool Equals(SquareMatrix<T> other)
        {
            if (ReferenceEquals(null, other))
                return false;
            return Matrix.Equals(other.Matrix);
        }


        public virtual T this[int i, int j]
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





        #region implementing interface and override object methods
        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        /// <returns>true if the specified object  is equal to the current object; otherwise, false.</returns>
        /// <param name="obj">The object to compare with the current object. </param>
        /// <filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            SquareMatrix<T> p = obj as SquareMatrix<T>;
            if (ReferenceEquals(null,p))
                return false;
            return Equals(p);
        }

        /// <summary>Serves as the default hash function. </summary>
        /// <returns>A hash code for the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return Matrix.GetHashCode();
        }


        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return Matrix.ToString();
        }

        protected override T GetValue(int i, int j) => Matrix[i, j];

        protected override void SetValue(int i, int j, T value)
        {
            Matrix[i, j] = value;
        }

        #endregion

    }
}
