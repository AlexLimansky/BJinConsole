using System;
using System.Collections.Generic;

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
            var cards = new Dictionary<int, string>
            {
                {9, "J 10"},
                {10, "Q 10"},
                {11, "K 10"},
                {12, "A 11"}
            };
            var counter = 0;
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 13; j++)
                {
                    string value;
                    if (cards.TryGetValue(j, out value))
                    {
                        var titleAndValues = value.Split(' ');
                        _deck[counter].Title = titleAndValues[0];
                        _deck[counter].Value = Convert.ToInt32(titleAndValues[1]);
                    }
                    else
                    {
                        _deck[counter].Title = (j + 2).ToString();
                        _deck[counter].Value = j + 2;
                    }
                    _deck[counter].InGame = false;
                    for (var k = 0; k < Enum.GetValues(typeof (Colors)).Length; k++)
                    {
                        var color = Enum.GetValues(typeof (Colors)).GetValue(k);
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
            var r = new Random();
            var cardnum = r.Next(0, 52);
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