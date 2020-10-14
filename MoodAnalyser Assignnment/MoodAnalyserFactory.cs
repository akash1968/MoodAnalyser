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
        public static object CreateMoodAnalyse(string ClassName, string ConstructorName,string message)
        {
            string pattern = @"." + ConstructorName + "$";
            var result = Regex.Match(ClassName, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = assembly.GetType(ClassName);
                    return Activator.CreateInstance(moodAnalyserType);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.TypeOfException.NO_SUCH_CLASS, "no such class is found");
                }
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.TypeOfException.NO_SUCH_CONSTRUCTOR, "no such constructor found");
            }
        }
        public static object CreateMoodAnalyseWithParametrizedConstructor(string className, string constructor,string message)
        {
            Type type = typeof(MoodAnalyse);

            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructor))
                {
                    ConstructorInfo cons = type.GetConstructor(new[] { typeof(string) });
                    object instance = cons.Invoke(new object[] { "HAPPY" });
                    return instance;
                }
                else
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.TypeOfException.NO_SUCH_METHOD, "Constructor not found");
                }

            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.TypeOfException.NO_SUCH_CLASS, "Class not found");
            }
        }
        public static string InvokeAnalyserMethod(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyser.MoodAnalyse");
                object moodAnalyserObject = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyser.MoodAnalyse", "MoodAnalyse", message);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object info = methodInfo.Invoke(moodAnalyserObject, null);
                return info.ToString();
            }

            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.TypeOfException.NO_SUCH_METHOD, "no such method is found");

            }
        }

       
    }
}
