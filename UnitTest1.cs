using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomListClass;

namespace ListTestClass
{
    [TestClass]
    public class AddMethodTest
    {
        [TestMethod]
        public void AddTest_CheckIndexZero_NewStringInArray()
        {
            //arrange
            string name = "chris";
            string expected = "chris";
            string actual;
            //act
            CustomList<string> names = new CustomList<string>();
            names.Add(name);
            actual = names[0];
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTest_CheckCountOne_IntegerOfOne()
        {
            //arrange
            string name = "chris";
            int expected = 1;
            int actual;
            //act
            CustomList<string> names = new CustomList<string>();
            names.Add(name);
            actual = names.Count;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTest_CheckCapacityDefault_CapacityOfFour()
        {
            //arrange
            string name = "chris";
            int expected = 4;
            int actual;
            //act
            CustomList<string> names = new CustomList<string>();
            names.Add(name);
            actual = names.Capacity;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTest_CheckCapacityIfArrayGoesOverFour_CapacityOfEight()
        {
            //arrange
            int expected = 8;
            int actual;
            //act
            CustomList<int> names = new CustomList<int>();
            for (int i = 0; i <= 5; i++)
            {
                names.Add(i);
            }
            actual = names.Capacity;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTest_CheckIndexPastFour_ItemAtIndexIsFour()
        {
            //arrange
            int expected = 5;
            int actual;
            //act
            CustomList<int> names = new CustomList<int>();
            for (int i = 0; i <= 5; i++)
            {
                names.Add(i);
            }
            actual = names[5];
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTest_CheckIndexAtTwoWhenCapacityIsOverFour_IndexAtTwoIs1()
        {
            //arrange
            int expected = 2;
            int actual;
            //act
            CustomList<int> names = new CustomList<int>();
            for (int i = 0; i < 5; i++)
            {
                names.Add(i);
            }
            actual = names[2];
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTest_CheckCount_CountIsFive()
        {
            //arrange
            int expected = 5;
            int actual;
            //act
            CustomList<int> names = new CustomList<int>();
            for (int i = 0; i < 5; i++)
            {
                names.Add(i);
            }
            actual = names.Count;
            //assert
            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass]
    public class RemoveMethodTest
    {
        [TestMethod]
        public void RemoveTest_ItemIsRemoved_CountDecrements()
        {
            //arrange
            int expected = 3;
            int actual;
            //act
            CustomList<string> names = new CustomList<string>();
            names.Add("Chris");
            names.Add("Shannon");
            names.Add("Austin");
            names.Add("Aaron");
            names.Remove("Shannon");
            actual = names.Count;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveTest_AttemptToRemoveSomethingNotInList_CountRemainsSame()
        {
            //arrange
            int expected = 4;
            int actual;
            //act
            CustomList<string> names = new CustomList<string>();
            names.Add("Chris");
            names.Add("Shannon");
            names.Add("Austin");
            names.Add("Aaron");
            names.Remove("Boberney");
            actual = names.Count;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveTest_AttemptToRemoveSomethingNotInList_ItemsRemainInSamePosition()
        {
            //arrange
            string expected = "Austin";
            string actual;
            //act
            CustomList<string> names = new CustomList<string>();
            names.Add("Chris");
            names.Add("Shannon");
            names.Add("Austin");
            names.Add("Aaron");
            names.Remove("Bobert");
            actual = names[2];
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveTest_ItemIsRemoved_TrueStatementReturned()
        {
            //arrange
            bool expected = true;
            bool actual;
            //act
            CustomList<string> names = new CustomList<string>();
            names.Add("Chris");
            names.Add("Shannon");
            names.Add("Austin");
            names.Add("Aaron");
            actual = names.Remove("Shannon");
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveTest_ItemIsNotRemoved_FalseStatementReturned()
        {
            //arrange
            bool expected = false;
            bool actual;
            //act
            CustomList<string> names = new CustomList<string>();
            names.Add("Chris");
            names.Add("Shannon");
            names.Add("Austin");
            names.Add("Aaron");
            actual = names.Remove("Henlo World");
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveTest_CountFromFiveToFour_CapacityStillEight()
        {
            //arrange
            int expected = 8;
            int actual;
            //act
            CustomList<string> names = new CustomList<string>();
            names.Add("Chris");
            names.Add("Shannon");
            names.Add("Austin");
            names.Add("Aaron");
            names.Add("CJ");
            names.Remove("Aaron");
            actual = names.Capacity;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveTest_DuplicateItemsInList_RemovesFirstInstance()
        {
            //arrange
            string expected = "Shannon";
            string actual;
            //act
            CustomList<string> names = new CustomList<string>();
            names.Add("Chris");
            names.Add("Shannon");
            names.Add("Austin");
            names.Add("Shannon");
            names.Add("CJ");
            names.Remove("Shannon");
            actual = names[2];
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveTest_LowerCaseAndUpperCaseOfSameItem_RemovesTheItemThatMatchesExactly()
        {
            //arrange
            string expected = "Chris";
            string actual;
            //act
            CustomList<string> names = new CustomList<string>();
            names.Add("Chris");
            names.Add("chris");
            names.Remove("chris");
            actual = names[0];
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveTest_Remove_RemovesFirstInstance()
        {
            //arrange
            string expected = "Shannon";
            string actual;
            //act
            CustomList<string> names = new CustomList<string>();
            names.Add("Chris");
            names.Add("Shannon");
            names.Add("Austin");
            names.Add("Shannon");
            names.Add("CJ");
            names.Remove("Shannon");
            actual = names[2];
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveTest_IntegersInsteadOfString_RemovesFirstOccurenceOfInteger()
        {
            //arrange
            int expected = 5;
            int actual;
            //act
            CustomList<int> names = new CustomList<int>();
            for (int i = 0; i < 6; i++)
            {
                names.Add(i);
            }
            names.Remove(4);
            actual = names[4];
            //assert
            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass]
    public class RemoveAtMethodTest
    {
        [TestMethod]
        public void RemoveAtTest_RemoveAtIndex_ItemAtIndexTwoRemoved()
        {
            //arrange
            CustomList<int> numbers = new CustomList<int>();
            CustomList<int> expected = new CustomList<int>();
            CustomList<int> actual = new CustomList<int>();
            expected.Add(1);
            expected.Add(2);
            expected.Add(3);
            expected.Add(5);
            //act
            for (int i = 1; i < 6; i++)
            {
                actual.Add(i);
            }
            actual.RemoveAt(3);
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void RemoveAtTest_RemoveAtIndex_ItemAtIndexZeroRemoved()
        {
            //arrange
            CustomList<int> numbers = new CustomList<int>();
            CustomList<int> expected = new CustomList<int>();
            CustomList<int> actual = new CustomList<int>();
            expected.Add(2);
            expected.Add(3);
            expected.Add(4);
            expected.Add(5);
            //act
            for (int i = 1; i < 6; i++)
            {
                actual.Add(i);
            }
            actual.RemoveAt(0);
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void RemoveAtTest_RemoveAtIndex_StringRemovedAtIndexOne()
        {
            //arrange
            CustomList<string> numbers = new CustomList<string>();
            CustomList<string> expected = new CustomList<string>();
            CustomList<string> actual = new CustomList<string>();
            expected.Add("chris");
            expected.Add("austin");
            expected.Add("cj");
            expected.Add("jack");
            //act
            actual.Add("chris");
            actual.Add("aaron");
            actual.Add("austin");
            actual.Add("cj");
            actual.Add("jack");
            actual.RemoveAt(1);
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void RemoveAtTest_CheckCount_CountIsFour()
        {
            //arrange
            CustomList<string> numbers = new CustomList<string>();
            CustomList<string> tempList = new CustomList<string>();
            int expected = 4;
            //act
            tempList.Add("chris");
            tempList.Add("aaron");
            tempList.Add("austin");
            tempList.Add("cj");
            tempList.Add("jack");
            tempList.RemoveAt(1);

            int actual = tempList.Count;
            //assert
            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass]
    public class ToStringOverrideTest
    {
        [TestMethod]
        public void ToStringTest_IntegersAdded_AllIntegersInOneString()
        {
            //arrange
            string expected = "1, 2, 3";
            string actual;
            //act
            CustomList<int> numbers = new CustomList<int>();
            for (int i = 1; i <= 3; i++)
            {
                numbers.Add(i);
            }
            actual = numbers.ToString();
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToStringTest_Strings_AllStringsIntoOneString()
        {
            //arrange
            string expected = "chris, austin, shannon";
            string actual;
            //act
            CustomList<string> names = new CustomList<string>();
            names.Add("chris");
            names.Add("austin");
            names.Add("shannon");
            actual = names.ToString();
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToStringTest_Booleans_PrintTrueToString()
        {
            //arrange
            string expected = "True, False, True, True";
            string actual;
            //act
            CustomList<bool> bools = new CustomList<bool>();
            bools.Add(true);
            bools.Add(false);
            bools.Add(true);
            bools.Add(true);
            actual = bools.ToString();
            //assert
            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass]
    public class AdditionOverloadTest
    {
        [TestMethod]
        public void AdditionOverloadTest_TwoIntegerLists_OneIntegerList()
        {
            //arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            CustomList<int> expected = new CustomList<int>();
            CustomList<int> actual;

            for (int i = 1; i <= 6; i++)
            {
                expected.Add(i);
            }

            //act
            for (int i = 1; i <= 3; i++)
            {
                list1.Add(i);
            }

            for (int i = 4; i <= 6; i++)
            {
                list2.Add(i);
            }
            actual = list1 + list2;
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void AdditionOverloadTest_TwoStringLists_OneStringList()
        {
            //arrange
            CustomList<string> list1 = new CustomList<string>();
            CustomList<string> list2 = new CustomList<string>();
            CustomList<string> expected = new CustomList<string>();
            CustomList<string> actual;
            expected.Add("hello");
            expected.Add("world");
            //act
            list1.Add("hello");
            list2.Add("world");
            actual = list1 + list2;
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void AdditionOverloadTest_OneListDoubleTheSizeOfTheOther_OneListWithBothCombined()
        {
            //arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            CustomList<int> expected = new CustomList<int>();
            CustomList<int> actual;

            for (int i = 1; i <= 8; i++)
            {
                expected.Add(i);
            }
            //act
            for (int i = 1; i <= 2; i++)
            {
                list1.Add(i);
            }
            for (int i = 3; i <= 8; i++)
            {
                list2.Add(i);
            }
            actual = list1 + list2;
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }

    [TestClass]
    public class SubtractionOverloadTest
    {
        [TestMethod]
        public void SubtractionOverloadTest_ListsOfInts_NewListWithRemovedItems()
        {
            //arrange
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            CustomList<int> expected = new CustomList<int>();
            CustomList<int> actual;

            expected.Add(3);
            expected.Add(5);
            //act
            list1.Add(1);
            list1.Add(3);
            list1.Add(5);

            list2.Add(2);
            list2.Add(1);
            list2.Add(6);
            actual = list1 - list2;
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void SubtractionOverloadTest_ListsOfString_NewListWithRemovedStrings()
        {
            //arrange
            CustomList<string> list1 = new CustomList<string>();
            CustomList<string> list2 = new CustomList<string>();
            CustomList<string> expected = new CustomList<string>();
            CustomList<string> actual;

            expected.Add("austin");
            expected.Add("shannon");
            //act
            list1.Add("chris");
            list1.Add("austin");
            list1.Add("shannon");

            list2.Add("chris");
            list2.Add("aaron");
            list2.Add("cj");
            actual = list1 - list2;
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void SubtractionOverloadTest_SecondListDoesNotHaveAnyItemsFromFirst_NewListSameAsFirstList()
        {
            //arrange
            CustomList<string> list1 = new CustomList<string>();
            CustomList<string> list2 = new CustomList<string>();
            CustomList<string> expected = new CustomList<string>();
            CustomList<string> actual;

            expected.Add("chris");
            expected.Add("austin");
            expected.Add("shannon");
            //act
            list1.Add("chris");
            list1.Add("austin");
            list1.Add("shannon");

            list2.Add("jack");
            list2.Add("aaron");
            list2.Add("cj");
            actual = list1 - list2;
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void SubtractionOverloadTest_FirstListItemsRemovedCompletely_NewListIsEmpty()
        {
            //arrange
            CustomList<string> list1 = new CustomList<string>();
            CustomList<string> list2 = new CustomList<string>();
            CustomList<string> expected = new CustomList<string>();
            CustomList<string> actual;

            //act
            list1.Add("chris");
            list1.Add("austin");
            list1.Add("shannon");

            list2.Add("chris");
            list2.Add("austin");
            list2.Add("shannon");
            actual = list1 - list2;
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void SubtractionOverloadTest_ActualListCount_CountIsTwo()
        {
            //arrange
            CustomList<string> list1 = new CustomList<string>();
            CustomList<string> list2 = new CustomList<string>();
            CustomList<string> newList;
            int expected = 2;
            int actual;

            //act
            list1.Add("chris");
            list1.Add("austin");
            list1.Add("shannon");

            list2.Add("chris");
            list2.Add("cj");
            list2.Add("aaron");
            newList = list1 - list2;
            actual = newList.Count;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractionOverloadTest_CheckCountOfTempLists_CountStaysAtThree()
        {
            //arrange
            CustomList<string> list1 = new CustomList<string>();
            CustomList<string> list2 = new CustomList<string>();
            CustomList<string> newList;
            int expected = 3;
            int actual;

            //act
            list1.Add("chris");
            list1.Add("austin");
            list1.Add("shannon");

            list2.Add("chris");
            list2.Add("cj");
            list2.Add("aaron");
            newList = list1 - list2;
            actual = list1.Count;
            //assert
            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass]
    public class ZipListsTest
    {
        [TestMethod]
        public void ZipTest_EvenAndOddLists_OneIncrementingList()
        {
            //arrange
            CustomList<int> even = new CustomList<int>();
            CustomList<int> odd = new CustomList<int>();
            CustomList<int> expected = new CustomList<int>();
            CustomList<int> actual = new CustomList<int>();
            for (int i = 1; i < 7; i++)
            {
                expected.Add(i);
            }
            //act
            even.Add(2);
            even.Add(4);
            even.Add(6);
            odd.Add(1);
            odd.Add(3);
            odd.Add(5);
            actual = CustomList<int>.Zip(odd, even);
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void ZipTest_EvenAndOddListsInWrongOrder_IncorrectOrderOfNumbers()
        {
            //arrange
            CustomList<int> even = new CustomList<int>();
            CustomList<int> odd = new CustomList<int>();
            CustomList<int> expected = new CustomList<int>();
            CustomList<int> actual = new CustomList<int>();
            expected.Add(2);
            expected.Add(1);
            expected.Add(4);
            expected.Add(3);
            expected.Add(6);
            expected.Add(5);
            //act
            even.Add(2);
            even.Add(4);
            even.Add(6);
            odd.Add(1);
            odd.Add(3);
            odd.Add(5);
            actual = CustomList<int>.Zip(even,odd);
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void ZipTest_IntListsOfDifferentSizes_ContinueThroughListWithNoMoreItems()
        {
            //arrange
            CustomList<int> even = new CustomList<int>();
            CustomList<int> odd = new CustomList<int>();
            CustomList<int> expected = new CustomList<int>();
            CustomList<int> actual = new CustomList<int>();
            expected.Add(2);
            expected.Add(1);
            expected.Add(4);
            expected.Add(6);
            //act
            even.Add(2);
            even.Add(4);
            even.Add(6);
            odd.Add(1);
            actual = CustomList<int>.Zip(even, odd);
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void ZipTest_OneListIsEmpty_DisplayEntiretyOfOtherList()
        {
            //arrange
            CustomList<int> even = new CustomList<int>();
            CustomList<int> odd = new CustomList<int>();
            CustomList<int> expected = new CustomList<int>();
            CustomList<int> actual = new CustomList<int>();
            expected.Add(2);
            expected.Add(4);
            expected.Add(6);
            //act
            even.Add(2);
            even.Add(4);
            even.Add(6);
            actual = CustomList<int>.Zip(even, odd);
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void ZipTest_CountCheckNewList_CountShouldBeSix()
        {
            //arrange
            CustomList<int> even = new CustomList<int>();
            CustomList<int> odd = new CustomList<int>();
            CustomList<int> tempList = new CustomList<int>();
            int expected = 6;
            int actual;
            //act
            even.Add(2);
            even.Add(4);
            even.Add(6);
            odd.Add(1);
            odd.Add(3);
            odd.Add(5);
            tempList = CustomList<int>.Zip(odd,even);
            actual = tempList.Count;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ZipTest_CountCheckOddList_CountShouldBeThree()
        {
            //arrange
            CustomList<int> even = new CustomList<int>();
            CustomList<int> odd = new CustomList<int>();
            CustomList<int> tempList;
            int expected = 3;
            int actual;
            //act
            even.Add(2);
            even.Add(4);
            even.Add(6);
            odd.Add(1);
            odd.Add(3);
            odd.Add(5);
            tempList = CustomList<int>.Zip(odd, even);
            actual = odd.Count;
            //assert
            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass]
    public class SortMethodTest
    {
        [TestMethod]
        public void SortTest_ListOfInts_RearrangeInCorrectOrder()
        {
            //arrange
            IntTest sort = new IntTest();
            CustomList<int> actual = new CustomList<int>();
            CustomList<int> expected = new CustomList<int>();
            for (int i = 1; i < 7; i++)
            {
                expected.Add(i);
            }
            //act
            actual.Add(3);
            actual.Add(1);
            actual.Add(2);
            actual.Add(6);
            actual.Add(4);
            actual.Add(5);

            actual.Sort(sort);
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void SortTest_ListOfStrings_RearrangeInCorrectOrderBasedOnFirstCharacter()
        {
            //arrange
            StringTest sort = new StringTest();
            CustomList<string> actual = new CustomList<string>();
            CustomList<string> expected = new CustomList<string>();

            expected.Add("Aaron");
            expected.Add("austin");
            expected.Add("chris");
            expected.Add("Cj");
            expected.Add("jack");
            expected.Add("shannon");

            //act
            actual.Add("Aaron");
            actual.Add("Cj");
            actual.Add("shannon");
            actual.Add("jack");
            actual.Add("austin");
            actual.Add("chris");

            actual.Sort(sort);
            //assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}
