using System;
using System.Linq;

namespace Test4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int intValue = 53483;
                string strValue = "Test string";
                double doubleValue = 10.0;

                Console.WriteLine($"{intValue} => {ProcessValue(intValue)}");
                Console.WriteLine($"{strValue} => {ProcessValue(strValue)}");
                Console.WriteLine($"{doubleValue} => {ProcessValue(doubleValue)}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);    
            }           
        }

        static object ProcessValue(object value)
        {
            if (value is String valueStr)
            {
                return GetInversionString(valueStr);
            }
            else if (value is int valueInt)
            {
                return GetSum(valueInt);
            }
            else
            {
                throw new ArgumentException("Please pass the correct value. Available types: int, string");
            }
        }

        private static int GetSum(int valueInt)
        {
            var sum = 0;

            while (valueInt != 0)
            {
                sum += valueInt % 10;
                valueInt /= 10;
            }

            return sum;
        }

        private static string GetInversionString(string valueStr)
        {
            return new string(valueStr.ToCharArray().Reverse().ToArray());
        }
    }
}
