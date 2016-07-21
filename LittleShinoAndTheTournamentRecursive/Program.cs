using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleShinoAndTheTournamentRecursive
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Console.ReadLine().Split(' ');
            var n = Convert.ToInt32(read[0]);
            var q = Convert.ToInt32(read[1]);

            int[] strengths = new int[n];
            int[] queries = new int[q];
            int[] participationCountArry = new int[n];

            ReadInStrength(strengths, n);
            ReadInQueries(queries, q);

            Container(strengths, participationCountArry);

            PrintResult(participationCountArry, queries);
        }

        public static void Container(int[] strength, int [] participationCountArry)
        {
            Fight(0, strength.Length / 2, strength, participationCountArry);
            Fight(strength.Length / 2 + 1, strength.Length - 1, strength, participationCountArry);

            // Fight(0, strength.Length - 1, strength, participationCountArry);
        }

        public static int Fight(int start, int end, int [] strength, int[] participationCountArry)
        {
            var max = -1;

            
            if (end - start == 1)
            {
                max = strength[start] > strength[end] ? start : end;
                participationCountArry[end]++;
                participationCountArry[start]++;
                return max;
            }

            if (start == end || end < start)
            {
                return start;
            }

            var m0 = Fight(start, end / 2, strength, participationCountArry);
            var m1 = Fight(end / 2 + 1 , end , strength, participationCountArry);

            participationCountArry[m0]++;
            participationCountArry[m1]++;

            return strength[m0] > strength[m1] ? m0 : m1;

        }

        private static void ReadInStrength(int[] arry, int len)
        {
            var array = Console.ReadLine().Split(' ');
            for (int i = 0; i < array.Length; i++)
            {
                arry[i] = Convert.ToInt32(array[i]);
                
            }
        }

        private static void ReadInQueries(int[] arry, int len)
        {
            for (int i = 0; i < len; i++)
            {
                arry[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        private static void PrintResult(int[] resultArry, int[] queries)
        {
            for (int i = 0; i < queries.Length; i++)
            {
                Console.WriteLine(resultArry[queries[i] - 1]);
            }
        }
    }
}
