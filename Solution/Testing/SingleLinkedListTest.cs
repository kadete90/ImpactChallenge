using System;
using FcLinkedList.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Testing
{
    [TestClass]
    public class SingleLinkedListTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            FcLinkedList<int> linkedList = new FcLinkedList<int>();
            linkedList.AddFirst(10);
            linkedList.AddFirst(15);
            linkedList.AddFirst(30);
            linkedList.AddFirst(25);
            linkedList.AddFirst(25);

            linkedList.Dump();

            Assert.AreEqual(5, linkedList.Count());

            linkedList.Remove(10);

            linkedList.Dump();

            Assert.AreEqual(4, linkedList.Count());
        }
    }

    internal static class Utils
    {
        public static void Dump(this object o)
        {
            string json = JsonConvert.SerializeObject(o, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}
