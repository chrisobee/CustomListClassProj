using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomListClass
{
    public class CustomList<T>:IEnumerable
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

        private int currentIndex = 0;

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

        public IEnumerator GetEnumerator()
        {
            for (int index = 0; index < Count; index++)
            {
                yield return items[index]; 
            }
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
                if (j == count)
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
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

        public static CustomList<T> operator +(CustomList<T> list1, CustomList<T> list2)
        {
            CustomList<T> newList = new CustomList<T>();
            for (int i = 0; i < list1.Count; i++)
            {
                newList.Add(list1[i]);
            }
            for (int i = 0; i < list2.Count; i++)
            {
                newList.Add(list2[i]);
            }
            return newList;
        }

        public static CustomList<T> operator -(CustomList<T> listOne, CustomList<T> listTwo)
        {
            CustomList<T> newList = new CustomList<T>();
            bool removeItem = false;
            for (int i = 0; i < listOne.Count; i++)
            {
                for (int j = 0; j < listTwo.Count; j++)
                {
                    removeItem = false;
                    if (listTwo[j].Equals(listOne[i]))
                    {
                        removeItem = true;
                        break;
                    }
                }
                if (removeItem)
                {
                    continue;
                }
                else
                {
                    newList.Add(listOne[i]);
                }
            }
            return newList;
        }

        public static CustomList<T> Zip(CustomList<T> listOne,CustomList<T> listTwo)
        {
            CustomList<T> newList = new CustomList<T>();
            if(listOne.Count >= listTwo.Count )
            {
                for (int i = 0; i < listOne.Count; i++)
                {
                    if (i == (listTwo.Count))
                    {
                        newList.AddRestOfList(listOne, i);
                        break;
                    }
                    else
                    {
                        newList.Add(listOne[i]);
                        newList.Add(listTwo[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < listTwo.Count; i++)
                {
                    if (i == (listOne.Count))
                    {
                        newList.AddRestOfList(listTwo, i);
                        break;
                    }
                    else
                    {
                        newList.Add(listOne[i]);
                        newList.Add(listTwo[i]);
                    }
                }
            }
            
            return newList;
        }

        public void AddRestOfList(CustomList<T> currentList, int i)
        {
            for (int j = i; j < currentList.Count; j++)
            {
                Add(currentList[j]);
            }
        }

        public void Sort(IComparer<T> comparer)
        {
            bool swappedNumbers;
            do
            {
                int start = 0;
                int end = Count - 1;
                swappedNumbers = false;

                swappedNumbers = ForwardPass(comparer, start, end);
                swappedNumbers = BackwardPass(comparer, start, end);
            }
            while (swappedNumbers == true);
        }

        public bool ForwardPass(IComparer<T> comparer, int start, int end)
        {
            int result;
            T temp;
            bool swappedNumbers = false;
            for (int i = start; i < end; i++)
            {
                result = comparer.Compare(items[i], items[i + 1]);
                if (result == 0)
                {
                    continue;
                }
                else if (result == 1)
                {
                    temp = items[i];
                    items[i] = items[i + 1];
                    items[i + 1] = temp;
                    swappedNumbers = true;
                }
                else if (result == -1)
                {
                    continue;
                }
            }
            end--;
            return swappedNumbers;
        }

        public bool BackwardPass(IComparer<T> comparer, int start, int end)
        {
            int result;
            T temp;
            bool swappedNumbers = false;
            for (int i = end; i > start; i--)
            {
                result = comparer.Compare(items[i], items[i - 1]);
                if (result == 0)
                {
                    continue;
                }
                else if (result == 1)
                {
                    continue;
                }
                else if (result == -1)
                {
                    temp = items[i];
                    items[i] = items[i - 1];
                    items[i - 1] = temp;
                    swappedNumbers = true;
                }
            }
            start++;
            return swappedNumbers;
        }
    }
}
