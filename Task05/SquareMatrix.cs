using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;

namespace Task05
{
    public class SquareMatrix<T> : IEnumerable<T> where T : struct, IEquatable<T>, IFormattable
    {
        public event EventHandler<ChangeElemEventArgs<T>> ChangeElem = delegate { };
        public T[,] Matrix { get; protected set; }
        public int Size => Matrix.Length;

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



        protected bool IsSquare(T[,] matrix)
        {
            double dimension = Math.Sqrt(matrix.Length) - Convert.ToInt32(Math.Sqrt(matrix.Length));
            if (dimension > 0)
                return false;
            return true;
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

        /// <summary>Returns an enumerator that iterates through a collection.</summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var elem in Matrix)
            {
                yield return elem;
            }
        }


        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return Matrix.ToString();
        }
        #endregion

        protected virtual void OnChangeElem(object sender, ChangeElemEventArgs<T> e)
        {
            ChangeElem?.Invoke(this, e);
            Console.Beep(e.I*100, e.J*1000);
            ChangeElem(sender, e);
        }
        
        public virtual SquareMatrix<T> Add(SquareMatrix<T> other)
        {
            if(Size != other.Size)
                throw new ArgumentException();
            T[,] newMatrix = Matrix;
            for (int i = 0; i < Matrix.Length; i++)
                for (int j = 0; j < Matrix.Length; j++)
                    newMatrix[i, j] = other[i,j];
            Matrix<T> lhs = Matrix<T>.Build.DenseOfArray(newMatrix);
            Matrix<T> rhs = Matrix<T>.Build.DenseOfArray(Matrix);
            newMatrix = lhs.Add(rhs).ToArray();
            return new SquareMatrix<T>(newMatrix);
        }
        
    }
}
