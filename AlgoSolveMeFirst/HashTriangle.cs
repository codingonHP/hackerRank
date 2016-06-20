using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoSolveMeFirst
{
    class HashTriangle
    {
        /*
         Consider a staircase of size :

           #
          ##
         ###
        ####
       #####
            Observe that its base and height are both equal to, 
            and the image is drawn using # symbols and spaces. 
            The last line is not preceded by any spaces.
            Write a program that prints a staircase of size.
       */

        static void Main(string[] args)
        {
            var cnt = Convert.ToInt32(Console.ReadLine());
            var message = string.Empty;
            for (int i = 1; i <= cnt; i++)
            {
                Console.WriteLine("{0,4}", message += "#");
            }
        }

        private static string CreateStep(int level, int height,  char pointer)
        {
            var tempLine = "\n";
            for (int i = 0; i < height; i++)
            {
                if (i < height-level-1)
                {
                    tempLine += " ";
                }
                else
                {
                    tempLine += pointer;
                }
            }

            return tempLine;
        }
    }
}
