using System;
using System.Linq;

namespace Test
{
    class PhoneNumberChecker 
    {
        private readonly long minValue = 9000000000;
        private readonly long maxValue = 9999870000;
        string strNumber;

        public PhoneNumberChecker(string strNumber)
        {
            this.strNumber = strNumber;
        }

        public bool TryValidate(out int count)
        {
            long numberLoc = 0;
            count = -1;

            if (isNumber(strNumber, ref numberLoc) && isNumberInRange(numberLoc))
            {
                count = strNumber.GroupBy(x => x)
                                    .Where(c => c.Count() == 2)
                                        .Count();
            }

            return count == 0;
        }

        private bool isNumberInRange(long number)
        {
            return number <= this.maxValue && number >= this.minValue;
        }

        private bool isNumber(string stringNumber, ref long number)
        {
            return long.TryParse(stringNumber, out number);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter phone number or 0 to exit:");
            string inputNumber = Console.ReadLine();
            while (inputNumber != "0")
            {
                PhoneNumberChecker PNChecker = new PhoneNumberChecker(inputNumber);
                
                bool isValidNumber = PNChecker.TryValidate(out int countError);

                OutputResult(inputNumber, isValidNumber, countError);
                inputNumber = Console.ReadLine();
            }
        }

        private static void OutputResult(string inputNumber, bool isValidNumber, int countError)
        {                
            string output = (countError > 0) ? $"{inputNumber} - {isValidNumber}, {countError}"
                                                : $"{inputNumber} - {isValidNumber}";

            Console.WriteLine(output);
        }
    }
}
