namespace _02.ClearSkies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] airspace = GetAirspace();

            int enemies = GetEnemiesCount(airspace);
            int aircraftHealth = 300;

            string command = Console.ReadLine();

            while (CanOperate(airspace, ref enemies, ref aircraftHealth, command))
            {
                command = Console.ReadLine();
            }

            PrintAirspace(airspace);
        }

        private static char[,] GetAirspace()
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

        private static int[] GetAircraftPosition(char[,] airspace)
        {
            for (int row = 0; row < airspace.GetLength(0); row++)
            {
                for (int col = 0; col < airspace.GetLength(1); col++)
                {
                    if (airspace[row, col] == 'J')
                    {
                        return new int[] { row, col };
                    }
                }
            }

            return null;
        }

        private static int GetEnemiesCount(char[,] airspace)
        {
            int count = 0;

            for (int row = 0; row < airspace.GetLength(0); row++)
            {
                for (int col = 0; col < airspace.GetLength(1); col++)
                {
                    if (airspace[row, col] == 'E')
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private static bool CanOperate(char[,] airspace, ref int enemiesCount, ref int aircraftHealth, string command)
        {
            int[] aircraftPosition = GetAircraftPosition(airspace);
            char encounter = ' ';

            switch (command)
            {
                case "up":
                    encounter = airspace[aircraftPosition[0] - 1, aircraftPosition[1]];

                    airspace[aircraftPosition[0] - 1, aircraftPosition[1]] = 'J';
                    airspace[aircraftPosition[0], aircraftPosition[1]] = '-';
                    break;
                case "down":
                    encounter = airspace[aircraftPosition[0] + 1, aircraftPosition[1]];

                    airspace[aircraftPosition[0] + 1, aircraftPosition[1]] = 'J';
                    airspace[aircraftPosition[0], aircraftPosition[1]] = '-';
                    break;
                case "left":
                    encounter = airspace[aircraftPosition[0], aircraftPosition[1] - 1];

                    airspace[aircraftPosition[0], aircraftPosition[1] - 1] = 'J';
                    airspace[aircraftPosition[0], aircraftPosition[1]] = '-';
                    break;
                case "right":
                    encounter = airspace[aircraftPosition[0], aircraftPosition[1] + 1];

                    airspace[aircraftPosition[0], aircraftPosition[1] + 1] = 'J';
                    airspace[aircraftPosition[0], aircraftPosition[1]] = '-';
                    break;
            }

            switch (encounter)
            {
                case 'R':
                    aircraftHealth = 300;
                    break;
                case 'E':
                    enemiesCount--;
                    aircraftHealth -= 100;

                    if (enemiesCount == 0)
                    {
                        Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
                        return false;
                    }    
                    else if (aircraftHealth <= 0)
                    {
                        int[] lastPosition = GetAircraftPosition(airspace);
                        Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{lastPosition[0]}, {lastPosition[1]}]!"
);
                        return false;
                    }
                    break;
            }

            return true;
        }

        private static void PrintAirspace(char[,] airspace)
        {
            for (int row = 0; row < airspace.GetLength(0); row++)
            {
                for (int col = 0; col < airspace.GetLength(1); col++)
                {
                    Console.Write(airspace[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
