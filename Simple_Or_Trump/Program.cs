using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Or_Trump
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = args[0];

            var deck = GetDeck();

            using (StreamReader reader = File.OpenText(fileName))
            {

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (String.IsNullOrWhiteSpace(line))
                        continue;

                    string[] inputs = line.Split('|');

                    string[] cards = inputs[0].Trim().Split(' ');
                    string trump = inputs[1].Trim();
                    string cardOne = cards[0];
                    string cardTwo = cards[1];

                    string winningCard = GetWinningCard(cardOne, cardTwo, trump, deck);

                    Console.WriteLine(winningCard);

                }
            }

            Console.ReadLine();
        }

        public static string GetWinningCard(string cardOne, string cardTwo, string trumpSuit, string[] deck)
        {
            var isOneTrump = cardOne.Contains(trumpSuit);
            var isTwoTrump = cardTwo.Contains(trumpSuit);

            if (isOneTrump && !isTwoTrump) return cardOne;
            if (isTwoTrump && !isOneTrump) return cardTwo;

            int cardOneValue = Array.FindIndex(deck, s => s == cardOne.Substring(0, cardOne.Length - 1).ToString());
            int cardTwoValue = Array.FindIndex(deck, s => s == cardTwo.Substring(0, cardTwo.Length - 1).ToString());

            string result = cardOne; //assume card one is the winner so we can eliminate an if statement


            if (cardTwoValue > cardOneValue)
            {
                result = cardTwo;
            }
            else if (cardOneValue == cardTwoValue)
            {
                result += " " + cardTwo;
            }

            return result;
        }

        public static string[] GetDeck()
        {
            var cardDeck = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            return cardDeck;
        }

    }
}
