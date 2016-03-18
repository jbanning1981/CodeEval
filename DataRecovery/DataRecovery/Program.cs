using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRecovery
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

                    string[] inputs = line.Split(';');

                    string[] wordsToSort = inputs[0].Split(' ');
                    string[] inputOrder = inputs[1].Split(' ');

                    string[] output = new string[wordsToSort.Length];

                    var missingInt = -1;
                    for (int i = 0; i <= inputOrder.Length - 1; i++)
                    {
                        //Check to see if this is the missing number
                        var missing = (i + 1).ToString();
                        if (!inputOrder.Contains(missing)) missingInt = Int16.Parse(missing) - 1;

                        int correctIndex = int.Parse(inputOrder[i]) - 1;
                        string word = wordsToSort[i];
                        output[correctIndex] = word;
                        wordsToSort[i] = String.Empty;
                    }

                    if (missingInt > -1)
                    {
                        var missingWord = wordsToSort.First(s => s != String.Empty);
                        output[missingInt] = missingWord;
                    }

                    var result = String.Join(" ", output.ToArray());                     

                    Console.WriteLine(result);
                }
                Console.ReadLine();
            }
        }
    }
}
