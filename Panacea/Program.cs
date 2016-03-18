using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panacea
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = args[0];

            using (StreamReader reader = File.OpenText(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (String.IsNullOrWhiteSpace(line))
                        continue;

                    string[] inputs = line.Split('|');

                    string[] hexValues = inputs[0].Split(' ');
                    string[] binaryValues = inputs[1].Split(' ');

                    int sumHex = 0;
                    foreach(string s in hexValues)
                    {
                        if(!String.IsNullOrWhiteSpace(s))
                        {
                            sumHex += Convert.ToInt32(s, 16); //Base 16
                        }
                    }

                    int sumBinary = 0;
                    foreach(string s in binaryValues)
                    {
                        if (!String.IsNullOrWhiteSpace(s))
                        {
                            sumBinary += Convert.ToInt32(s, 2); //Base 2
                        }
                    }

                    string result = (sumBinary >= sumHex).ToString();

                    Console.WriteLine(result);
                }
                Console.ReadLine();
            }

        }
    }
}
