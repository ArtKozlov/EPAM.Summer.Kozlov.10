using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task03
{
    public class Set<T> : IEquatable<Set<T>>, IEnumerable<T> where T : class
    {
        private T[] array;
        public int Count => array.Length;


        public Set()
        {
            array = new T[0];
        }

        public Set(IEnumerable<T> otherSet)
        {

            InitArray(otherSet);
        }

        #region implementation interfaces

        /// <summary>Indicates whether the current object is equal to another object of the set type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Set<T> other)
        {
            if (ReferenceEquals(null, other) || other.Count != Count)
                return false;

            T[] lhs = new T[Count];
            T[] rhs = new T[other.Count];
            array.CopyTo(lhs, 0);
            int j = 0;

            foreach (var elem in other)
            {
                rhs[j++] = elem;
            }

            Array.Sort(lhs);
            Array.Sort(rhs);

            for (int i = 0; i < lhs.Length; i++)
            {
                if (!lhs[i].Equals(rhs[i])) { return false; }
            }

            return true;
        }

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in array)
            {
                yield return item;
            }
        }

        /// <summary>Returns an enumerator that iterates through a collection.</summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        #region override object methods and operators.
        /// <summary>Determines whether the specified object is equal to the set.</summary>
        /// <returns>true if the specified object  is equal to the set; otherwise, false.</returns>
        /// <param name="obj">The object to compare with the set. </param>
        /// <filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            Set<T> set = obj as Set<T>;
            if (ReferenceEquals(null, set))
            {
                return false;
            }
            return Equals(set);
        }

        /// <summary>Returns a string that represents the set.</summary>
        /// <returns>A string that represents the set.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            if (ReferenceEquals(null, array))
                throw new ArgumentNullException();
            string set = "{ ";
            foreach (T elem in array)
            {
                set += elem + " ";
            }
            set += "}";
            return set;
        }

        /// <summary>Serves as the default hash function. </summary>
        /// <returns>A hash code for the set.</returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            int num = 43;
            foreach (var item in array)
            {
                num = num * 37 + item.GetHashCode();
            }

            return num;
        }

        public static bool operator ==(Set<T> lhs, Set<T> rhs)
        {
            if (ReferenceEquals(null, lhs) || ReferenceEquals(null, rhs))
                return false;
            return ReferenceEquals(lhs, rhs);
        }

        public static bool operator !=(Set<T> lhs, Set<T> rhs)
        {
            return !(lhs == rhs);
        }
        #endregion

        #region functionality
        /// <summary>
        /// The method adds an element to the set; otherwise throws an exception.
        /// </summary>
        /// <param name="item">Items are added into a plurality.</param>
        public void Add(T item)
        {
            foreach (T elem in array)
            {
                if (item.Equals(elem))
                    throw new ArgumentException("Element exists!");
            }

            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = item;
        }

        /// <summary>
        /// The method removes an element from the set.
        /// </summary>
        /// <param name="item">Items are removed into a plurality.</param>
        public void Remove(T item)
        {
            T[] result = new T[array.Length];
            int counter = 0;

            foreach (T elem in array)
            {
                if (!item.Equals(elem))
                {
                    result[counter] = elem;
                    counter++;
                }
            }
            Array.Resize(ref result, counter);
            Array.Resize(ref array, counter);

            result.CopyTo(array, 0);
        }

        /// <summary>
        /// Checks the element in the set.
        /// </summary>
        /// <param name="element">Cheking element/</param>
        /// <returns>Returns true if the element is present in a plurality, and false if the element is not present in the set.</returns>
        public bool Contains(T element)
        {
            foreach (T elem in array)
            {
                if (element.Equals(elem))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// It removes all of the plurality of.
        /// </summary>
        public void Clear()
        {
            Array.Resize(ref array, 0);
        }

        /// <summary>
        /// Finds the intersection of two sets.
        /// </summary>
        /// <returns>Returns a new object of type of set.</returns>
        public Set<T> IntersectionOfSets(Set<T> otherSet)
        {
            T[] tempArray = new T[0];
            foreach (var elem in otherSet)
            {
                if (array.Contains(elem))
                {
                    Array.Resize(ref tempArray, tempArray.Length + 1);
                    tempArray[tempArray.Length - 1] = elem;
                }
            }

            return new Set<T>(tempArray);
        }

        /// <summary>
        /// It finds the union of two sets.
        /// </summary>
        /// <returns>Returns a new object of type of set.</returns>
        public Set<T> UnionOfSets(Set<T> otherSet)
        {

            T[] tempArray = new T[array.Length];
            array.CopyTo(tempArray, 0);
            foreach (var elem in otherSet)
            {
                if (!array.Contains(elem))
                {
                    Array.Resize(ref tempArray, tempArray.Length + 1);
                    tempArray[tempArray.Length - 1] = elem;

                }

            }

            return new Set<T>(tempArray);
        }

        /// <summary>
        /// Find the difference between the two sets.
        /// </summary>
        /// <returns>Returns a new object of type of set.</returns>
        public Set<T> DifferenceOfSets(Set<T> otherSet)
        {
            var tempArray = new T[0];

            foreach (var elem in otherSet)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (!array.Contains(elem))
                    {
                        Array.Resize(ref tempArray, tempArray.Length + 1);
                        tempArray[tempArray.Length - 1] = elem;
                    }

                }
            }

            return new Set<T>(tempArray);
        }
        #endregion

        private void InitArray(IEnumerable<T> set)
        {
            if (ReferenceEquals(null, set))
                throw new ArgumentNullException();
            Array.Resize(ref array, set.Count());
            int i = 0;
            foreach (var item in set)
            {
                array[i++] = item;
            }
        }

    }
}
