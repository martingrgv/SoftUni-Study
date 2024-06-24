namespace _01.EncryptSortAndPrintArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            string[] names = GetNames();

            int[] encryptedNames = new int[names.Length];

            // Loop through names
            for (int i = 0; i < names.Length; i++)
            {
                int sum = 0;
                string currentName = names[i];

                for (int j = 0; j < currentName.Length; j++) // Loop through chars
                {
                    char currentChar = currentName[j];

                    if (vowels.Any(ch => ch == char.ToLower(currentChar))) // is vowel
                    {
                        sum += currentChar * currentName.Length;
                    }
                    else // is not vowel
                    {
                        sum += currentChar / currentName.Length;
                    }
                }

                encryptedNames[i] = sum;
            }

            // Print output
            Array.Sort(encryptedNames);
            Console.WriteLine(string.Join("\n", encryptedNames));
        }

        static string[] GetNames()
        {
            int namesCount = int.Parse(Console.ReadLine());
            string[] names = new string[namesCount];

            for (int i = 0; i < namesCount; i++)
            {
                names[i] = Console.ReadLine();
            }

            return names;
        }
    }
}
