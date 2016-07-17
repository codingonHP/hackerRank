using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinuAndCoins
{
    /*
        https://www.hackerearth.com/july-circuits/algorithm/little-shino-and-coins-3/  
   */

    class Node
    {
        public char Key { get; set; }
        public List<char> Holder { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            //SolveByIteration();

            SolveBySingleTraveling();

        }

        private static void SolveBySingleTraveling()
        {
            List<Node> holder = new List<Node>();
            int output = 0, temp = 0;

            var k = Convert.ToInt32(Console.ReadLine());
            var input = Console.ReadLine();

            if (k <= 0 || k > input.Length)
            {
                Console.WriteLine(output);
                return;
            }

            if (k == input.Length)
            {
                temp = input.Distinct().Count() == input.Length ? output = 1 : output = 0;
                Console.WriteLine(output);
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                foreach (var node in holder)
                {
                    if (node.Holder.Count > 0)
                    {
                        if (!node.Holder.Contains(input[i]))
                        {
                            node.Holder.Add(input[i]);
                        }

                        if (node.Holder.Count == k)
                        {
                            ++output;
                        }
                    }
                }


                holder.Add(new Node { Key = input[i], Holder = new List<char> { input[i] } });
                if (k == 1)
                {
                    ++output;
                }

            }

            Console.WriteLine(output);
        }

        private static void SolveByIteration()
        {
            int k = 0, output = 0, temp;
            bool alldistinct = false;
            string input;
            try
            {

                k = Convert.ToInt32(Console.ReadLine().Trim());
                input = Console.ReadLine().Trim();
                if (k <= 0 || k > input.Length)
                {
                    Console.WriteLine(output);
                    return;
                }

                if (k == input.Length)
                {
                    temp = input.Distinct().Count() == input.Length ? output = 1 : output = 0;
                    Console.WriteLine(output);
                    return;
                }

                if (input.Distinct().Count() == input.Length)
                {
                    alldistinct = true;
                }

                var subStr = "";
                bool stop = true;
                for (int i = 1; i <= input.Length; i++)
                {
                    stop = true;
                    for (int j = i + k - 1; i <= j && j <= input.Length; j++)
                    {
                        stop = false;
                        if (i + k - 1 <= input.Length)
                        {
                            subStr = SubString(input, i - 1, j);
                            if (alldistinct && subStr.Length > k)
                            {
                                break;
                            }
                            temp = subStr.Distinct().Count() == k ? ++output : -1;
                        }
                    }

                    if (stop)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Console.WriteLine(output);
        }

        private static string SubString(string @string, int startIndex, int endIndex)
        {
            string subStr = "";
            for (int i = startIndex; i < endIndex; i++)
            {
                subStr += @string[i];
            }
            return subStr;
        }
    }
}
