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
        public void GivenSadMoodShouldReturnSad(string message)
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
        public void GivenAnyMoodShouldReturnHappy(string message)
        {
            //arrange
            string expected = "HAPPY";
            MoodAnalyse mood = new MoodAnalyse(message);
            //Act
            string actual = mood.AnalyserMethod();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        // Given_Empty_Mood_Should_Throw_MoodAnalysisCustomException_IndicatingEmptyMood
        [TestMethod]
        public void Given_Empty_Mood_Should_Throw_MoodAnalysisCustomException_IndicatingEmptyMood()
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
        // Given_Null_Mood_Should_Throw_MoodAnalysisCustomException_IndicatingNullMood
        [TestMethod]
        public void Given_Null_Mood_Should_Throw_MoodAnalysisCustomException_IndicatingNullMood()
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
        public void GivenMoodAnalyserClass_ShouldReturn_MoodAnalyserObject()
        {

            string message = null;
            object expected = new MoodAnalyse(message);
            object obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyser.MoodAnalyse", "MoodAnalyse", null);
            obj.Equals(expected);

        }
        //Test Case 4.1 to match both class name and constructor name
        [TestMethod]
        public void CreateObjectOfMoodAnalyserClass()
        {
            //Arrange
            MoodAnalyse mood = new MoodAnalyse();
            //Act
            var objectFromFactory = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyser.MoodAnalyse", "MoodAnalyse", null);
            //Assert
            objectFromFactory.Equals(mood);

        }
        //Test Case 4.2 To return exception when wrong class name is passed
        [TestMethod]
        public void CreateObjectOfMoodAnalyserClassWithWrongClassName()
        {
            //Arrange
            MoodAnalyse mood = new MoodAnalyse();
            //Act
            try
            {
                var objectFromFactory = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyser.MoodAnalyseWrong", "MoodAnalyse", null);
            }
            //Assert
            catch (MoodAnalyserCustomException exception)
            {
                Assert.AreEqual("No such class found", exception.Message);
            }

        }
        //Test Case 4.3 To return exception for wrong constructor name
        [TestMethod]
        public void CreateObjectOfMoodAnalyserClassWithWrongConstructor()
        {
            //Arrange
            MoodAnalyse mood = new MoodAnalyse();
            //Act
            try
            {
                var objectFromFactory = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyser.MoodAnalyse", "MoodAnalyseWrong", null);
            }
            //Assert
            catch (MoodAnalyserCustomException exception)
            {
                Assert.AreEqual("No such constructor found", exception.Message);
            }

        }
       
        //TC_5.1 - Given MoodAnalyser when proper message pass to Parameterized constructor then return mood analyser object
        [TestMethod]
        public void CreateParameterizedObjectOfMoodAnalyserClass()
        {
            //Arrange

            MoodAnalyse mood = new MoodAnalyse();
            //Act
            var obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyser.MoodAnalyse", "MoodAnalyse","HAPPY");
          //Assert
            obj.Equals(mood);

        }
        //TC 5.2 When a wrong class name is passed then throw exception
        [TestMethod]
        public void CreateParameterizedObjectOfMoodAnalyseInvalidClassName()
        {
            //Arrange
            MoodAnalyse mood = new MoodAnalyse();

            //Act
            try
            {
                var obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyser.MoodAnalyseWrong", "MoodAnalyse", "HAPPY");
            }
                //Assert
            catch (MoodAnalyserCustomException exception)
            {
                Assert.AreEqual("No such class found", exception.Message);
            }

        }
        //TC 5.3 When a wrong costructor name is passed then throw an exception
        [TestMethod]
        public void CreateParameterizedObjectOfMoodAnalyseInvalidConstructor()
        {
            //Arrange
            MoodAnalyse mood = new MoodAnalyse();
           
            //Act
            try
            {
                var obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyser.MoodAnalyse", "MoodAnalyseWrong", "HAPPY");
            }
            //Assert
            catch (MoodAnalyserCustomException exception)
            {
                Assert.AreEqual("No such constructor found", exception.Message);
            }

        }
        [TestMethod]
        //UC 6.1 : Given 'Happy' message when proper should return 'Happy Mood'.
       
        public void GivenHappyMessage_InvokeAnalyseMoodMethod_ShouldReturnHappyMoodMessage()
        {
            //arrange
            MoodAnalyse mood = new MoodAnalyse("I am in happy mood");

            //Act
            object actual = MoodAnalyserFactory.InvokeAnalyserMethod("MoodAnalyser.MoodAnalyse", "MoodAnalyse", "i am in happy mood", "AnalyserMethod"); 
            //Assert
            Assert.AreEqual("HAPPY", actual);
        }
        [TestMethod]
        
        //UC 6.2 : Given Improper method name must return mood analyser custom exception
        public void GivenHappyMessage_WhenImproperMethod_ShouldThrowMoodAnalysisException()
        {
            //Act
            try
            {
                MoodAnalyse mood = new MoodAnalyse("I am in happy mood");
                object expected = mood.AnalyserMethod();
                object actual= MoodAnalyserFactory.InvokeAnalyserMethod("MoodAnalyser.MoodAnalyse", "MoodAnalyse", "i am in happy mood", "InvalidMethod");
            }
            catch (MoodAnalyserCustomException exception)
            {
                //Assert
                Assert.AreEqual("method not found", exception.Message);
            }
        }
    }
}
