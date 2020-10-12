using System;

namespace MoodAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            MoodAnalyse analyser = new MoodAnalyse("I am in sad mood");
            Console.WriteLine(analyser.AnalyserMethod());
        }
    }
}
