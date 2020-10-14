using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;
using System.Reflection;
namespace MoodAnalyserMSTest
{
    [TestClass]
    public class UnitTest1
    {
        //UC 1.1: GivenSadMoodShouldReturnSad
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
        //UC 1.2: GivenAnyMoodShouldReturnHappy
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
        //UC 3.2: Given_Empty_Mood_Should_Throw_MoodAnalysisCustomException_IndicatingEmptyMood
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
        //UC 3.1: Given_Null_Mood_Should_Throw_MoodAnalysisCustomException_IndicatingNullMood
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
            object obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyser.MoodAnalyse", "MoodAnalyse",null);
            obj.Equals(expected);

        }
        //TC_5.1 - Given MoodAnalyser when proper message pass to Parameterized constructor then return mood analyser object
        [TestMethod]
        public void TestMethod6()
        {

            string message = "HAPPY";
            object expected = new MoodAnalyse(message);
            object obj = MoodAnalyserFactory.CreateMoodAnalyseWithParametrizedConstructor("MoodAnalyser.MoodAnalyse", "MoodAnalyse","HAPPY");
            obj.Equals(expected);

        }
        [TestMethod]
        //UC 6.1 : Given 'Happy' message when proper should return 'Happy Mood'.
        //GivenHappyMessage_InvokeAnalyseMoodMethod_ShouldReturnHappyMoodMessage
        public void TestMethod7()
        {
            //arrange
            string expected = "HAPPY Mood";
            
            //Act
            string actual = MoodAnalyserFactory.InvokeAnalyserMethod("Happy","MoodAnalyse");
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        //GivenHappyMessage_WhenImproperMethod_ShouldThrowMoodAnalysisException
        //UC 6.2 : Given Improper method name must return mood analyser custom exception
        public void TestMethod8()
        {
            try
            {
                //Act
                object result= MoodAnalyserFactory.InvokeAnalyserMethod("Happy", "MoodAnalyseDifferent");
            }
            catch (MoodAnalyserCustomException exception)
            {
                //Assert
                Assert.AreEqual("Exception: method not found", exception.Message);
            }
        }
    }
}
