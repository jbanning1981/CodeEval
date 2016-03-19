using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplication_Tables
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = BuildTable(12, 12);

            foreach(string row in table)
            {
                Console.WriteLine(row);
            }

            Console.ReadLine();
        }

        static List<string> BuildTable(int rows, int columns)
        {
            var table = new List<string>();

            for (int row = 1; row <= rows; row++)
            {
                string line = String.Empty;
                int padLength = 4;
                for (int col = 1; col <= columns; col++)
                {
                    string value = (row * col).ToString();
                    if (col == 1)
                    {
                        line = value.PadLeft(2);
                    }
                    else
                    {
                        line += value.PadLeft(padLength);
                    }
                }
                table.Add(line);
            }

            return table;
        }
    }
}
