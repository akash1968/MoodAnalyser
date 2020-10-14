using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;
using System.Reflection;
namespace MoodAnalyserMSTest
{
    [TestClass]
    public class UnitTest1
    {
        //GivenSadMoodShouldReturnSad
        [TestMethod]
        [DataRow("I am in a sad mood")]
        public void TestMethod1(string message)
        {
            //arrange
            string expected = "SAD";
            MoodAnalyse mood = new MoodAnalyse(message);
            //Act
            string actual = mood.AnalyserMethod();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        //GivenAnyMoodShouldReturnHappy
        [TestMethod]
        [DataRow("I am in any mood")]
        public void TestMethod2(string message)
        {
            //arrange
            string expected = "HAPPY";
            MoodAnalyse mood = new MoodAnalyse(message);
            //Act
            string actual = mood.AnalyserMethod();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        //Given_Empty_Mood_Should_Throw_MoodAnalysisCustomException_IndicatingEmptyMood
        [TestMethod]
        public void TestMethod3()
        {
            try
            {
                string message = " ";
                MoodAnalyse mood = new MoodAnalyse(message);
            }

           catch (MoodAnalyserCustomException exception)
            {
                Assert.AreEqual("Mood Should not be empty", exception.Message);
            }
        }
        //Given_Null_Mood_Should_Throw_MoodAnalysisCustomException_IndicatingNullMood
        [TestMethod]
        public void TestMethod4()
        {
            try
            {
                string message = null;
                MoodAnalyse mood = new MoodAnalyse(message);
                string actual = mood.AnalyserMethod();
            }

            catch (MoodAnalyserCustomException exception)
            {
                Assert.AreEqual("Mood Should not be NULL", exception.Message);
            }
        }
        //GivenMoodAnalyserClass_ShouldReturn_MoodAnalyserObject
        [TestMethod]
        public void TestMethod5()
        {
           
                string message = null;
            object expected = new MoodAnalyse(message);
            object obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyser.MoodAnalyse", "MoodAnalyse");
            obj.Equals(expected);

        }
        //TC_5.1 - Given MoodAnalyser when proper message pass to Parameterized constructor then return mood analyser object
        [TestMethod]
        public void TestMethod6()
        {

            string message = "HAPPY";
            object expected = new MoodAnalyse(message);
            object obj = MoodAnalyserFactory.CreateMoodAnalyseWithParametrizedConstructor("MoodAnalyser.MoodAnalyse", "MoodAnalyse");
            obj.Equals(expected);

        }
    }
}
