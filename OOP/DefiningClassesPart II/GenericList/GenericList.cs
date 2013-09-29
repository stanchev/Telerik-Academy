using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    public class GenericList<T>
    {
        private T[] elements;
        private int nextElement;
        private int capacity;

        /// <summary>
        /// Get count of elements in list.
        /// </summary>
        public int Count
        {
            get
            {
                return this.nextElement;
            }
        }

        public GenericList(int capacity = 16)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Value must be positive.");
            }
            else
            {
                this.elements = new T[capacity];
                this.nextElement = 0;
                this.capacity = capacity;
            }
        }

        /// <summary>
        /// Get or set element by index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                CheckRange(index);
                return this.elements[index];
            }
            set
            {
                CheckRange(index);
                this.elements[index] = value;
            }
        }

        /// <summary>
        /// Add element to list.
        /// </summary>
        /// <param name="element"></param>
        public void AddElement(T element)
        {
            if (this.nextElement >= this.capacity)
            {
                GrowList();
            }
            this.elements[this.nextElement] = element;
            this.nextElement++;
        }

        /// <summary>
        /// Grow twice size of list.
        /// </summary>
        private void GrowList()
        {
            T[] temp = new T[this.capacity];
            this.elements.CopyTo(temp, 0);
            this.capacity *= 2;
            this.elements = new T[this.capacity];
            temp.CopyTo(this.elements, 0);
        }

        /// <summary>
        /// Delete element at index.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveElementAt(int index)
        {
            CheckRange(index);
            T nextElement = default(T);
            for (int i = index; i < this.elements.Length - 1; i++)
            {
                nextElement = this.elements[i + 1];
                this.elements[i] = nextElement;
            }
            this.nextElement--;
        }

        /// <summary>
        /// Insert given element at index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="element"></param>
        public void InsertElementAt(int index, T element)
        {
            CheckRange(index);
            if (this.nextElement >= this.capacity)
            {
                GrowList();
            }
            for (int i = this.nextElement; i > index; i--)
            {
                this.elements[i] = this.elements[i - 1];
            }
            this.elements[index] = element;
            this.nextElement++;
        }

        /// <summary>
        /// Clear list.
        /// </summary>
        public void ClearList()
        {
            this.elements = new T[this.capacity];
            this.nextElement = 0;
        }

        /// <summary>
        /// Find element in list and return its index.
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public int FindElementIndex(T searchValue)
        {
            return Array.IndexOf(this.elements, searchValue);
        }

        /// <summary>
        /// Check for correct range.
        /// </summary>
        /// <param name="index"></param>
        private void CheckRange(int index)
        {
            if (index < 0 || index >= this.nextElement)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
        }

        public override string ToString()
        {
            StringBuilder genericListInfo = new StringBuilder("(");
            for (int i = 0; i < this.nextElement; i++)
            {
                genericListInfo.Append(this.elements[i] + ",");
            }
            genericListInfo.Remove(genericListInfo.Length - 1, 1).Append(")");
            return genericListInfo.ToString();
        }
    }
}
