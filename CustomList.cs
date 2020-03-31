using System;
using System.Collections.Generic;
using System.Text;

namespace CustomListClass
{
    public class CustomList<T>
    {
        T[] items;

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
                if(index >= 0 && index < Count)
                {
                    items[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public int Capacity { get; set; }

        public CustomList()
        {
            count = 0;
            Capacity = 4;
            items = new T[Capacity];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                if(i == 0)
                {
                    sb.Append($"{items[i]}");
                }
                else
                {
                    sb.Append($", {items[i]}");
                }
            }
            return sb.ToString();
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

        public static CustomList<T> operator +(CustomList<T> list1, CustomList<T> list2)
        {
            CustomList<T> newList = new CustomList<T>();
            for (int i = 0; i < list1.Count; i++)
            {
                newList.Add(list1.items[i]);
            }
            for (int i = 0; i < list2.Count; i++)
            {
                newList.Add(list2.items[i]);
            }
            return newList;
        }

        public void IncreaseCapacity()
        {
            T[] tempArray;
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
            //bool itemExists = false;
            for (int i = 0; i < count; i++)
            {
                if (items[i].Equals(input))
                {
                    ReorderArray(i);
                    currentIndex--;
                    count--;
                    return true;
                }
            }
            return false;
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
    }
}
