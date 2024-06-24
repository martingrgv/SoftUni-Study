namespace _05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothesRange = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> clothBox = new Stack<int>(clothesRange);

            int rackCapacity = int.Parse(Console.ReadLine());
            int racksUsed = 0;

            while (clothBox.Count > 0)
            {
                int clothesToHang = clothBox.Pop();

                while (clothBox.Count > 0 && clothesToHang + clothBox.Peek() <= rackCapacity)
                {
                        clothesToHang += clothBox.Pop();                   
                }

                racksUsed++;
            }

            Console.WriteLine(racksUsed);
        }
    }
}
