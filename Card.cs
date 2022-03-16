public class Card
{
    public string value;
    public string suit;

    string[] values = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
    string[] suits = {"Hearts", "Clubs", "Diamonds", "Spades"};

    public Card (string cardValue, string cardSuit)
    {
        value = cardValue;
        suit = cardSuit;
    }

    public override string ToString()
    {
        return value + " of " + suit;
    }
}