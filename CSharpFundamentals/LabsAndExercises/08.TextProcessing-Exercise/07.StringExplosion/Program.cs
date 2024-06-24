using System.Text;

namespace _07.StringExplosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string explosionString = Console.ReadLine();
            string explodedString = ExplodeString(explosionString);

            Console.WriteLine(explodedString);
        }

        private static string ExplodeString(string str)
        {
            StringBuilder sb = new StringBuilder();
            int explosionStrenght = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '>')
                {
                    explosionStrenght += int.Parse(str[i + 1].ToString());
                    sb.Append(str[i]);
                }
                else if (explosionStrenght == 0)
                {
                    sb.Append(str[i]);
                }
                else
                {
                    explosionStrenght--;
                }
            }

            return sb.ToString();
        }
    }
}