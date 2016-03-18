using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumFromFile
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    result += Int16.Parse(line);
                }
            Console.WriteLine(result);
        }
    }
}
