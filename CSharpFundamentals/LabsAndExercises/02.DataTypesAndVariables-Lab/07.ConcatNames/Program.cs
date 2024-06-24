namespace _07.ConcatNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] concatName = new string[3];
            for (int i = 0; i < 3; i++)
            {
                concatName[i] = Console.ReadLine();   
            }

            Console.WriteLine(concatName[0] + concatName[2] + concatName[1]);
        }
    }
}