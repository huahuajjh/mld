using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLD.ViewModel.State;

namespace MLD.UnitTest
{
    [TestClass]
    public class TestDateTime
    {
        [TestMethod]
        public void TestDate()
        {
            DateTime dt = DateTime.Parse("2015-09-13");
            Console.WriteLine(dt.ToString("d"));
        }
    }
}
