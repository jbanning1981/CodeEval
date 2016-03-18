using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TimeToEat
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
                    var sortedTime = SortDates(line);
                    Console.WriteLine(sortedTime);
                }
            }
        }

        public static string SortDates(string input)
        {
            var times = new List<DateTime>();
            var outputList = new List<string>();
            var inputTimes = input.Split(' ');

            foreach(string time in inputTimes)
            {
                var fullTime = "1/1/1 " + time;
                var dt = new DateTime();
                if (DateTime.TryParse(fullTime, out dt))
                {
                    times.Add(dt);
                }
            }

            times.Sort();
            times.Reverse();

            foreach(DateTime dt in times)
            {
                outputList.Add(dt.ToString("HH:mm:ss"));
            }

            return String.Join(" ", outputList.ToArray());
        }
    }
}
