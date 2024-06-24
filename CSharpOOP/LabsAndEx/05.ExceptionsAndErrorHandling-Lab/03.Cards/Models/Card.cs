namespace Cards.Models;

public class Card
{
    private readonly string[] validFaces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
    private readonly string[] validSuits = { "H", "C", "D", "S"};
    private string face;
    private string suit;

    public Card(string face, string suit)
    {
        Face = face;
        Suit = suit;
    }

    public string Face
    {
        get { return face; }
        private set
        {
            if (!validFaces.Contains(value))
            {
                throw new ArgumentException("Invalid card!");
            }

            face = value;
        }
    }
    
    public string Suit
    {
        get { return suit; }
        private set
        {
            if (!validSuits.Contains(value))
            {
                throw new ArgumentException("Invalid card!");
            }

            suit = value;
        }
    }

    private string SuitSymbol
    {
        get
        {
            if (Suit == "H") return "\u2665";
            else if (Suit == "C") return "\u2663";
            else if (Suit == "D") return "\u2666";
            else if (Suit == "S") return "\u2660";
            else throw new ArgumentException("Card suit cannot be null");
        }
    }

    public override string ToString()
    {
        return $"[{Face}{SuitSymbol}]";
    }
}