namespace _02.VowelsCount;

class Program
{
    static void Main(string[] args)
    {
        string word = Console.ReadLine();
        PrintVowels(word);
    }

    static int GetVowelsCount(string word)
    {
        int total = 0;
        foreach (char letter in word)
        {
            if (isVowel(letter))
            {
                total++;
            }
        }

        return total;
    }

    static bool isVowel(char letter) => Char.ToLower(letter) == 'a' || Char.ToLower(letter) == 'e' || 
                                        Char.ToLower(letter) == 'i'  || Char.ToLower(letter)== 'o'  || 
                                        Char.ToLower(letter) == 'u'
                                        ? true : false;

    static void PrintVowels(string word)
    {
        int vowelsCount = GetVowelsCount(word);
        Console.WriteLine(vowelsCount);
    }
}
