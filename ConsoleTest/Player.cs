using System.Collections.Generic;


namespace ConsoleTest
{
    public class Player
    {
        public List<Card> Hand { get; set; }        
        public Player()
        {
            Hand = new List<Card>();
        }
    }
}
