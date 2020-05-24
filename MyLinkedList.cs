using ClassLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class MyLinkedList : IEnumerable
    {
        Point begin = null;
        
        public int Length
        {
            get
            {
                if (begin == null) return 0;
                int length = 0;
                Point p = begin;
                while (p != null)
                {
                    p = p.next;
                    length++;
                }
                return length;

            }
        }
        public Point End
        {
            get
            {
                if (begin == null) return begin;
                Point p = begin;
                while (p.next != null)
                {
                    p = p.next;
                }
                return p;
            }
        }
        public Point Begin
        {
            get { return begin; }
            set { begin = value; }
        }

        public MyLinkedList()
        {
            begin = null;
        }
        public MyLinkedList(int size)
        {
            begin = new Point();
            Point p = begin;
            for (int i = 1; i < size; i++)
            {
                Point temp = new Point();
                p.next = temp;
                temp.pred = p;
                p = temp;

            }
        }
        public MyLinkedList(params Person[] mas)
        {
            begin = new Point();
            begin.data = mas[0];
            Point p = begin;
            for (int i = 1; i < mas.Length; i++)
            {
                Point temp = new Point();
                temp.data = mas[i];
                p.next = temp;
                temp.pred = p;
                p = temp;
            }
        }

        
        public void AddToBegin(Person d)
        {
            Point temp = new Point(d);
            if (begin == null)
            {
                begin = temp;
                return;
            }
            temp.next = begin;
            begin.pred = temp;
            begin = temp;

        }   
        public void AddAfterKey(Person key, Person d)
        {
            Point temp = new Point(d);

            if (Length == 0)                                       //список пустой
            {
                Console.WriteLine("Список пустой");
                return;
            }

            if (Length == 1 && Begin.data.Equals(key))             //1 элемент и он = ключ 
            {
                temp = new Point(d);
                
                begin.next = temp;
                temp.pred = begin;
                return;
            }
            if (Length == 1 && !Begin.data.Equals(key))            //1 элемент в списке и он != ключ
            {
                Console.WriteLine("Элемента нет в списке");
                return;
            }            

            Point p = begin;
            while (p.next != null && !p.data.Equals(key))         //пока следующий элемент != конец и
                p = p.next;                                       //элемент != ключ

            if (!p.data.Equals(key))                              //если элемент != ключ
            {
                Console.WriteLine("Элемента нет в списке");
                return;
            }
            if (p.next == null && p.data.Equals(key))              //если элемент = ключ и он последний
            {
                temp.pred = p;
                p.next = temp;
                return;
            }
            p.next.pred = temp;
            temp.next = p.next;
           
            temp.pred = p;
            p.next = temp;
        }
        public void AddToEnd(Person d)
        {
            Point temp = new Point(d);
            if (begin == null)
            {
                begin = temp;
                return;
            }
            End.next = temp;
            temp.pred = End;
        }


        public void RemoveKey(Person key)
        {
            if (Length == 0)
            {
                Console.WriteLine("Список пустой");
                return;
            }

            if (Length == 1 && Begin.data.Equals(key))
            {
                begin = null;
                return;
            }
            if (Length == 1 && !Begin.data.Equals(key))
            {
                Console.WriteLine("Элемента нет в списке");
                return;
            }

            if (Begin.data.Equals(key))
            {
                begin = begin.next;
                begin.pred = null;

                return;
            }

            if (End.data.Equals(key))
            {
                End.pred.next = null;
                return;
            }

            Point p = begin;
            while (p.next.next != null && !p.next.data.Equals(key)) 
                p = p.next;

            if (!p.next.data.Equals(key))
            {
                Console.WriteLine("Элемента нет в списке");
                return;
            }

            p.next = p.next.next;
            p.next.pred = p;
        }

        public MyLinkedList Clone()
        {
            MyLinkedList newList = new MyLinkedList();
            foreach (Person item in this)
            {
                newList.AddToEnd(new Point(item).data);
            }
            return newList;
        }
        public MyLinkedList ShallowCopy()
        {
            MyLinkedList newList = new MyLinkedList();
            newList = this;
            return newList;
        }
        
        public void RemoveCollection()
        {
            this.begin.next = null;
            this.begin.data = null;
        }

        public int Count()
        {
            int i = 0;
            foreach(Person item in this)
            {
                i++;
            }
            return i;
        }
        public void PrintList()
        {
            Console.WriteLine();
            if (begin == null)
            {
                Console.WriteLine("Пустой список");
                Console.WriteLine("\n...Нажмите любую клавшу для продолжения...");
                Console.ReadKey();
                return;
            }
            Point p = begin;
            while (p != null)
            {
                Console.WriteLine(p);
                p = p.next;
            }
            Console.WriteLine("\n...Нажмите любую клавшу для продолжения...");
            Console.ReadKey();
        }

        //обобщенный нумератор
        public IEnumerator GetEnumerator()
        {
            Point current = begin;
            while (current != null)
            {
                yield return current.data;
                current = current.next;
            }
        }
        //необобщенный нумератор
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
