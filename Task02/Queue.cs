using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task02
{
    public class Queue<T>: IEnumerable<T>
    {
        private T[] array;
        public int Count => array.Length;


        public Queue()
        {
            array = new T[0];
        }

        public Queue(IEnumerable<T> otherQueue)
        {

            InitArray(otherQueue);
        }

        #region implementation interfaces


        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(this);
        }

        /// <summary>Returns an enumerator that iterates through a collection.</summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal T this[int index] => array[index];

        #endregion

        #region override object methods and operators.
        /// <summary>Returns a string that represents the queue.</summary>
        /// <returns>A string that represents the queue.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            if (ReferenceEquals(null, array))
                throw new ArgumentNullException();
            string set = String.Empty;
            foreach (T elem in array)
            {
                set += elem + " ";
            }

            return set;
        }

        /// <summary>Serves as the default hash function. </summary>
        /// <returns>A hash code for the queue.</returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            int num = 13;
            foreach (var item in array)
            {
                num = num * 27 + item.GetHashCode();
            }

            return num;
        }
        
        #endregion

        #region functionality
        /// <summary>
        /// It returns an object that is at the beginning, but does not remove it.
        /// </summary>
        /// <returns>the first object in queue.</returns>
        public T Peek()
        {
            return array[0];
        }
        /// <summary>
        /// The method adds an element to the queue.
        /// </summary>
        /// <param name="item">Items are added into a plurality.</param>
        public void Enqueue(T item)
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = item;
        }

        /// <summary>
        /// The method removes an element from the queue.
        /// </summary>
        /// <returns>Removing element.</returns>
        public T Dequeue()
        {
            T[] tempArray = new T[array.Length - 1];
            T result = array[0];

            for (int i = 1; i < Count; i++)
            {
                tempArray[i - 1] = array[i];
            }

            Array.Resize(ref array, array.Length - 1);
            tempArray.CopyTo(array, 0);

            return result;
        }

        /// <summary>
        /// Checks the element in the queue.
        /// </summary>
        /// <param name="element">Cheking element/</param>
        /// <returns>Returns true if the element is present in a plurality, and false if the element is not present in the queue.</returns>
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

        #endregion

        private void InitArray(IEnumerable<T> queue)
        {
            if (ReferenceEquals(null, queue))
                throw new ArgumentNullException();
            Array.Resize(ref array, queue.Count());
            int i = 0;
            foreach (var item in queue)
            {
                array[i++] = item;
            }
        }

    }
}
