using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CustomListClass
{
    public class IntTest : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if(x == 0 || y == 0)
            {
                return 0;
            }
            else
            {
                return x.CompareTo(y);
            }
        }
    }

    public class StringTest : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == null || y == null)
            {
                return 0;
            }
            else if(x == y)
            {
                return 0;
            }
            else if(x.ToLower()[0] == y.ToLower()[0])
            {
                if(x.ToLower()[1].CompareTo(y.ToLower()[1]) > 0)
                {
                    return 1;
                }
                else if(x.ToLower()[1].CompareTo(y.ToLower()[1]) < 0)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else if(x.ToLower()[0].CompareTo(y.ToLower()[0]) > 0)
            {
                return 1;
            }
            else if(x.ToLower()[0].CompareTo(y.ToLower()[0]) < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
