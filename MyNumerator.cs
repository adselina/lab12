using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ClassLibrary;

namespace LinkedList
{
    class MyNumerator : IEnumerator
    {
        Point beg;//начало коллекции
        Point current;//текущий


        public MyNumerator(MyLinkedList collection)
        {
            beg = collection.Begin;
            current = null;
        }

        public Person Current
        {
            get
            {
                return current.data;
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose()
        {

        }

        public bool MoveNext()
        {

            if (current == null)
                current = beg;
            else
                current = current.next;
            return current != null;

        }

        public void Reset()
        {
            current = this.beg;
        }
    }
}
