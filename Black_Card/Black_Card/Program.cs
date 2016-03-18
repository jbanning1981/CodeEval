using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Black_Card
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
                    string result = String.Empty;
                    List<string> players = new List<string>();
                    int selected = -1;

                    if (IsValidInput(line, out players, out selected, out result))
                    {
                        result = FindWinner(players, selected);
                    }
                    
                    Console.WriteLine(result);
                }
            }

            Console.ReadLine(); //Remove before submitting.

        }

        public static bool IsValidInput(string line, out List<string> players, out int selected, out string result)
        {
            result = String.Empty;
            players = new List<string>();
            var lineParts = line.Split('|');

            if (lineParts.Count() != 2)
            { 
                result = "Invalid format.";
            }

            var tempPlayers = lineParts[0].Split(' ').ToList();

            foreach(string player in tempPlayers)
            {
                if (!String.IsNullOrWhiteSpace(player))
                {
                    players.Add(player);
                }
            }

            if (players.Count() < 3 || players.Count() > 10)
            {
                result = "Invalid player count. Player Number can be from 3 to 10";
            }

            if (!Int32.TryParse(lineParts[1].Trim(), out selected) || selected < 1)
            {
                result = "Invalid number.";
            }

            return result == String.Empty;
        }

        public static string FindWinner(List<string> players, int spotNumber)
        {
            int playerCount = 0;
            
            if (players != null)
            {
                playerCount = players.Count();
            }
          
            if (playerCount == 0)
            {
                return "No Winner.";
            }
            else if (playerCount == 1)
            {
                return players[0];
            }
            else
            {
                int removed = -1;

                if (spotNumber <= playerCount)
                {
                    removed = (playerCount - 1);
                }
                else
                {
                    if(spotNumber % playerCount == 0)
                    {
                        removed = playerCount - 1;
                    }
                    else
                    {
                        removed = (spotNumber % playerCount) - 1;
                    }
                }

                players.RemoveAt(removed);

                return FindWinner(players, spotNumber);
            }
        }



    }
}
