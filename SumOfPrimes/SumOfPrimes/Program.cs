using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            int counter = 0;
            int num = 2;
            while (counter < 1000)
            {
                if (IsPrime(num))
                {

                    result += num;
                    counter++;
                }
                num++;
            }
            Console.WriteLine(result);
        }

        static bool IsPrime(int numToCheck)
        {
            if (numToCheck > 3)
            {
                for (int i = 2; i <= (numToCheck / 2); i++)
                {
                    if (numToCheck % i == 0 || numToCheck == 4)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
