using System;
using Cards2;

// loop while there's more input(not sure what to do with this,have to press enter to start code)
string input = Console.ReadLine();

// Add your code between this comment
// and the comment below. You can of
// course add more space between the
// comments as needed

// declare a deck variable and create a deck object
// DON'T SHUFFLE THE DECK
Deck deck = new Deck();

// 4 players, up to 3 cards each
Card[,] players = new Card[4, 3];

// deal 2 cards each to 4 players (deal properly, dealing
// the first card to each player before dealing the
// second card to each player)
for (int i = 0; i < 2; i++)
{
    for (int p = 0; p < 4; p++)
    {
        players[p, i] = deck.TakeTopCard();
    }
}

// deal 1 more card to players 2 and 3
players[1, 2] = deck.TakeTopCard();
players[2, 2] = deck.TakeTopCard();

// flip all the cards over
for (int p = 0; p < 4; p++)
{
    for (int c = 0; c < 3; c++)
    {
        if (players[p, c] != null)
        {
            players[p, c].FlipOver();
        }
    }
}

// print the cards for player 1234

for (int p = 0; p < 4; p++)
{
    Console.WriteLine("Player " + (p + 1) + ":");
    for (int c = 0; c < 3; c++)
    {
        if (players[p, c] != null)
            Console.WriteLine(players[p, c].Rank + " of " + players[p, c].Suit);
    }
    Console.WriteLine();

}