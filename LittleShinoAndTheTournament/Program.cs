using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleShinoAndTheTournament
{

    class Program
    {
        //https://www.hackerearth.com/july-circuits/algorithm/little-shino-and-the-tournament/

        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            var read = Console.ReadLine().Split(' ');
            var n = Convert.ToInt32(read[0]);
            var q = Convert.ToInt32(read[1]);

            int[] strengths = new int[n];
            int[] queries = new int[q];
            int[] participationCountArry = new int[n];

            ReadInArray(strengths, n, queue);
            ReadInLine(queries, q);

            Fight(strengths, participationCountArry, queue);

            PrintResult(participationCountArry, queries);

        }


        public static void Fight(int[] strengths, int[] participationCountArry, Queue<int> queue)
        {
            Queue<int> passed = new Queue<int>();

            int p1, p2 = -1;

            do
            {
                while (queue.Count > 0)
                {
                    p1 = queue.Dequeue();

                    if (queue.Count > 0)
                    {
                        p2 = queue.Dequeue();
                    }
                    else
                    {
                        p2 = -1;
                    }

                    int wonIndex = p2 > 0 && p2 < strengths.Length && strengths[p2] > strengths[p1] ? p2 : p1;
                    passed.Enqueue(wonIndex);

                    if (p2 > 0)
                    {
                        participationCountArry[p1]++;
                        participationCountArry[p2]++;
                    }

                }

                queue = passed;
                passed = new Queue<int>();

            } while (queue.Count != 1);

        }

        private static void ReadInArray(int[] arry, int len, Queue<int> queue)
        {
            var array = Console.ReadLine().Split(' ');
            for (int i = 0; i < array.Length; i++)
            {
                arry[i] = Convert.ToInt32(array[i]);
                queue.Enqueue(i);
            }
        }

        private static void ReadInLine(int[] arry, int len)
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
