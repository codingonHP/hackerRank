using System;
using System.Collections.Generic;

namespace ShinuAndFib
{
    public class ShinuFibonacci
    {
        static readonly long[] Cache = new long[94];
        static readonly Queue<long> FibListDictionary = new Queue<long>();
        static void Main(string[] args)
        {
            FillFib();

            var t = Convert.ToInt32(Console.ReadLine());
            var holder = new int[t,2];

            for (int i = 0; i < t; i++)
            {
                var line = Console.ReadLine();
                var l = Convert.ToInt32(line.Split(' ')[0]);
                var r = Convert.ToInt32(line.Split(' ')[1]);
                holder[i, 0] = l;
                holder[i, 1] = r;
            }

            for (int i = 0; i < t; i++)
            {
                //long sum = CalculateSum(holder[i,0], holder[i,1]);
                var sum = CacheSumCalc(holder[i, 0], holder[i, 1]);
                Console.WriteLine(sum);
            }
           
        }

        //(F(l)%10000+F(l+1)%10000+F(l+2)%10000+...+F(r)%10000) % (10**9+7)

        public static long CalculateSum(int l , int r)
        {
            long sum = 0, k = 0;
            for (long i = r; i >= l; i--)
            {
                ++k;

                long currFib = 0;
                if (k > 2)
                {
                    if (FibListDictionary.Count > 0 )
                    {
                        currFib = FibListDictionary.Dequeue() - FibListDictionary.Peek();
                        FibListDictionary.Enqueue(currFib);
                    }
                   
                }
                else
                {
                    currFib = Fib(i);
                    FibListDictionary.Enqueue(currFib);
                }
               
                sum += currFib % 10000;

                if (k == 4)
                {
                    break;
                }
            }

            return sum % 1000000007;
        }

        public static long CacheSumCalc(int l, int r)
        {
            long sum = 0, k = 0;
            for (long i = r; i >= l; i--)
            {
                ++k;

                long currFib = Cache[i];
                
                sum += currFib % 10000;

                if (k == 4)
                {
                    break;
                }
            }

            return sum % 1000000007;
        }

        static long Fib(long n)
        {
            if (n < 2) return n;
            if (n == 2) return 1;
            var k = n / 2;
            var a = Fib(k + 1);
            var b = Fib(k);
            if (n % 2 == 1)
                return a * a + b * b;
            else
                return b * (2 * a - b);
        }

        static void FillFib()
        {
            Cache[0] = 0;
            Cache[1] = 0;
            Cache[2] = 1;
            Cache[3] = 1;
             
            for (int i = 4; i < 94; i++)
            {
                Cache[i] = Cache[i - 1] + Cache[i - 2];
            }
        }
    }
}
