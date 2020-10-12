using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
   public class MoodAnalyse
    {
        private string message;
        public MoodAnalyse(string message)
        {
            this.message = message;
        }
        public string AnalyserMethod()
        {
            if (this.message.Contains("sad"))
                return "sad";
            else
                return "happy";
        }
    }
}
