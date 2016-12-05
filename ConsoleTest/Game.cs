using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ConsoleTest
{
    public class Game
    {
        private readonly Card[] _deck = new Card[52];

        private enum Colors
        {
            S = 0,
            H = 1,
            C = 2,
            D = 3
        }

        public void DeckCreate()
        {
            Dictionary<int, string> cards = new Dictionary<int, string>();
            cards.Add(9, "J 10");
            cards.Add(10, "Q 10");
            cards.Add(11, "K 10");
            cards.Add(12, "A 11");
            var counter = 0;
            for (var i = 0; i < 4; i++)
            {
                for(var j = 0; j < 13; j++)
                {
                    foreach (var card in cards)
                    {
                        if (j == card.Key)
                        {
                            string[] titleAndValues = card.Value.Split(' ');
                            _deck[counter].Title = titleAndValues[0];
                            _deck[counter].Value = Convert.ToInt32(titleAndValues[1]);
                        }
                        if (j != card.Key)
                        {
                            _deck[counter].Title = (j + 2).ToString();
                            _deck[counter].Value = j + 2;
                        }                      
                    }               
                    _deck[counter].InGame = false;
                    foreach (var color in Enum.GetValues(typeof(Colors)))
                    {
                        if (i == (int) color)
                        {
                            _deck[counter].Color = color.ToString();
                        }
                    }
                    counter++;
                }
            }
        }

        public Card GetCard()
        {
            Random r = new Random();
            int cardnum = r.Next(0, 52);
            while (_deck[cardnum].InGame)
            {
                cardnum = r.Next(0, 52);
            }
            _deck[cardnum].InGame = true;
            return _deck[cardnum];
        }

        public void GameStart(Player bank, Player player)
        {
            DeckCreate();
            bank.Hand.Add(GetCard());
            bank.Hand.Add(GetCard());
            player.Hand.Add(GetCard());
            player.Hand.Add(GetCard());
        }

        public void More(Player player)
        {
            player.Hand.Add(GetCard());
        }                      
    }
}
