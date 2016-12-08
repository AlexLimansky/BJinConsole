using System;
using System.Collections.Generic;

namespace ConsoleTest
{
    public class Game
    {
        private const int DeckAmount = 52;
        private const int CardsInColor = 13;
        private const int ColorsAmount = 4;
        private const int MinCardNum = 2;
        private readonly string[] _colors = {"S","H","C","D"};

        private readonly Card[] _deck = new Card[DeckAmount];

        public Card CreateNumCard(int counter, int color)
        {
            var c = new Card
            {
                Title = (counter + MinCardNum).ToString(),
                Color = "",
                InGame = false,
                Value = counter + MinCardNum
            };
            return c;
        }

        public Card CreatePicCard(int counter, int color, string dicValue)
        {
            var titleAndValues = dicValue.Split(' ');
            var c = new Card
            {
                Title = titleAndValues[0],
                Color = "",
                InGame = false,
                Value = Convert.ToInt32(titleAndValues[1])
            };
            return c;
        }

        public void CreateOneColorOfCards(Card[] deck, int color)
        {
            var cards = new Dictionary<int, string>
            {
                {CardsInColor-4, "J 10"},
                {CardsInColor-3, "Q 10"},
                {CardsInColor-2, "K 10"},
                {CardsInColor-1, "A 11"}
            };
            for (var j = 0; j < CardsInColor; j++)
            {
                string value;
                var newcard = cards.TryGetValue(j, out value) ? CreatePicCard(j, color, value)
                 : CreateNumCard(j, color);
                _deck[j + CardsInColor*color] = newcard;
                _deck[j + CardsInColor * color].Color = _colors[color];
            }
        }

        public void DeckCreate()
        {
            for (var i = 0; i < ColorsAmount; i++)
            {
                CreateOneColorOfCards(_deck, i);
            }
        }

        public Card GetCard()
        {
            var r = new Random();
            var cardnum = r.Next(0, DeckAmount);
            while (_deck[cardnum].InGame)
            {
                cardnum = r.Next(0, DeckAmount);
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