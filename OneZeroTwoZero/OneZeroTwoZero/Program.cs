using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneZeroTwoZero
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;

                    var inputs = line.Split(' ');
                    var zeroSearchCount = Int16.Parse(inputs[0]);
                    var maxSearchNum = Int16.Parse(inputs[1]);
                    int matchCount = 0;

                    for(int i = 1; i<= maxSearchNum; i++)
                    {
                        string binary = Convert.ToString(i, 2);
                        var zeroCount = binary.Count(c => c == '0');
                        if (zeroCount == zeroSearchCount) matchCount++;
                    }

                    Console.WriteLine(matchCount);
                }
            }
        }
    }
}
