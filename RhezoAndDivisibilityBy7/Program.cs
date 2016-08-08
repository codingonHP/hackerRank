using System;

namespace RhezoAndDivisibilityBy7
{
    public class Program
    {
        static void Main(string[] args)
        {
            var number = Convert.ToInt32(Console.ReadLine());
            var q = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < q; i++)
            {
                var input = Console.ReadLine();
                var s = input.Split(' ');
                var l = Convert.ToInt32(s[0]);
                var r = Convert.ToInt32(s[1]);

                string output = DivisibleBy7(l, r, number);
                Console.WriteLine(output);
            }
        }

        public static string DivisibleBy7(long l, long r, long number)
        {
            double finalNumber = 0;
            double k = 1;
            double digit = 1;

            while (k <= r)
            {
                digit = number % 10;
                number = number / 10;
               
                if (k == l)
                {
                    finalNumber = digit;
                }
                else
                {
                    finalNumber = digit + finalNumber * 10;
                }
                ++k;
            }

            return finalNumber % 7 == 0 ? "YES" : "NO";
        }
    }
}
