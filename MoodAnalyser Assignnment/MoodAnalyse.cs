using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Text;

namespace MoodAnalyser
{
   public class MoodAnalyse
    {
        private string message;
        
       
        public MoodAnalyse(string message)
        {
            this.message = message;
            Console.WriteLine("parameterised constructor");
            Console.WriteLine(message);
        }
        public MoodAnalyse()
        {
            Console.WriteLine("default constructor");
        }
        public string AnalyserMethod()
        {
            try
            {
                if (this.message.Equals(string.Empty))
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.TypeOfException.EMPTY_MESSAGE, "mood should not be empty");
                else if (this.message.Contains("sad"))
                    return "SAD";
                else
                    return "HAPPY";
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.TypeOfException.NULL_MESSAGE, "Mood Should not be NULL");
            }
        }

    }
}
