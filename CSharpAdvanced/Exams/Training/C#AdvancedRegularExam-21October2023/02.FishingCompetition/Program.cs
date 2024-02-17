namespace _02.FishingCompetition;
class Program
{
    static void Main(string[] args)
    {
        char[,] area = GetFishingArea();

        int caughtFish = 0;

        string input;

        while ((input = Console.ReadLine()) != "collect the nets" && CanMove(input, area, ref caughtFish));

        if (input == "collect the nets")
        {
            PrintOutput(caughtFish, area);
        }


    }

    private static char[,] GetFishingArea()
    {
        int n = int.Parse(Console.ReadLine());
        char[,] matrix = new char[n, n];

        for (int row = 0; row < n; row++)
        {
            string line = Console.ReadLine();
            for (int col = 0; col < n; col++)
            {
                matrix[row, col] = line[col];
            }
        }

        return matrix;
    }

    private static int[] GetPlayerPosition(char[,] area)
    {
        for (int row = 0; row < area.GetLength(0); row++)
        {
            for (int col = 0; col < area.GetLength(1); col++)
            {
                if (area[row, col] == 'S')
                {
                    return new int[] { row, col };
                }
            }
        }

        return null;
    }

    private static bool CanMove(string input, char[,] area, ref int caughtFish)
    {
        int[] playerPos = GetPlayerPosition(area);
        char gameChar = ' ';

        switch (input)
        {
            case "up":
                if (playerPos[0] - 1 < 0)
                {
                    gameChar = area[area.GetLength(1) - 1, playerPos[1]];

                    area[area.GetLength(1) - 1, playerPos[1]] = 'S';
                    area[playerPos[0], playerPos[1]] = '-';
                }
                else
                {
                    gameChar = area[playerPos[0] - 1, playerPos[1]];

                    area[playerPos[0] - 1, playerPos[1]] = 'S';
                    area[playerPos[0], playerPos[1]] = '-';
                }
                break;
            case "down":
                if (playerPos[0] + 1 > area.GetLength(0) - 1)
                {
                    gameChar = area[0, playerPos[1]];

                    area[0, playerPos[1]] = 'S';
                    area[playerPos[0], playerPos[1]] = '-';
                }
                else
                {
                    gameChar = area[playerPos[0] + 1, playerPos[1]];

                    area[playerPos[0] + 1, playerPos[1]] = 'S';
                    area[playerPos[0], playerPos[1]] = '-';
                }
                break;
            case "left":
                if (playerPos[1] - 1 < 0)
                {
                    gameChar = area[playerPos[0], area.GetLength(1) - 1];

                    area[playerPos[0], area.GetLength(1) - 1] = 'S';
                    area[playerPos[0], playerPos[1]] = '-';
                }
                else
                {
                    gameChar = area[playerPos[0], playerPos[1] - 1];

                    area[playerPos[0], playerPos[1] - 1] = 'S';
                    area[playerPos[0], playerPos[1]] = '-';
                }
                break;
            case "right":
                if (playerPos[1] + 1 > area.GetLength(1) - 1)
                {
                    gameChar = area[playerPos[0], 0];

                    area[playerPos[0], 0] = 'S';
                    area[playerPos[0], playerPos[1]] = '-';
                }
                else
                {
                    gameChar = area[playerPos[0], playerPos[1] + 1];

                    area[playerPos[0], playerPos[1] + 1] = 'S';
                    area[playerPos[0], playerPos[1]] = '-';
                }
                break;
            case "print":
                PrintFishingArea(area);
                break;
        }

        if (char.IsDigit(gameChar))
        {
            caughtFish += (int)char.GetNumericValue(gameChar);
        }
        else if (gameChar == 'W')
        {
            int[] lastPos = GetPlayerPosition(area);
            Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{lastPos[0]},{lastPos[1]}]");
            return false;
        }
        else if (caughtFish >= 20)
        {
            PrintOutput(caughtFish, area);

            return false;
        }

        return true;
    }

    private static void PrintFishingArea(char[,] area)
    {
        for (int row = 0; row < area.GetLength(0); row++)
        {
            for (int col = 0; col < area.GetLength(1); col++)
            {
                Console.Write(area[row, col]);
            }
            Console.WriteLine();
        }
    }

    private static void PrintOutput(int fishCount, char[,] area)
    {
        if (fishCount >= 20)
        {
            Console.WriteLine("Success! You managed to reach the quota!");
        }
        else
        {
            Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {20 - fishCount} tons of fish more.");
        }

        if (fishCount > 0)
        {
            Console.WriteLine($"Amount of fish caught: {fishCount} tons.");
        }

        PrintFishingArea(area);
    }
}