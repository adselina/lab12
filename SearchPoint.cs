using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary;

namespace Tree
{
    public class SearchPoint<T>
        where T: Person
    {
        public T data;
        public SearchPoint<T> left;
        public SearchPoint<T> right;

        public SearchPoint (T d)
        {
            data = d;
            left = null;
            right = null;

        }

        public SearchPoint()
        {
            data = default;
            left = null;
            right = null;
        }

        public override string ToString()
        {
            return data.ToString() + " ";
        }


        int CompareTo(T other)
        {
            return data.CompareTo(other);
        }
    }
}
