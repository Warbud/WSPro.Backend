using NUnit.Framework;
using WSPro.Backend.Model;

namespace Test.WSPro.Backend.Model
{
    public class CraneTest
    {
        /// <summary>
        ///     Test sprawdzaojący poprawność metody IsValidName klasy Crane.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="expectedIsValid"></param>
        [TestCase("00", false)]
        [TestCase("C1000", false)]
        [TestCase("L00", false)]
        [TestCase("01", true)]
        public void TestCraneNameValidator(string name, bool expectedIsValid)
        {
            Assert.AreEqual(Crane.IsValidName(name), expectedIsValid);
        }
    }
}