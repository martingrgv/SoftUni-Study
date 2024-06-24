namespace _04.ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string sReverse = String.Empty;

            for (int i = s.Length; i > 0; i--)
            {
                sReverse += s[i - 1];
            }

            Console.WriteLine(sReverse);
        }
    }
}