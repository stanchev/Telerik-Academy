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

        public void AddElement(T element)
        {
            if (this.nextElement >= this.capacity)
            {
                GrowList();
            }
            this.elements[this.nextElement] = element;
            this.nextElement++;
        }

        private void GrowList()
        {
            T[] temp = new T[this.capacity];
            this.elements.CopyTo(temp, 0);
            this.capacity *= 2;
            this.elements = new T[this.capacity];
            temp.CopyTo(this.elements, 0);
        }

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

        public void ClearList()
        {
            this.elements = new T[this.capacity];
            this.nextElement = 0;
        }

        public int FindElementIndex(T searchValue)
        {
            return Array.IndexOf(this.elements, searchValue);
        }

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
