using NUnit.Framework;
using NCS.DSS.Anonymise.Helpers;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            string myString = NCS.DSS.Anonymise.Helpers.AnonHelper.GetRandomForename("123");
            Assert.Greater(myString.Length, 0);
        }
    }
}