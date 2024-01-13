namespace _06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");
            Queue<string> songsQueue = new Queue<string>(songs);

            while (songsQueue.Count > 0)
            {
                string command = Console.ReadLine();
                string[] tokens = command.Split();

                switch (tokens[0])
                {
                    case "Play":
                        songsQueue.Dequeue();
                        break;
                    case "Add":
                        string songName = string.Join(' ', tokens.Skip(1));

                        if (!songsQueue.Contains(songName))
                        {
                            songsQueue.Enqueue(songName);
                        }
                        else
                        {
                            Console.WriteLine(songName + " is already contained!");
                        }
                        break;
                    case "Show":
                        songs = songsQueue.ToArray();
                        Console.WriteLine(string.Join(", ", songs));
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
