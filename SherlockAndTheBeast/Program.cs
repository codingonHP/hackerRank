using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherlockAndTheBeast
{
    /*
     Sherlock Holmes suspects his archenemy, Professor Moriarty, is once again plotting something diabolical. Sherlock's companion, Dr. Watson, suggests Moriarty may be responsible for MI6's recent issues with their supercomputer, The Beast.

    Shortly after resolving to investigate, Sherlock receives a note from Moriarty boasting about infecting The Beast with a virus; however, he also gives him a clue—a number, . Sherlock determines the key to removing the virus is to find the largest Decent Number having  digits.

    A Decent Number has the following properties:

    Its digits can only be 3's and/or 5's.
    The number of 3's it contains is divisible by 5.
    The number of 5's it contains is divisible by 3.
    If there are more than one such number, we pick the largest one.
    Moriarty's virus shows a clock counting down to The Beast's destruction, and time is running out fast. Your task is to help Sherlock find the key before The Beast is destroyed!
         */
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listOf5 = new List<string>();
            List<string> listOf3 = new List<string>();

            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                var threeParts = n/3;
                var fiveParts = n/5;

                for (int i = 1; i <= threeParts; i++)
                {
                    listOf5.Add((i*3).ToString());
                }

                for (int i = 1; i <= fiveParts; i++)
                {
                    listOf3.Add((i * 5).ToString());
                }

                string answer = "-1";
                if (listOf5.Any())
                {
                    foreach (var l5 in listOf5)
                    {
                        if (listOf3.Any())
                        {
                            foreach (var l3 in listOf3)
                            {
                                if (Convert.ToInt32(l3) + Convert.ToInt32(l5) == n)
                                {
                                    answer = l5 + ":" + l3;
                                }
                            }
                        }
                        else
                        {
                            answer = listOf5.Last();
                            break;
                        }
                    }
                }
                else if (listOf3.Any())
                {
                    answer = listOf3.Last();
                }

                if (answer == "-1" && (listOf5.Any() || listOf3.Any()))
                {
                    var last5 = listOf5.LastOrDefault();
                    var last3 = listOf3.LastOrDefault();

                    if (last5 != null && last3 != null)
                    {
                        answer = Convert.ToInt32(last5) >= Convert.ToInt32(last3) ? (last5 + ":" + 0) : (0 + ":" +last3);
                    }
                    else if (last3 == null)
                    {
                        answer = (last5 + ":" + 0);
                    }
                    else
                    {
                        answer = (0 + ":" + last3);
                    }
                }

                Console.WriteLine(FormatOutput(answer));
            }

        }

        private static string FormatOutput(string input)
        {
            var answer = string.Empty;
            if (input == "-1")
            {
                return input;
            }

            var parts = input.Split(':');
            for (int i = 0; i < Convert.ToInt32(parts[0]); i++)
            {
                answer += "5";
            }

            if (parts.Length > 1)
            {
                for (int i = 0; i < Convert.ToInt32(parts[1]); i++)
                {
                    answer += "3";
                }
            }

            return answer;
        }
    }
}
