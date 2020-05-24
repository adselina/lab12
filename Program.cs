using System;
using System.Text;
using ClassLibrary;
using List;
using LinkedList;
using IdealTreeSpace;
using Tree;
using System.ComponentModel.Design.Serialization;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();

            int menu = 1;
            
            while (menu != 5) 
            {
                menu = MainMenu();
                Console.Clear();
                switch (menu)
                {
                    case 1:
                        Task1();
                        
                        break;
                    case 2:
                        Task2();
                        break;
                    case 3:
                        Task3();
                        break;
                    case 4:
                        Task4();
                        break;
                }
               
            }
        }

        private static int ReadNumber(int left, int right, string label)
        {
            int result = 0;
            bool flag = true;
            Console.Write(label);
            do
            {

                flag = int.TryParse(Console.ReadLine(), out result);

                if (!flag || result < left + 1 || result > right - 1)

                    Console.WriteLine($"Неверный ввод. Введите целое число от {left + 1} до {right - 1}");

            } while (!flag || result < left + 1 || result > right - 1);

            return result;

        }   //границы ввода
        private static Person MakeObject()
        {

            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            int age = ReadNumber(0, 101, "Введите возраст: ");
            Person p = new Person(name, age);
            return p;
        } //создание объекта для запроса

        #region Tasks
        private static void Task1()
        {
            int menu = 2;
            MyList list = new MyList();
            while (menu != 7)
            {
                menu = Task1_Menu();
                Console.Clear();
                switch (menu)
                {
                    case 1:
                        //формирование коллеции
                        int size = ReadNumber(-1, 50, "Введите размер однонаправленного списка: ");
                        list = new MyList(size);                                      //создание списка
                        list.PrintList();
                        break;
                    case 2:
                        //добавление в коллекцию
                        int add = ReadNumber(0, 3, "1. В начало" + "\n2. В конец\n");
                        switch (add)
                        {
                            //в начало
                            case 1:
                                list.AddToBegin(MakeObject());
                                break;
                            //в конец
                            case 2:
                                list.AddToEnd(MakeObject());
                                break;
                        }
                        list.PrintList();
                        break;
                    case 3:
                        int remove = ReadNumber(0, 3, "1. Удаление по ключу" + "\n2. Удаление четных чисел\n");
                        switch (remove)
                        {
                            //удаление по ключу
                            case 1:
                                list.RemoveKey(MakeObject());
                                break;
                            //удаление четных (задание)
                            case 2:
                                list.RemoveEverySecond();
                                break;

                        }
                        list.PrintList();
                        break;
                    case 4:
                        //клонирование
                        int clone = ReadNumber(0, 3, "1. Глубокое клонирование" + "\n2. Поверхностное\n");
                        switch (clone)
                        {
                            //полное 
                            case 1:
                                MyList listClone = list.Clone();
                                Console.WriteLine("Клон создан");
                                listClone.PrintList();
                                
                                break;
                            //поверхностниое
                            case 2:
                                MyList listShallowCopy = list.ShallowCopy();
                                Console.WriteLine("Копия создана");
                                listShallowCopy.PrintList();
                                break;
                        }

                        break;
                    case 5:
                        Console.WriteLine($"Размер коллекции: {list.Count()}");
                        Console.ReadKey();
                        //Подсчет количества объектов
                        break;
                    case 6:
                        list.PrintList();
                        //печать
                        break;

                }
                Console.Clear();
            }
            list.RemoveCollection();
        }
        private static void Task2()
        {
            {
                int menu = 1;
                MyLinkedList linlkedList = new MyLinkedList();
                do
                {
                    menu = Task1_Menu();
                    Console.Clear();
                    switch (menu)
                    {
                        case 1:
                            //формирование коллеции
                            int size = ReadNumber(-1, 50, "Введите размер однонаправленного списка: ");
                            linlkedList = new MyLinkedList(size);                                      //создание списка
                            linlkedList.PrintList();
                            break;
                        case 2:
                            //добавление в коллекцию
                            int add = ReadNumber(0, 4, "1. В начало" + "\n2. В конец" + "\n3. После элемента\n");
                            switch (add)
                            {
                                //в начало
                                case 1:
                                    linlkedList.AddToBegin(MakeObject());
                                    break;
                                //в конец
                                case 2:
                                    linlkedList.AddToEnd(MakeObject());
                                    break;
                                case 3:
                                    Console.WriteLine("Введите ключ для поиска: ");
                                    Person key = MakeObject();
                                    Console.WriteLine("Введите элемент для добавления после ключа: ");
                                    Person addAfterKey = MakeObject();
                                    linlkedList.AddAfterKey(key, addAfterKey);
                                    break;
                            }
                            linlkedList.PrintList();
                            break;
                        case 3:
                            Console.WriteLine("Удаление по ключу:");
                            linlkedList.RemoveKey(MakeObject());
                            linlkedList.PrintList();
                            break;

                        case 4:
                            //клонирование
                            int clone = ReadNumber(0, 3, "1. Глубокое клонирование" + "\n2. Поверхностное\n");
                            switch (clone)
                            {
                                //полное 
                                case 1:
                                    MyLinkedList listClone = linlkedList.Clone();
                                    Console.WriteLine("Копия создана");
                                    listClone.PrintList();
                                    break;
                                //поверхностниое
                                case 2:
                                    MyLinkedList listShallowCopy = linlkedList.ShallowCopy();
                                    Console.WriteLine("Копия создана");
                                    listShallowCopy.PrintList();
                                    break;
                            }

                            break;
                        case 5:
                            Console.WriteLine($"Размер коллекции: {linlkedList.Count()}");
                            Console.ReadKey();
                            //Подсчет количества объектов
                            break;
                        case 6:
                            linlkedList.PrintList();
                            //печать
                            break;

                    }
                    Console.Clear();
                } while (menu != 7);

                linlkedList.RemoveCollection();

            }
        }
        private static void Task3()
        {
            {
                int menu = 1;
                IdealTree tree = new IdealTree();
               
                do
                {
                    menu = TaskTree_Menu();
                    Console.Clear();
                    switch (menu)
                    {
                        case 1:
                            //формирование дерева
                            int size = ReadNumber(-1, 50, "Введите количество элементов дерева: ");
                            tree = new IdealTree(size);
                            tree.Show();

                            break;

                        case 2:
                            //Подсчет листьев
                            int numberOfLeaves = tree.CountLeaves(tree.root);
                            Console.WriteLine($"Количество листьев в дереве = {numberOfLeaves}\n");
                            tree.Show();            
                            break;

                        case 3:
                            //Преобразование в дерево поиска
                            tree.Show();
                            Console.WriteLine("_______________________________________");
                            SearchTree<Person> serachTree = tree.IdealToSearchTree();
                            serachTree.Show();
                            break;

                        
                        case 4:
                            Console.WriteLine($"Количество объектов в дереве: {tree.Count()}");
                            Console.ReadKey();
                            //Подсчет количества объектов
                            break;

                        case 5:
                            tree.Show();
                            //печать
                            break;

                    }
                    Console.Clear();
                } while (menu != 6);

                tree.RemoveCollection();

            }
        }
        private static void Task4()
        {
            {
                int menu = 1;
                SearchTree<Person> searchTree = new SearchTree<Person>();

                do
                {
                    menu = TaskSearchTree_Menu();
                    Console.Clear();
                    switch (menu)
                    {
                        case 1:
                            //формирование дерева
                            int size = ReadNumber(-1, 50, "Введите количество элементов дерева: ");
                            searchTree = new SearchTree<Person>(size);
                            searchTree.Show();

                            break;

                        case 2:
                            //добавление в коллекцию
                            Console.WriteLine("Добавление элемента");
                            searchTree.Add(MakeObject());
                            searchTree.Show();
                            break;

                        case 3:
                            //Удаление
                            if (searchTree.Remove(MakeObject()))
                                Console.WriteLine("Элемент удален");
                            else 
                                Console.WriteLine("Элемент не найден:");
                            searchTree.Show();
                            break;


                        case 4:
                            //Поиск
                            Person p = MakeObject();
                            bool searchedItem = searchTree.Contains(p);
                            if (!searchedItem)
                            {
                                Console.WriteLine($"Объект {p} не найден");
                            }
                            else
                            {
                                Console.WriteLine($"Объект {p} найден\n");
                            }
                            searchTree.Show();
                            
                            break;

                        case 5:
                            //клонирование
                            int clone = ReadNumber(0, 3, "1. Глубокое клонирование" + "\n2. Поверхностное\n");
                            switch (clone)
                            {
                                //полное 
                                case 1:
                                    SearchTree<Person> cloneTree = searchTree.Clone();

                                    searchTree.Show();
                                    Console.WriteLine("_____________Копия создана___________");
                                    cloneTree.Show();
                                    Console.ReadKey();
                                    break;
                                //поверхностниое
                                case 2:
                                    SearchTree<Person> treeShallowCopy = searchTree.ShallowCopy();
                                    Console.WriteLine("Копия создана");
                                    treeShallowCopy.Show();
                                    break;
                            }

                            break;
                        case 6:
                            Console.WriteLine($"Элементов в коллекции: {searchTree.Count()}" +
                                $"\nНажмите любую клавишу для продолжения...");
                            Console.ReadKey();
                            //печать    
                            break;
                        case 7:
                            searchTree.Show();
                            //печать
                            break;

                    }
                    Console.Clear();
                } while (menu != 8);
            }
        }
        #endregion

        #region Menu
        private static int MainMenu()
        {
            Console.WriteLine("1. List" +
                                "\n2. LinkedList" +
                                "\n3. BinaryTree" +
                                "\n4. Коллекция дерева поиска" +
                                "\n5. Выход");

            int choise = ReadNumber(0, 6, "Выберите задание: ");
            return choise;
        }
        private static int Task1_Menu()
        {
            Console.WriteLine("1. Формирование коллекции" +
                                "\n2. Добавление элемента" +
                                "\n3. Удаление элемента" +
                                "\n4. Клонирование коллекции" +
                                "\n5. Размер коллекции" +
                                "\n6. Печать" +
                                "\n7. Выход в меню");

            int choise = ReadNumber(0, 8, "Выберите номер: ");
            return choise;
        }

        private static int TaskTree_Menu()
        {
            Console.WriteLine("1. Формирование коллекции" +
                                "\n2. Подсчет количества листьев" +
                                "\n3. Форматирование в дерево поиска" +
                                "\n4. Размер коллекции" +
                                "\n5. Печать" +
                                "\n6. Выход в меню");

            int choise = ReadNumber(0, 7, "Выберите номер: ");
            return choise;
        }
        private static int TaskSearchTree_Menu()
        {
            Console.WriteLine("1. Формирование коллекции" +
                                "\n2. Добавление элемента" +
                                "\n3. Удаление элемента" +
                                "\n4. Поиск по значению" +
                                "\n5. Клонирование" +
                                "\n6. Подсчет количества элементов" +
                                "\n7. Печать дерева" +
                                "\n8. Выход в меню");

            int choise = ReadNumber(0, 9, "Выберите номер: ");
            return choise;
        }
        #endregion

    }
}
