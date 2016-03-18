using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimePalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 1000; i>0;i--)
            {
                var reverse = ReverseText(i.ToString());
                if (i.ToString() == reverse)
                {
                    if (IsPrime(i))
                    {
                        Console.WriteLine(i);
                        break;
                    }
                }
            }
            Console.ReadLine();
        }

        static bool IsPrime(int numToCheck)
        {
            for (int i = 2; i < (numToCheck / 2); i++)
            {
                if (numToCheck % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static string ReverseText(string text)
        {
            return new string(text.Reverse().ToArray());
        }
    }
}
