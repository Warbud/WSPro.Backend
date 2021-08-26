using NUnit.Framework;
using WSPro.Backend.Model;

namespace Test.WSPro.Backend.Model
{
    public class LevelTest
    {
        
        /// <summary>
        /// Test sprawdzający poprawność metody IsValidName klasy Level.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="expectedIsValid"></param>
        [TestCase("L01", true)]
        [TestCase("L00", true)]
        [TestCase("B00", true)]
        [TestCase("B01", true)]
        [TestCase("F", true)]
        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase("null", false)]
        public void TestLevelNameValidator(string name, bool expectedIsValid)
        {
            Assert.AreEqual(Level.IsValidName(name), expectedIsValid);
        }
    }
}