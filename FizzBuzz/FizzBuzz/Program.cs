/*Sample code to read in test cases:*/
using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        using (StreamReader reader = File.OpenText(args[0]))
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                    continue;

                int divisor1 = int.Parse(line.Split(' ')[0]);
                int divisor2 = int.Parse(line.Split(' ')[1]);
                int numberlist = int.Parse(line.Split(' ')[2]);

                bool isDivisorOneValid = ( divisor1 > 0 && divisor1 <= 20);
                bool isDivisorTwoValid = ( divisor2 > 0 && divisor2 <= 20);
                bool isNumberListValid = ( numberlist >= 21 && numberlist <= 100);
                
                string outputLine = string.Empty;

                if (isDivisorOneValid && isDivisorTwoValid && isNumberListValid)
                {
                    string loopOutput = string.Empty;

                    for(int i = 1; i <= numberlist; i++)
                    {

                        bool isFizz = (i % divisor1 == 0);
                        bool isBuzz = (i % divisor2 == 0);

                        if (i > 1) { loopOutput += " "; };


                        if(isFizz) { loopOutput += "F"; };
                        if(isBuzz) { loopOutput += "B"; };
                        if (!(isFizz || isBuzz)) { loopOutput += i.ToString(); };
                    }
                    outputLine += loopOutput;
                }
                else
                {
                    outputLine = "Error: invalid input";
                }
                Console.WriteLine(outputLine);
            }
    }
}