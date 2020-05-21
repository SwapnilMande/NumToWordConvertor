using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberToWordConvertor;

namespace NumToWordUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Program program = new Program();
            string NuminWords = program.ProcessNumberforConversion(123);
            Assert.AreEqual(NuminWords, " One Hundred Twenty Three");
        }
    }
}
