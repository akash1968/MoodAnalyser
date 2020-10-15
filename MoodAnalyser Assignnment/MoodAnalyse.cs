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
            this.message = null;
            Console.WriteLine("default constructor");
        }
        public string AnalyserMethod()
        {
            try
            {
                if (!String.IsNullOrEmpty(message))
                {
                    if (message.ToUpper().Contains("SAD"))
                        return "SAD";
                    else if (message.ToUpper().Contains("HAPPY") || message.ToUpper().Contains("ANY"))
                        return "HAPPY";
                    else
                        return "HAPPY";
                }
                else if (this.message.Equals(string.Empty))
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.TypeOfException.EMPTY_MESSAGE, "mood should not be empty");
                }
                else
                    throw new NullReferenceException();

            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.TypeOfException.NULL_MESSAGE, "Mood Should not be NULL");
            }         
        }

    }
}
