using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;
namespace MoodAnalyserMSTest
{
    [TestClass]
    public class UnitTest1
    {
        MoodAnalyser.MoodAnalyse analyser = null;
        [TestInitialize]
        public void SetUp()
        {
            analyser = new MoodAnalyser.MoodAnalyse("I am in sad mood");
        }
        [TestMethod]
        public void TestMethod1()
        {
            //Act
            var actual = analyser.AnalyserMethod();
            //Assert
            Assert.AreEqual("sad", actual);

        }
    }
}
