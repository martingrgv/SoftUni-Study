namespace _03.ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            string fileName = Path.GetFileNameWithoutExtension(path);
            string fileExtension = Path.GetExtension(path).Replace(".", "");

            Console.WriteLine("File name: " + fileName);
            Console.WriteLine("File extension: " + fileExtension);
        }
    }
}