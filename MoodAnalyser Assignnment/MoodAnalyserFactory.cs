using System;
using System.Collections.Generic;
using System.Text;
using MoodAnalyser;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MoodAnalyser
{
    public class MoodAnalyserFactory
    {
       
        public static object CreateMoodAnalyse(string className, string constructor,string message)
        {
            Type type = typeof(MoodAnalyse);

            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructor))
                {
                    return Activator.CreateInstance(type, message);
                }
                else
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.TypeOfException.NO_SUCH_METHOD, "No such constructor found");
                }

            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.TypeOfException.NO_SUCH_CLASS, "No such class found");
            }
        }
        public static Object InvokeAnalyserMethod(string className,string constructor,string message, string methodName)
        {
            //Get the instance of the MoodAnalyserClass and create a constructor
            object moodAnalysis = CreateMoodAnalyse(className, constructor, message);
            Type type = typeof(MoodAnalyse);
            try
            {
                //Fetching the method info using reflection
                MethodInfo methodInfo = type.GetMethod(methodName);
                //Invoking the method of Mood Analyser Class
                Object obj = methodInfo.Invoke(moodAnalysis, null);
                return obj;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.TypeOfException.NO_SUCH_METHOD, "method not found");
            }
           
        }

       
    }
}
