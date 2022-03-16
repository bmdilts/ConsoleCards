using System;
using System.Linq;

partial class Deck
{
    private Card[] deck;
    private int currentCard;
    private const int NUMBER_OF_CARDS = 52;
    private Random randomNumber;

    public Deck()
    {
        string[] values = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
        string[] suits = {"Hearts", "Clubs", "Diamonds", "Spades"};
        deck = new Card[NUMBER_OF_CARDS];
        currentCard = 0;
        randomNumber = new Random();
        for(int i = 0; i < deck.Length; i++){
            deck[i] = new Card(values[i % 13], suits[i / 13]);
        }
    }

    public Card DealCard()
    {
        if(currentCard < deck.Length)
            return deck[currentCard++];
        else
            return null;
    }

    public Card DealCards(int count)
    {
        for(int i = 0; i < count; i++){
            if(currentCard < deck.Length)
            {
                currentCard++;
                Console.WriteLine();
                Console.WriteLine(deck[currentCard].ToString());
            }
            else
            {
                return null;
            }
        }
        Console.WriteLine();
        return null;
    }
    
    public void ShuffleDeck()
    {
        currentCard = 0;
        for(int first = 0; first < deck.Length; first++)
        {
            int second = randomNumber.Next(NUMBER_OF_CARDS);
            Card temp = deck[first];
            deck[first] = deck[second];
            deck[second] = temp;
        }
    }

    public Deck Sort(string type, Deck sortThisDeck)
    {
        if( type == "rank")
        {
            Deck sortedDeck = new Deck();
            sortedDeck.deck = sortThisDeck.deck.OrderBy(card => card.value).ToArray();
            return sortedDeck;
        }
        if ( type == "suit")
        {
            Deck sortedDeck = new Deck();
            sortedDeck.deck = sortThisDeck.deck.OrderBy(card => card.suit).ToArray();
            return sortedDeck;
        }
        return new Deck();
    }

    public void PrintDeck(Deck deck)
    {
        for(int x = 0; x < 52; x++)
        {
            Console.Write("{0,-19}", deck.DealCard());

            if((x + 1) % 4 == 0)
                Console.WriteLine();
        }
    }

    public void WriteToConsole()
    {
        foreach (Card card in deck)
        {
            Console.WriteLine(card.ToString());
        }
    }
}