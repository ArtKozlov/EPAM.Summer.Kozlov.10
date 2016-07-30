using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task05
{
    public abstract class AbstractMatrix<T>: IEquatable<AbstractMatrix<T>>, IEnumerable<T>
    {
        public T[,] Matrix { get; protected set; }
        public event EventHandler<ChangeElemEventArgs<T>> ChangeElem = delegate { };

        public int Size { get; protected set; }

        public T this[int i, int j]
        {
            get
            {
                if (i < 0 && i >= Size)
                    throw new ArgumentOutOfRangeException(nameof(i));
                if (j < 0 && j >= Size)
                    throw new ArgumentOutOfRangeException(nameof(j));
                return GetValue(i, j);
            }
            set
            {
                if (i < 0 && i >= Size)
                    throw new ArgumentOutOfRangeException(nameof(i));
                if (j < 0 && j >= Size)
                    throw new ArgumentOutOfRangeException(nameof(j));

                SetValue(i, j, value);
                OnChangeElem(this, new ChangeElemEventArgs<T>(i, j, value));
            }
        }

        protected bool EqualsByIndexator(AbstractMatrix<T> other)
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (!this[i, j].Equals(other[i, j]))
                        return false;

            return true;
        }

        public void Accept(IMatrixVisitor<T> visitor, AbstractMatrix<T> matrix)
        {
            visitor.Visit((dynamic)this, matrix);
        }

        public bool Equals(AbstractMatrix<T> other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return Size == other.Size && EqualsByIndexator(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != GetType() && !obj.GetType().IsSubclassOf(typeof(SquareMatrix<T>)))
                return false;
            return EqualsByIndexator((AbstractMatrix<T>)obj);
        }

        public override string ToString()
        {
            StringBuilder matrixBuilder = new StringBuilder();
            matrixBuilder.Append($"Matrix. Size: {Size}\n");
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    matrixBuilder.Append($"{this[i, j],5}");
                }
                matrixBuilder.Append("\n");
            }
            return matrixBuilder.ToString();
        }
        protected bool IsSquare(T[,] matrix)
        {
            double dimension = Math.Sqrt(matrix.Length) - Convert.ToInt32(Math.Sqrt(matrix.Length));
            if (dimension > 0)
                return false;
            return true;
        }
        protected abstract T GetValue(int i, int j);
        protected abstract void SetValue(int i, int j, T value);

        protected virtual void OnChangeElem(object sender, ChangeElemEventArgs<T> e)
        {
            ChangeElem?.Invoke(this, e);
            Console.Beep(e.I * 100, e.J * 1000);
            ChangeElem(sender, e);
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
    }
}
