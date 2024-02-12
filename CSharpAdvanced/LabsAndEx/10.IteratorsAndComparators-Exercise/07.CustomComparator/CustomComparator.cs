using System;
namespace _07.CustomComparator
{
    public class CustomComparator : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x % 2 == 0 && y % 2 != 0)
                return -1;
            else if (x % 2 != 0 && y % 2 == 0)
                return 1;
            else
                return x.CompareTo(y);
        }
    }
}

