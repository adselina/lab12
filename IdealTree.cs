using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Tree;
using ClassLibrary;

namespace IdealTreeSpace
{
    public class IdealTree : IEnumerable
    {
        public Point root = null; //корень

        public IdealTree()
        {
            root = null;
        }                       //создание сбалансированного дерева
        public IdealTree(params Person[] arr)
        {
            if (arr.Length != 0)
            {
                root = new Point(arr[0]);
                root = MakeIdealTree(arr.Length, root, 0, arr);
            }

        }   //создание сбалансированного дерева
        public IdealTree(int size)
        {
            Point p = new Point();
            root = p;
            root = MakeIdealTree(size, p);
        }              //создание сбалансированного дерева


        private static Point MakeIdealTree(int size, Point p)
        {
            Point r;
            int nl, nr;
            if (size == 0)
            {
                p = null;
                return p;
            }

            nl = size / 2;
            nr = size - nl - 1;
            Random rnd = new Random();

            r = new Point(new Person());

            r.left = MakeIdealTree(nl, r.left);
            r.right = MakeIdealTree(nr, r.right);
            return r;
        }
        private static Point MakeIdealTree(int size, Point p, int i, params Person[] arr)
        {
            Point r;
            int nl, nr;
            if (size == 0)
            {
                p = null;
                return p;
            }

            nl = size / 2;
            nr = size - nl - 1;
            Random rnd = new Random();

            r = new Point(arr[i++]);

            r.left = MakeIdealTree(nl, r.left, i, arr);
            r.right = MakeIdealTree(nr, r.right, i, arr);
            return r;
        }

        public static List<Person> list = new List<Person>();

        public SearchTree<Person> IdealToSearchTree()
        {
            foreach (Person item in this)
            {
                list.Add(item);
            }
            Person[] arr = list.ToArray();
            SearchTree<Person> tree = new SearchTree<Person>(arr);
            list.Clear();
            return tree;
        }

        private void ShowTree(Point p, int l)
        {
            if (p != null)
            {

                ShowTree(p.left, l + 3);
                for (int i = 0; i < l; i++)
                    Console.Write("-");
                Console.WriteLine(p.data);
                ShowTree(p.right, l + 3);

            }
        }     //печать поддерьвьев
        public void Show()
        {
            if (root == null)
            {
                Console.WriteLine("Пустое дерево");
            }
            else
                ShowTree(root, 5);
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }                        //печать всего дерева

        public int CountLeaves(Point root)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.left == null && root.right == null)
            {
                return 1;
            }
            else
            {
                return CountLeaves(root.left) + CountLeaves(root.right);
            }
        }        //подсчет количества листьев дерева
        public int Count()
        {
            int i = 0;
            foreach (Person item in this)
            {
                i++;
            }
            return i;
        }

        public void RemoveCollection()
        {
            this.root = null;
        }

        public IEnumerator InOrderTraversal()
        {
            // Это нерекурсивный алгоритм.
            // Он использует стек для того, чтобы избежать рекурсии.
            if (root != null)
            {
                // Стек для сохранения пропущенных узлов.
                Stack<Point> stack = new Stack<Point>();

                Point current = root;

                // Когда мы избавляемся от рекурсии, нам необходимо
                // запоминать, в какую стороны мы должны двигаться.
                bool goLeftNext = true;

                // Кладем в стек корень.
                stack.Push(current);

                while (stack.Count > 0)
                {
                    // Если мы идем налево...
                    if (goLeftNext)
                    {
                        // Кладем все, кроме самого левого узла на стек.
                        // Крайний левый узел мы вернем с помощю yield.
                        while (current.left != null)
                        {
                            stack.Push(current);
                            current = current.left;
                        }
                    }

                    // Префиксный порядок: left->yield->right.
                    yield return current.data;

                    // Если мы можем пойти направо, идем.
                    if (current.right != null)
                    {
                        current = current.right;

                        // После того, как мы пошли направо один раз,
                        // мы должным снова пойти налево.
                        goLeftNext = true;
                    }
                    else
                    {
                        // Если мы не можем пойти направо, мы должны достать родительский узел
                        // со стека, обработать его и идти в его правого ребенка.
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }
        public IEnumerator GetEnumerator()
        {
            return InOrderTraversal();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
