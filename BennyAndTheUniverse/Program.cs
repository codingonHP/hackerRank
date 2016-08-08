using System;
using System.Diagnostics;
using System.Linq;


namespace BennyAndTheUniverse
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var userInput = Console.ReadLine().Split(' ');
                var n = Convert.ToInt32(userInput[0]);
                var q = Convert.ToInt32(userInput[1]);
                var s = Console.ReadLine();
                int[] queries = new int[q];

                for (int i = 0; i < q; i++)
                {
                    queries[i] = Convert.ToInt32(Console.ReadLine());
                }

                Run(n, queries, s);
            }
            catch (Exception)
            {
            }
        }

        public static void Run(int n, int[] q, string s)
        {
          
            int[] spaceShips = new int[n];
            int i = -1;
            foreach (var spaceships in s.Split(' ').Where(x => x != ""))
            {
                spaceShips[++i] = Convert.ToInt32(spaceships);
            }

            spaceShips = spaceShips.OrderBy(t => t).ToArray();
            for (int j = 0; j < q.Length; j++)
            {
                string canGo = CanVisit(spaceShips, q[j]);
                Console.WriteLine(canGo);
                Debug.WriteLine(canGo);
            }
        }

        public static string CanVisit( int[] spaceShips, int toPlanet )
        {
            string output = "NO";

            for (int i = 0; i < spaceShips.Length; i++)
            {
                var result = Traverse(spaceShips[i], toPlanet, spaceShips,0);
                if (result)
                {
                    output = "YES";
                    break;
                }
            }

            return output;
        }

        private static bool Traverse(int root, int toPlanet, int[] spaceShips, int index )
        {
            if (root == toPlanet)
            {
                Debug.WriteLine(root + " :TRUE, for " + toPlanet );
                return true;
            }
                
            var next = root + spaceShips[index];
            if (next == toPlanet)
            {
                Debug.WriteLine(root);
                return true;
            }
            if (next < toPlanet)
            {
                var output =  Traverse(next, toPlanet, spaceShips, 0);
                if (output)
                {
                    return true;
                }
            }

            if (index + 1 == spaceShips.Length)
            {
                return false;
            }

            if (root + spaceShips[index + 1] <= toPlanet)
            {
               return  Traverse(root, toPlanet, spaceShips, index + 1);
            }

            return false;
        }

      
    }
}
