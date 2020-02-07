using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailSender.lib.Tests.Service
{
    [TestClass]
    public class TestEncoderTests
    {
        static TestEncoderTests()
        {

        }

        public TestEncoderTests()
        {

        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext Context)
        {

        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext Context)
        {

        }

        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestCleanup]
        public void TestCleanup()
        {

        }

        [ClassCleanup]
        public static void ClassCleanup()
        {

        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {

        }

        [TestMethod]
        public void Encode_ABC_to_BCD_with_key_1()
        {
            // A-A-A = Arrange - Act - Assert

            const string str = "ABC";
            const int key = 1;
            const string expected_str = "BCD";

            var actual_str = TextEncoder.Encode(str, key);

            Assert.AreEqual(expected_str, actual_str);
        }

        [TestMethod]
        public void Decode_BCD_to_ABC_with_key_1()
        {
            // A-A-A = Arrange - Act - Assert

            const string str = "BCD";
            const int key = 1;
            const string expected_str = "ABC";

            var actual_str = TextEncoder.Decode(str, key);

            Assert.AreEqual(expected_str, actual_str);

            //StringAssert.Matches();
            //CollectionAssert.AllItemsAreNotNull();
        }
    }
}
