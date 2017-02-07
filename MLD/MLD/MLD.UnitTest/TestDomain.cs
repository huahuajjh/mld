using System;
using System.Drawing;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLD.Library.Constant;
using MLD.Library.Helper;
using MLD.Library.Log;
using MLD.Library.SerializeHelper;

namespace MLD.UnitTest
{
    [TestClass]
    public class TestDomain
    {
        [TestMethod]
        public void TestLogin()
        {
            var rs = DateHelper.DiffTime(DateTime.Parse("2015/08/05 12:30"), DateTime.Parse("2015/08/05 08:30"));
            Console.WriteLine((DateTime.Parse("2015/08/05 12:30") - DateTime.Parse("2015/08/05 08:30")).Days);
        }
    }
}
