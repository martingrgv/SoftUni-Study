using Cards.Models;

namespace Cards;

public class StartUp
{
    public static void Main(string[] args)
    {
        List<Card> cards = new List<Card>();

        string[] cardsData = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < cardsData.Length; i++)
        {
            string[] cardData = cardsData[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

            try
            {
                cards.Add(new Card(cardData[0], cardData[1]));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        foreach (var card in cards)
            Console.Write(card + " ");
    }
}