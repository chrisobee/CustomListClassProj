using System;

namespace CustomListClass
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> numbers = new CustomList<int>();
            numbers.Add(1);
            numbers.Add(2);
        }
    }
}
