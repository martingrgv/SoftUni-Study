namespace _03.ThePianist
{
    internal class Program
    {
        static List<Piece> pieces = new();
        static void Main(string[] args)
        {
            int piecesCount = int.Parse(Console.ReadLine());

            AddPieces(piecesCount);

            string input;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] inArgs = input.Split("|");
                string act = inArgs[0];

                switch (act)
                {
                    case "Add":
                        string pieceName = inArgs[1];
                        string composer = inArgs[2];
                        string key = inArgs[3];

                        AddPiece(pieceName, composer, key);
                        break;
                    case "Remove":
                        pieceName = inArgs[1];

                        RemovePiece(pieceName);
                        break;
                    case "ChangeKey":
                        pieceName = inArgs[1];
                        string newKey = inArgs[2];

                        ChangePieceKey(pieceName, newKey);
                        break;
                }
            }

            pieces.ForEach(p => Console.WriteLine($"{p.Name} -> Composer: {p.Composer}, Key: {p.Key}"));
        }

        static void AddPieces(int count)
        {
            for (int i = 0; i < count; i++)
            {
                AddPiece();
            }
        }

        static void AddPiece()
        {
            Piece piece = GetPiece();

            if (!pieces.Exists(p => p.Name == piece.Name))
            {
                pieces.Add(piece);
            }
        }

        static void AddPiece(string pieceName, string composer, string key)
        {
            Piece piece = new Piece(pieceName, composer, key);

            if (pieces.Exists(p => p.Name == piece.Name))
            {
                Console.WriteLine($"{pieceName} is already in the collection!");
            }
            else
            {
                pieces.Add(piece);
                Console.WriteLine($"{pieceName} by {composer} in {key} added to the collection!");
            }
        }

        static Piece GetPiece()
        {
            string[] arguments = Console.ReadLine().Split("|");

            string name = arguments[0];
            string composer = arguments[1];
            string key = arguments[2];

            return new Piece(name, composer, key);
        }

        static void RemovePiece(string pieceName)
        {
            if (pieces.Exists(p => p.Name == pieceName))
            {
                Piece removePiece = pieces.FirstOrDefault(p => p.Name == pieceName);
                pieces.Remove(removePiece);

                Console.WriteLine($"Successfully removed {pieceName}!");
            }
            else
            {
                Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
            }
        }

        static void ChangePieceKey(string pieceName, string newKey)
        {
            if (pieces.Exists(p => p.Name == pieceName))
            {
                Piece piece = pieces.FirstOrDefault(p => p.Name == pieceName);
                piece.Key = newKey;

                Console.WriteLine($"Changed the key of {pieceName} to {newKey}!");
            }
            else
            {
                Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
            }
        }
    }
}