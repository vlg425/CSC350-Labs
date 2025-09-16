//UML
//Player()
//--------------------
//-playerCards : List<Card>
//-playerID : int
//--------------------
//+GetPlayerID() : int
//+AddCard(card : Card) : void
//+RemoveCard(cardIndex : int) : Card
//+GetCardCount() : int
//+HasCards() : bool
//+DisplayCards() : void
//+SortCardsByValue() : void
//+SortCardsBySuit() : void
//
//--------------------

using Cards2;
using System;
class Player
{
    private List<Card> playerCards;

    public Player()
    {
        playerCards = new List<Card>();

    }



    public void AddCard(Card card)
    {
        playerCards.Add(card);
    }

    public Card RemoveCard(int cardIndex)
    {
        if (cardIndex < 0 || cardIndex >= playerCards.Count)
        {
            throw new ArgumentOutOfRangeException("Invalid card index");
        }
        Card removedCard = playerCards[cardIndex];
        playerCards.RemoveAt(cardIndex);
        return removedCard;
    }

    public int GetCardCount()
    {
        return playerCards.Count;
    }

    public bool HasCards()
    {
        return playerCards.Count > 0;
    }

    public void DisplayCards()
    {
        foreach (var card in playerCards)
        {
            Console.WriteLine(card.Rank + " of " + card.Suit);

        }
    }
    
    



}
class Program
{
    public static void Main(string[] args)
    {
        Player player = new Player();
        Deck deck = new Deck();
        deck.Shuffle();

        player.AddCard(deck.TakeTopCard());
        player.AddCard(deck.TakeTopCard());
        player.AddCard(deck.TakeTopCard());
        player.AddCard(deck.TakeTopCard());
        player.DisplayCards();
        

    }
      
}

