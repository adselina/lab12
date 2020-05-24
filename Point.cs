using System;
using ClassLibrary;


namespace LinkedList
{
    public class Point
    {
        public Person data;
        public Point next, //адрес следующего элемента
                     pred; //адрес предыдущего элемента
        public Point()
        {
            Person p = new Person();

            data = p;
            next = null;
            pred = null;
        }
        public Point(Person d)
        {
            data = d;
            next = null;
            pred = null;
        }
        public override string ToString()
        {
            return data + " ";
        }
    }
}
