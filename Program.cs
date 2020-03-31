using System;
using System.Collections.Generic;

namespace CustomListClass
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>() { "chris", "austin", "shannon", "aaron" };
            names.Remove("austin");
            names.Add("aaaron");
        }
    }
}
