namespace _10.LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] field = new int[fieldSize];
            int[] ladybugsPos = GetStarterPos();

            PlaceBugs(ladybugsPos, field);

            string userInput;
            while ((userInput = Console.ReadLine()) != "end")
            {
                string[] command = GetCommand(userInput);
                MoveBug(int.Parse(command[0]), int.Parse(command[2]), command[1], field);
            }

            ShowField(field);
        }

        static int[] GetStarterPos() => Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

        static string[] GetCommand(string s) => s.Split(" ");

        static void PlaceBugs(int[] bugsPos, int[] field)
        {
            foreach (var bugPos in bugsPos)
            {
                SetPose(bugPos, field);
            }
        }

        static void SetPose(int pos, int[] field)
        {
            field[pos] = 1;
        }

        static void MoveBug(int startPos, int steps, string direction, int[] field)
        {
            field[startPos] = 0;

            try
            {
                if (direction == "right")
                {
                    int endPos = startPos + steps;
                    if (field[steps] == 1)
                    {
                        field[endPos + steps] = 1;
                    }
                    else
                    {
                        field[endPos] = 1;
                    }
                }
                else // left
                {
                    int endPos = startPos - steps;
                    if (field[endPos] == 1)
                    {
                        field[endPos - steps] = 1;
                    }
                    else
                    {
                        field[endPos] = 1;
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
            }
        }

        static void ShowField(int[] field)
        {
            foreach (var pos in field)
            {
                Console.Write(pos + " ");
            }
        }
    }
}