using System;
using System.Collections.Generic;
using System.Text;

namespace CustomListClass
{
    public class CustomList<T>
    {
        T[] items;
        T[] tempArray;
        private int count;
        public int Count
        {
            get 
            { 
                return count; 
            }
        }

        public int currentIndex = 0;

        public T this[int index]
        {
            get 
            { 
                if(index >= 0 && index < Count)
                {
                    return items[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
                
            }
            set 
            { 
                items[index] = value;
            }
        }
        public int Capacity { get; set; }
        public CustomList()
        {
            count = 0;
            Capacity = 4;
            items = new T[Capacity];
        }

        public void Add(T item)
        {
            if(count == Capacity)
            {
                IncreaseCapacity();
            }
            items[currentIndex] = item;
            currentIndex++;
            count++;
        }

        public void IncreaseCapacity()
        {
            tempArray = items;
            Capacity *= 2;
            items = new T[Capacity];
            for (int i = 0; i < tempArray.Length; i++)
            {
                items[i] = tempArray[i];
            }
        }
    }
}
