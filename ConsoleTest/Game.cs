using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public struct Card
    {
        public string Title { get; set; }        
        public string Color { get; set; }
        public int Value { get; set; }
        public bool InGame { get; set; }
    }

    public class Player
    {
        public List<Card> Hand { get; set; }
        public int Points
        {
            get
            {
                int total = 0;
                foreach (Card с in Hand)
                {
                    total += с.Value;
                }
                return total;
            }
            set
            {
                this.Points = 0;
            }
        }
        public string Cards
        {
            get
            {
                string cards = "";
                foreach (Card c in Hand)
                {
                    cards += c.Title + "-" + c.Color + " ";
                }
                return cards;
            }
            set
            {
                this.Cards = "";
            }
        }
        public Player()
        {
            Hand = new List<Card>();
        }
    }


    public class Game
    {
        private Card[] Deck = new Card[52];

        public void DeckCreate()
        {
            int counter = 0;
            for (int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 13; j++)
                {
                    if (j < 9)
                    {
                        Deck[counter].Title = (j+2).ToString();
                        Deck[counter].Value = j+2;
                    }
                    else
                    {
                        switch (j)
                        {
                            case 9:
                                Deck[counter].Title = "В";
                                Deck[counter].Value = 10;
                                break;
                            case 10:
                                Deck[counter].Title = "Д";
                                Deck[counter].Value = 10;
                                break;
                            case 11:
                                Deck[counter].Title = "К";
                                Deck[counter].Value = 10;
                                break;
                            case 12:
                                Deck[counter].Title = "Т";
                                Deck[counter].Value = 11;
                                break;
                        }
                    }                   
                    switch (i)
                    {
                        case 0:
                            Deck[counter].Color = "Ч";
                            break;
                        case 1:
                            Deck[counter].Color = "Т";
                            break;
                        case 2:
                            Deck[counter].Color = "Б";
                            break;
                        case 3:
                            Deck[counter].Color = "П";
                            break;
                    }
                    Deck[counter].InGame = false;
                    counter++;
                }
            }
        }

        public Card GetCard()
        {
            Random r = new Random();
            int cardnum = r.Next(0, 52);
            while (Deck[cardnum].InGame)
            {
                cardnum = r.Next(0, 52);
            }
            Deck[cardnum].InGame = true;
            return Deck[cardnum];
        }

        public void GameStart(Player Bank, Player Player)
        {
            DeckCreate();
            Bank.Hand.Add(GetCard());
            Bank.Hand.Add(GetCard());
            Player.Hand.Add(GetCard());
            Player.Hand.Add(GetCard());
        }

        public void More(Player Player)
        {
            Player.Hand.Add(GetCard());
        }
               
        

    }
}
