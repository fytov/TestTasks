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

                Console.WriteLine($"{intValue} => {ProcessValue(intValue)}");
                Console.WriteLine($"{strValue} => {ProcessValue(strValue)}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);    
            }           
        }

        static string ProcessValue(string value)
        {
            return new string(value.ToCharArray().Reverse().ToArray());
        }

        static int ProcessValue(int value)
        {
            var sum = 0;

            while (value != 0)
            {
                sum += value % 10;
                value /= 10;
            }

            return sum;
        }
    }
}
