using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ClassLibrary;

namespace List
{
    public class MyList : IEnumerable
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

        public MyList()
        {
            begin = null;
        }                          //пустой конструктор
        public MyList(int size)
        {
            
            begin = new Point();
            Point p = begin;
            for (int i = 1; i < size; i++)
            {
                Point temp = new Point();
                p.next = temp;
                p = temp;
            }
        }                  //контруктор для создания листа по размеру
        public MyList(params Person[] mas)
        {
            begin = new Point();
            begin.data = mas[0];
            Point p = begin;
            Point temp = new Point();
            for (int i = 1; i < mas.Length; i++)
            {
                
                temp.data = mas[i];
                p.next = temp;
                
                p = p.next;
            }
            p.next = null;
        }       //контруктор для создания листа по массиву


        public void AddToBegin(Person d)
        {
            Point temp = new Point(d);
            if (begin == null)
            {
                begin = temp;
                return;
            }
            temp.next = begin;
            begin = temp;

            //Console.WriteLine("Элемент добавлен");

        }         //добавление элемента в начало списка
        public void AddToEnd(Person d)
        {
            Point temp = new Point(d);
            if (begin == null)
            {
                begin = temp;
                return;
            }
            End.next = temp;

            //Console.WriteLine("Элемент добавлен");

        }           //добавление элемента в конец списка


        public void RemoveKey(Person key)
        {
            if (this.Length == 0)                          
            {
                Console.WriteLine("Список пустой");
                return;
            }                                //пустой список

            if (Length == 1 && Begin.data.Equals(key))
            {
                begin = null;
                Console.WriteLine("Единственный элемент был удален");
                return;
            }           //один элемент и он = ключ
            if (Length == 1 && !Begin.data.Equals(key))
            {
                Console.WriteLine("Элемента нет в списке");
                return;
            }          //один элемент и он != ключ

            if (Begin.data.Equals(key))
            {
                begin = begin.next;
                return;
            }                          //первый элемент = ключ

            Point p = begin;
            while (p.next.next != null && !p.next.data.Equals(key)) //пока следующий элемент не последний или следующий элемент !=ключ
                p = p.next;   

            if (!p.next.data.Equals(key))
            {
                Console.WriteLine("Элемента нет в списке");
                return;
            }                        //если следующий элемент != ключ -> элемента нет

            p.next = p.next.next;                                   //если следующий элемент = ключ -> удаление этого элемента
        }        //удаление элемента по ключу
        public void RemoveEverySecond()
        {
            if (this.Count() == 0)
            {
                Console.WriteLine("Список пустой");
                return;
            }

            if (Length == 1)
            {
                Console.WriteLine("Длина списка 1 - Четных элементов нет");
                return;
            }

            Point p = begin;

            while (p.next != null && p.next.next != null)
            {
                p.next = p.next.next;
                p = p.next;
            }
            p.next = null;

        }          //удаление четных элементов


        public MyList Clone()
        {
            MyList newList = new MyList();
            foreach (Person item in this)
            {
                newList.AddToEnd((Person) item.Clone());
            }
            return newList;

        }                    //глубокое копирование
        public MyList ShallowCopy()
        {
            MyList newList = new MyList();
            newList = this;
            return newList;
        }              //поверхностное копирование
        public void RemoveCollection()
        {
            this.begin = null;
        }           //удаление коллекции из памяти

        public int Count() 
        {
            int i = 0;
            foreach (Person item in this)
                i++;
            return i;
        }                      //количество элементов в листе
        public void PrintList()
        {
            Console.WriteLine("");
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
        }                  //печать

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
