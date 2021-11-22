using System;

namespace Test2
{
    class Program
    {
        private static readonly int DaysInWeek = 7;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter date or 0 to exit:");

            string inputDateString = Console.ReadLine();
            DateTime findDate = new DateTime();

            while (inputDateString != "0")
            {
                DateTime inputDate;

                if (DateTime.TryParse(inputDateString, out inputDate))
                {
                    var minDistanceToWednesday = MinDOWDistance(inputDate.DayOfWeek, DayOfWeek.Wednesday);

                    findDate = inputDate.AddDays(minDistanceToWednesday);

                    Console.WriteLine(!isEvenDay(findDate)
                        ? findDate.AddDays(minDistanceToWednesday == 0 
                                            ? DaysInWeek
                                            : -Math.Sign(minDistanceToWednesday) * DaysInWeek)
                        : findDate);
                }
                inputDateString = Console.ReadLine();
            }
        }

        public static bool isEvenDay(DateTime date)
        {
            return date.Day % 2 == 0;
        }

        public static int MinDOWDistance(DayOfWeek dow1, DayOfWeek dow2)
        {
            int DaysDistance(int dow1, int dow2) => dow2 - dow1 + ((dow1 > dow2) ? 7 : 0);

            int fwd = DaysDistance((int)dow1, (int)dow2);
            int bck = DaysDistance((int)dow2, (int)dow1);

            return fwd < bck ? fwd : -bck;
        }
    }
}
