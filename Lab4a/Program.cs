using System;
using System.Collections.Generic;
using Cards2; // Deck, Card, Rank, Suit

public class Player
{
    private readonly List<Card> _hand = new List<Card>();

    public string Name { get; }
    public int CardCount { get { return _hand.Count; } }
    public bool HasCards { get { return _hand.Count > 0; } }

    public Player(string name)
    {
        Name = name;
    }

    // Draw one or more cards from the deck into this player's hand.
    public void DrawFrom(Deck deck, int numberOfCards = 1)
    {
        if (deck == null) return;
        if (numberOfCards < 1) return;

        for (int i = 0; i < numberOfCards; i++)
        {
            if (deck.Empty) break;

            Card topCard = deck.TakeTopCard(); // Cards2: returns null if empty
            if (topCard != null)
            {
                _hand.Add(topCard);
            }
            else
            {
                break;
            }
        }
    }

    // Add a card directly (useful for testing duplicates)
    public void Add(Card cardToAdd)
    {
        if (cardToAdd != null) _hand.Add(cardToAdd);
    }

    // Remove by index; returns true if a card was removed and sets removedCard.
    public bool TryRemoveAt(int index, out Card removedCard)
    {
        removedCard = null;

        if (index < 0 || index >= _hand.Count)
        {
            Console.WriteLine("Invalid index.");
            return false;
        }

        removedCard = _hand[index];
        _hand.RemoveAt(index);
        return true;
    }

    // Remove a specific card instance; returns true if it was found and removed.
    public bool Remove(Card cardToRemove)
    {
        return _hand.Remove(cardToRemove);
    }

    // Check if an index is valid for the current hand.
    public bool IsValidIndex(int index)
    {
        return index >= 0 && index < _hand.Count;
    }

    // Sort the player's hand by rank, then by suit.
    public void SortHand()
    {
        _hand.Sort((left, right) =>
        {
            int byRank = left.Rank.CompareTo(right.Rank);
            if (byRank != 0) return byRank;
            return left.Suit.CompareTo(right.Suit);
        });
    }

    // Print a readable list of the player's cards.
    public void DisplayHand()
    {
        if (!HasCards)
        {
            Console.WriteLine(Name + " has no cards.");
            return;
        }

        Console.WriteLine(Name + "'s hand (" + CardCount + " cards):");
        foreach (Card card in _hand)
        {
            Console.WriteLine("  " + card.Rank + " of " + card.Suit);
        }
    }
}


class Program
{
    static void Main()
    {
        Console.WriteLine("=== Player Class Test Suite ===\n");

        Deck gameDeck = new Deck();
        gameDeck.Shuffle();

        Player playerOne = new Player("Player 1");

        // 1) Initialization
        playerOne.DisplayHand();
        Console.WriteLine($"card count: {playerOne.CardCount}");
        Console.WriteLine();

        // 2) Add Card to Player (draw 1)
        playerOne.DrawFrom(gameDeck, 1);
        playerOne.DisplayHand();
        Console.WriteLine();
        // 3) Remove Card from Player (remove index 0)
        bool removedOk = playerOne.TryRemoveAt(0, out Card removedCard);
        playerOne.DisplayHand();
        Console.WriteLine();

        // 4) Card Count (draw 3, then remove 1)
        playerOne.DrawFrom(gameDeck, 3);
        playerOne.DisplayHand();
        Console.WriteLine();
        removedOk = playerOne.TryRemoveAt(1, out removedCard);
        playerOne.DisplayHand();
        Console.WriteLine();

        // 5) Index Validation (try invalid index)
        bool indexValid = playerOne.IsValidIndex(999);
        
        removedOk = playerOne.TryRemoveAt(999, out removedCard);
        playerOne.DisplayHand();
        Console.WriteLine();
        

        // 6) Empty Hand Check (remove all cards)
        while (playerOne.HasCards)
        {
            playerOne.TryRemoveAt(0, out removedCard);
        }
        playerOne.DisplayHand();
        Console.WriteLine();
        
        // 7) Display Cards (draw 2 and show)
        playerOne.DrawFrom(gameDeck, 2);
        Console.WriteLine("\n7) Display:");
        playerOne.DisplayHand();

        // 8) Sorting by Card Value (rank then suit)
        playerOne.DrawFrom(gameDeck, 3); // make sure we have a few cards
        int handSizeBeforeSort = playerOne.CardCount;
        playerOne.SortHand();
        
        Console.WriteLine("\n8) Sorted hand:");
        playerOne.DisplayHand();

        // 9) Multiple Deals
        Player playerTwo = new Player("Player 2");
        playerTwo.DrawFrom(gameDeck, 5);
        

        // 10) Handling Duplicate Cards
        Player duplicateTester = new Player("Duplicate Tester");
        Card tenOfDiamonds = new Card(Rank.Ten, Suit.Diamonds);
        duplicateTester.Add(tenOfDiamonds);
        duplicateTester.Add(tenOfDiamonds);
        
        bool removedOneDuplicate = duplicateTester.Remove(tenOfDiamonds);
        

        // 11) Removing Non-Existent Card
        Card aceOfSpades = new Card(Rank.Ace, Suit.Spades);
        bool removedMissing = duplicateTester.Remove(aceOfSpades);
        

        Console.WriteLine("\nAll tests finished.");
    }

    
}
