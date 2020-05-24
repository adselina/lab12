using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using List;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTestList
    {
        [TestMethod]
        public void ListPoint()
        {
            //arrange
            Point point = new Point();
            Person data = new Person("1", 1);
            point = new Point(data);

            //act
            Person expectedData = new Person("1", 1);

            ////assert
            Assert.AreEqual(point.data, expectedData);
        }

        [TestMethod]
        public void Length()
        {
            //arrange
            MyList list = new MyList();
            int actual = list.Length;

            MyList list2 = new MyList(3);
            int actual2 = list2.Length;
            //act
            int expected = 0;
            int expected2 = 3;

            ////assert
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(actual2, expected2);
        }

        [TestMethod]
        public void AddToBegin()
        {
            //arrange
            Person p1 = new Person("1", 1);
            Person p2 = new Person("2", 2);
            Person p3 = new Person("3", 3);

            Person[] arr = { p2, p3 };
            MyList list = new MyList(arr);

            //act
            list.AddToBegin(p1);

            ////assert
            Assert.AreEqual(list.Begin.data, p1);
            Assert.AreEqual(list.Begin.next.data, p2);

        }

        [TestMethod]
        public void AddToClearList()
        {
            //arrange
            Person p1 = new Person("1", 1);
            
            MyList list = new MyList();

            //act
            list.AddToBegin(p1);

            ////assert
            Assert.AreEqual(list.Length, 1);
            Assert.AreEqual(list.Begin.data, p1);

        }
        [TestMethod]
        public void AddToEnd()
        {
            //arrange
            Person p1 = new Person("1", 1);
            Person p2 = new Person("2", 2);
            Person p3 = new Person("3", 3);

            Person[] arr = { p2, p3 };
            MyList list = new MyList(arr);

            //act
            list.AddToEnd(p1);

            ////assert
            Assert.AreEqual(list.End.data, p1);    
        }

        [TestMethod]
        public void Clone()
        {
            //arrange
            Person p1 = new Person("1", 1);
            Person p2 = new Person("2", 2);         

            Person[] arr = { p1, p2 };
            MyList list = new MyList(arr);

            //act
            MyList listClone = new MyList();
            listClone = list.Clone();

            ////assert
            Assert.AreEqual(list.Begin.data, listClone.Begin.data);
            Assert.AreEqual(list.End.data, listClone.End.data);
            
        }
        [TestMethod]
        public void Count()
        {
            //arrange
            Person p1 = new Person("1", 1);
            Person p2 = new Person("2", 2);

            Person[] arr = { p1, p2 };
            MyList list = new MyList(arr);

            //act
            int lenght = list.Count();

            ////assert
            Assert.AreEqual(lenght, 2);
        }

        [TestMethod]
        public void ShallowCopy()
        {
            //arrange
            Person p1 = new Person("1", 1);
            Person p2 = new Person("2", 2);

            Person[] arr = { p1, p2 };
            MyList list = new MyList(arr);

            //act
            MyList listCopy = new MyList(arr);
            listCopy = list.ShallowCopy();

            ////assert
           Assert.AreEqual(list, listCopy);
        }


        [TestMethod]
        public void RemoveEverySecond_OneElem()
        {
            //arrange
            MyList list = new MyList();
            list.Begin = new Point(new Person("1", 1));

            //act
            list.RemoveEverySecond();

            ////assert
            Assert.AreEqual(list.Length, 1);
        }

        [TestMethod]
        public void RemoveEverySecond_ClearCollection()
        {
            //arrange
            MyList list = new MyList();

            //act
            list.RemoveEverySecond();

            ////assert
            Assert.AreEqual(list.Length, 0);
        }

        [TestMethod]
        public void RemoveEverySecond()
        {
            //arrange
            MyList list2 = new MyList(3);

            //act
            list2.RemoveEverySecond();

            ////assert
            Assert.AreEqual(list2.Length, 2);
            Assert.AreEqual(list2.Begin.next, list2.End);
        }


        [TestMethod]
        public void RemoveKey_ClearCollection()
        {
            //arrange
            Person p1 = new Person("1", 1);
            
            MyList list = new MyList();

            //act
            list.RemoveKey(p1);

            ////assert
            Assert.AreEqual(list.Length, 0);
        }

        [TestMethod]
        public void RemoveKey_OneElement()
        {
            //arrange
            Person p1 = new Person("1", 1);
            MyList list = new MyList(p1);

            //act
            list.RemoveKey(p1);

            ////assert
            Assert.AreEqual(list.End, list.Begin);
            Assert.AreEqual(list.Length, 0);
        }

        [TestMethod]
        public void RemoveKey_OneElement_NoKey()
        {
            //arrange
            Person p1 = new Person("1", 1);
            Person p2 = new Person("2", 2);

            MyList list = new MyList(p1);

            //act
            list.RemoveKey(p2);

            ////assert
            Assert.AreEqual(list.Length, 1);
        }

        [TestMethod]
        public void RemoveKey_RemoveFirst_Key()
        {
            //arrange
          
            MyList list = new MyList(4);
            Person p = list.Begin.data;
            Person p2 = list.Begin.next.data;
            //act
            list.RemoveKey(p);

            ////assert
            Assert.AreEqual(list.Length, 3);
            Assert.AreEqual(list.Begin.data, p2);
        }

        [TestMethod]
        public void RemoveKey_Middle()
        {
            //arrange
            MyList list = new MyList(4);
            Person p2 = list.Begin.next.data;
            Person p3 = list.Begin.next.next.data;

            //act
            list.RemoveKey(p2);

            ////assert
            Assert.AreEqual(list.Length, 3);
            Assert.AreEqual(list.Begin.next.data, p3);
        }

        [TestMethod]
        public void RemoveKey_NoKey()
        {
            //arrange
            MyList list = new MyList(4);
            Person p = new Person("1", 1);
           
            //act
            list.RemoveKey(p);

            ////assert
            Assert.AreEqual(list.Length, 4);
        }

        [TestMethod]
        public void RemoveKey_EndKey()
        {
            //arrange
            MyList list = new MyList(5);
            list.AddToEnd(new Person("1", 1));


            //act
            list.RemoveKey(new Person("1", 1));

            ////assert
            Assert.AreEqual(list.Length, 5);
        }


    }
}
