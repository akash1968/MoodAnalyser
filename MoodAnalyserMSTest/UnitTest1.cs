using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;
namespace MoodAnalyserMSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            string expected = "SAD";
            string message = "I am SAD";
            MoodAnalyse mood = new MoodAnalyse(message);
            //Act
            string actual = mood.AnalyserMethod();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            //arrange
            string expected = "HAPPY";
            string message = "I am in any mood";
            MoodAnalyse mood = new MoodAnalyse(message);
            //Act
            string actual = mood.AnalyserMethod();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod3()
        {
            //arrange
            string expected = "SAD";
            string message = "I am in HAPPY mood";
            MoodAnalyse mood = new MoodAnalyse(message);
            //Act
            string actual = mood.AnalyserMethod();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod4()
        {
            //arrange
            string expected = "HAPPY";
            string message = null;
            MoodAnalyse mood = new MoodAnalyse(message);
            //Act
            string actual = mood.AnalyserMethod();
            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
