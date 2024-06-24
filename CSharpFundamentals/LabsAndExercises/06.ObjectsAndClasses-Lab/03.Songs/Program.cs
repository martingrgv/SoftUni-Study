namespace _03.Songs;

class Program
{
    static void Main(string[] args)
    {
        int songsCount = int.Parse(Console.ReadLine());
        List<Song> songs = new List<Song>();

        for (int i = 0; i < songsCount; i++)
        {
            string[] fullName = Console.ReadLine().Split("_");

            Song song = new Song();
            song.TypeList = fullName[0];
            song.Name = fullName[1];
            song.Time = fullName[2];
            
            songs.Add(song);
        }

        string type = Console.ReadLine();

        switch (type)
        {
            case "all":
                System.Console.WriteLine(string.Join(Environment.NewLine, songs.Select(s => s.Name)));
                break;
            default:
                System.Console.WriteLine(string.Join(Environment.NewLine, songs.Where(s => s.TypeList == type)
                                                                               .Select(s => s.Name)));
                break;
        }
    }
}
