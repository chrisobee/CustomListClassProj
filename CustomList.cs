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

        public void Add(T input)
        {
            if(count == Capacity)
            {
                IncreaseCapacity();
            }
            items[currentIndex] = input;
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

        public bool Remove(T input)
        {
            bool itemExists = false;
            for (int i = 0; i < count; i++)
            {
                if (items[i].Equals(input))
                {
                    ReorderArray(i);
                    itemExists = true;
                    break;
                }
            }
            CheckForCountDecrement(itemExists);
            return itemExists;
            
        }

        public void ReorderArray(int i)
        {
            for (int j = i + 1; j <= count; j++)
            {
                if(j == count)
                {
                    items[i] = default;
                }
                else
                {
                    items[i] = items[j];
                    i++;
                }
            }
        }

        public void CheckForCountDecrement(bool itemExists)
        {
            if (itemExists)
            {
                count--;
            }
        }
    }
}
