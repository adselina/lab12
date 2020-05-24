using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using LinkedList;


namespace UnitTestProject2
{
    [TestClass]
    public class LinkedList
    {
        [TestMethod]
        public void LinkedListPoint()
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
        public void PointToString()

        {
            //arrange
            Point point = new Point();
            Person data = new Person("1", 1);
            point = new Point(data);

            //act
            string expectedData = "1, возраст:1 ";

            ////assert
            Assert.AreEqual(point.ToString(), expectedData);
        }

        [TestMethod]
        public void Length()
        {
            //arrange
            MyLinkedList list = new MyLinkedList();
            int actual = list.Length;

            MyLinkedList list2 = new MyLinkedList(3);
            int actual2 = list2.Length;
            //act
            int expected = 0;
            int expected2 = 3;

            ////assert
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(actual2, expected2);
        }
        [TestMethod]
        public void Begin()
        {
            //arrange
            MyLinkedList list = new MyLinkedList();
            Point actual = list.Begin;
           
            //act
            Point expected = null;

            ////assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void End()
        {
            //arrange
            MyLinkedList list = new MyLinkedList();
            Point actual = list.End;

            //act
            Point expected = null;

            ////assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void AddToEnd_End()
        {
            //arrange
            MyLinkedList list = new MyLinkedList();
            Person p1 = new Person("1", 1);
            Person p2 = new Person("2", 2);
            list.AddToEnd(p1);
            list.AddToEnd(p2);
            Point actual = list.End;

            //act
            Point expected = new Point(p2);

            ////assert
            
            Assert.AreEqual(actual.next, null);
            Assert.AreEqual(actual, list.Begin.next);
        }
        [TestMethod]
        public void AddToBegin_Begin()
        {
            //arrange
            MyLinkedList list = new MyLinkedList();
            Person p1 = new Person("1", 1);
            Person p2 = new Person("2", 2);
            list.AddToBegin(p1);
            list.AddToBegin(p2);
            Point actual = list.Begin;

            //act
            Point expected = new Point(p2);

            ////assert
           
            Assert.AreEqual(actual.next, list.End);
            Assert.AreEqual(actual.pred, null);
        }

        [TestMethod]
        public void Count()
        {
            Person p1 = new Person("1", 1);
            Person p2 = new Person("2", 2);
            Person[] arr = {p1, p2};
            
            //arrange
            MyLinkedList list = new MyLinkedList(arr);
            int actual = list.Count();

            //act
            int expected = arr.Length;

            ////assert
            Assert.AreEqual(actual, expected);
        }

        #region RemoveKey
        [TestMethod]
        public void RemoveKey_Begin()
        {
            Person p1 = new Person("1", 1);
            Point point = new Point(p1);

            //arrange
            MyLinkedList list = new MyLinkedList();
            list.Begin = point;

            list.RemoveKey(p1);
            int actual2 = list.Count();

            //act

            int expected2 = 0;

            ////assert

            Assert.AreEqual(actual2, expected2);
            Assert.AreEqual(list.Begin, null);
        }

        [TestMethod]
        public void RemoveKey_Middle()
        {
            Person p1 = new Person("1", 1);
            Person p2 = new Person("2", 2);
            Person p3 = new Person("3", 3);
            Person p4 = new Person("4", 4);

            Person[] arr = { p1, p2, p3,p4 };

            //arrange
            MyLinkedList list = new MyLinkedList(arr);
            
            list.RemoveKey(p3);
            int actual2 = list.Count();

            //act
            
            int expected2 = 3;

            ////assert
            
            Assert.AreEqual(actual2, expected2);
            Assert.AreEqual(list.End.pred.data, p2);
            Assert.AreEqual(list.Begin.next.data, p2);
        }

        
    

        [TestMethod]
        public void RemoveKey_End()
        {
            Person p1 = new Person("1", 1);
            Person p2 = new Person("2", 2);
            Person p3 = new Person("3", 3);

            Person[] arr = { p1, p2, p3 };

            //arrange
            MyLinkedList list = new MyLinkedList(arr);
            list.RemoveKey(p3);
            int actual2 = list.Count();

            //act
            int expected2 = 2;

            ////assert

            Assert.AreEqual(actual2, expected2);
            Assert.AreEqual(list.Begin.next.data, p2);
            Assert.AreEqual(list.Begin.next.next, null);
        }

        [TestMethod]
        public void RemoveKey_ClearCollection()
        {
            //arrange
            Person p1 = new Person("1", 1);
            MyLinkedList list = new MyLinkedList(p1);
            list.RemoveKey(p1);
            
            //act
            list.RemoveKey(p1);
           

            ////assert
            Assert.AreEqual(list.Count(), 0);
        }

        [TestMethod]
        public void RemoveKey_NoElement()
        {
            Person p1 = new Person("1", 1);
            Person p2 = new Person("2", 2);
            Person p3 = new Person("3", 3);

            Person[] arr = { p1, p2};
            //arrange
            
            MyLinkedList list = new MyLinkedList(arr);

            //act
            list.RemoveKey(p3);


            ////assert
            Assert.AreEqual(list.Count(), 2);
        }

        [TestMethod]
        public void RemoveKey_OneElem_NoKey()
        {
            //arrange
            Person p1 = new Person("1", 1);
            Person p2 = new Person("2", 2);
            MyLinkedList list = new MyLinkedList(p1);

            //act
            list.RemoveKey(p2);

            ////assert
            Assert.AreEqual(list.Count(), 1);
        }

        [TestMethod]
        public void RemoveKey_BeginKey()
        {
            //arrange
            Person p1 = new Person("1", 1);
            Person p2 = new Person("2", 2);

            Person[] arr = { p1, p2 };

            MyLinkedList list = new MyLinkedList(arr);

            //act
            list.RemoveKey(p1);


            ////assert
            Assert.AreEqual(list.Count(), 1);
            Assert.AreEqual(list.Begin.data, p2);
        }
        #endregion

        #region AddAfterKey
        [TestMethod]
        public void AddAfterKey_Middle()
        {
            //arrange
            Person p1 = new Person("1", 1);
            Person p2 = new Person("2", 2);
            Person p3 = new Person("3", 3);
            Person p4 = new Person("4", 4);

            Person[] arr = { p1, p2, p4 };

            MyLinkedList list = new MyLinkedList(arr);

            //act
            list.AddAfterKey(p2, p3);

            ////assert
            Assert.AreEqual(list.Begin.next.next.data, p3);
        }
        [TestMethod]
        public void AddAfterKey_ClearCollection()
        {
            //arrange
            Person p1 = new Person("1", 1);
            Person p2 = new Person("2", 2);

            MyLinkedList list = new MyLinkedList();

            //act
            list.AddAfterKey(p1, p2);

            ////assert
            Assert.AreEqual(list.Count(), 0);
        }

        [TestMethod]
        public void AddAfterKey_OneElementInList()
        {
            //arrange
            Person p1 = new Person("1", 1);
            Person p2 = new Person("2", 2);

            MyLinkedList list = new MyLinkedList(p1);

            //act
            list.AddAfterKey(p1, p2);

            ////assert
            Assert.AreEqual(list.Count(), 2);
            Assert.AreEqual(list.Begin.next.data, p2);
        }

        [TestMethod]
        public void AddAfterKey_EndElementKey()
        {
            //arrange
            Person p1 = new Person("1", 1);
            Person p2 = new Person("2", 2);
            Person p3 = new Person("3", 3);

            Person[] arr = { p1, p2};

            MyLinkedList list = new MyLinkedList(arr);

            //act
            list.AddAfterKey(p2, p3);

            ////assert
            Assert.AreEqual(list.Count(), 3);
            Assert.AreEqual(list.End.data, p3);
        }

        [TestMethod]
        public void AddAfterKey_OneElem_NoKey()
        {
            //arrange
            Person p1 = new Person("1", 1);
            Person p2 = new Person("2", 2);

            MyLinkedList list = new MyLinkedList(p1);

            //act
            list.AddAfterKey(p2, p1);

            ////assert
            Assert.AreEqual(list.Count(), 1);
        }

        [TestMethod]
        public void AddAfterKey_NoKey()
        {
            //arrange
            Person p1 = new Person("1", 1);
            Person p2 = new Person("2", 2);
            Person p3 = new Person("3", 3);
            Person p4 = new Person("4", 4);

            Person[] arr = { p1,p2,p3};

            MyLinkedList list = new MyLinkedList(arr);

            //act
            list.AddAfterKey(p4, p1);

            ////assert
            Assert.AreEqual(list.Count(), 3);
        }
        #endregion
       

        [TestMethod]
        public void ShallowCopy()
        {
            Person p1 = new Person("1", 1);
            Person p2 = new Person("2", 2);
            Person p3 = new Person("3", 3);

            Person[] arr = { p1, p2, p3 };
            //arrange

            MyLinkedList list = new MyLinkedList(arr);

            //act
            MyLinkedList listCopy = new MyLinkedList();
            listCopy = list.ShallowCopy();


            ////assert
            Assert.AreEqual(list, listCopy);
        }

        [TestMethod]
        public void Clone()
        {
            Person p1 = new Person("1", 1);
            Person p2 = new Person("2", 2);

            Person[] arr = { p1, p2 };
            //arrange

            MyLinkedList list = new MyLinkedList(arr);

            //act
            MyLinkedList listCopy = new MyLinkedList();
            listCopy = list.Clone();


            ////assert
            Assert.AreEqual(list.Begin.data, listCopy.Begin.data);
            Assert.AreEqual(list.End.data, listCopy.End.data);

        }
    }
}
