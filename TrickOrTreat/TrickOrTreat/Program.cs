using System;
using System.Collections.Generic;
using System.IO;

namespace TrickOrTreat
{
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
                    var inputs = line.Split(',');

                    var vampires = GetCount(inputs[0]);
                    var zombies = GetCount(inputs[1]);
                    var witches = GetCount(inputs[2]);
                    var houses = GetCount(inputs[3]);

                    var totalPieces = GetCandyTotal(vampires, zombies, witches, houses);
                    var avgCandyPerKid = totalPieces / (vampires + zombies + witches);

                    Console.WriteLine(avgCandyPerKid);
                }
        }

        static int GetCount(string inputSection)
        {
            return Int16.Parse(inputSection.Split(':')[1].Trim());
        }

        static int GetCandyTotal(int vampires, int zombies, int witches, int houses)
        {
            return houses * ((3 * vampires) + (4 * zombies) + (5 * witches));
        }




    }
}
