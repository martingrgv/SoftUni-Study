using System.Runtime.CompilerServices;

namespace _11.ArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = GetArray();
            ManipulativeArray manipulativeArray = new ManipulativeArray(numbers);

            string[] command = GetCommand();

            while (command[0] != "end")
            {
                if (command[0] == "exchange")
                {
                    int exchangeNumber = int.Parse(command[1]);

                    if (exchangeNumber < manipulativeArray.Length)
                    {
                        manipulativeArray.Exchange(exchangeNumber);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (command[0] == "max")
                {
                    if (command[1] == "even")
                    {
                        Console.WriteLine(manipulativeArray.MaxEven);
                    }
                    else // odd
                    {
                        Console.WriteLine(manipulativeArray.MaxOdd);
                    }
                }
                else if (command[0] == "min")
                {
                    if (command[1] == "even")
                    {
                        Console.WriteLine(manipulativeArray.MinEven);
                    }
                    else // odd
                    {
                        Console.WriteLine(manipulativeArray.MinOdd);
                    }
                }
                else if (command[0] == "first")
                {
                    int count = int.Parse(command[1]);

                    if (count <= manipulativeArray.Length)
                    {
                        if (command[2] == "even")
                        {
                            int[] firstEven = manipulativeArray.FirstEven(count);
                            PrintArray(firstEven);
                        }
                        else // odd
                        {
                            int[] firstOdd = manipulativeArray.FirstOdd(count);
                            PrintArray(firstOdd);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid count");
                    }
                }
                else if (command[0] == "last")
                {
                    int count = int.Parse(command[1]);

                    if (count <= manipulativeArray.Length)
                    {
                        if (command[2] == "even")
                        {
                            int[] firstEven = manipulativeArray.FirstEven(count);
                            PrintArray(firstEven);
                        }
                        else // odd
                        {
                            int[] firstOdd = manipulativeArray.FirstOdd(count);
                            PrintArray(firstOdd);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid count");
                    }
                }

                command = GetCommand();
            }

            manipulativeArray.ShowArray();
        }

        static int[] GetArray() => Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

        static string[] GetCommand() => Console.ReadLine().Split(" ").ToArray();

        static void PrintArray(int[] arr)
        {
            if (arr[0] == -1)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine('[' + String.Join(", ", arr) + ']');
            }
        }
    }

    internal class ManipulativeArray
    {
        private int[] array = new int[0];

        public int Length { get { return this.array.Length; } }

        public Object MaxEven
        {
            get
            {
                bool exists = false;
                int greatestNumIndex = 0;

                for (int i = 0; i < Length; i++)
                {
                    if (this.array[i] % 2 == 0)
                    {
                        if (this.array[greatestNumIndex] <= this.array[i])
                        {
                            exists = true;
                            greatestNumIndex = i;
                        }
                    }
                }

                if (exists)
                {
                    return greatestNumIndex;
                }

                return "No matches";
            }
        }

        public Object MaxOdd
        {
            get
            {
                bool exists = false;
                int greatestNumIndex = 0;

                for (int i = 0; i < Length; i++)
                {
                    if (this.array[i] % 2 != 0)
                    {
                        if (this.array[greatestNumIndex] <= this.array[i])
                        {
                            exists = true;
                            greatestNumIndex = i;
                        }
                    }
                }

                if (exists)
                {
                    return greatestNumIndex;
                }

                return "No matches";
            }
        }

        public Object MinEven
        {
            get
            {
                bool exists = false;
                int lowestNumIndex = 0;

                for (int i = 0; i < Length; i++)
                {
                    if (this.array[i] % 2 == 0)
                    {
                        if (this.array[lowestNumIndex] >= this.array[i])
                        {
                            exists = true;
                            lowestNumIndex= i;
                        }
                    }
                }

                if (exists)
                {
                    return lowestNumIndex;
                }

                return "No matches";
            }
        }

        public Object MinOdd
        {
            get
            {
                bool exists = false;
                int lowestNumIndex = 0;

                for (int i = 0; i < Length; i++)
                {
                    if (this.array[i] % 2 != 0)
                    {
                        if (this.array[lowestNumIndex] >= this.array[i])
                        {
                            exists = true;
                            lowestNumIndex = i;
                        }
                    }
                }

                if (exists)
                {
                    return lowestNumIndex;
                }

                return "No matches";
            }
        }

        public ManipulativeArray(int[] array)
        {
            this.array = array;
        }

        public void ShowArray()
        {
            Console.Write('[' + String.Join(", ", this.array) + ']');
        }

        public void Exchange(int num)
        {
            int rotations = 0;

            while (rotations < num + 1)
            {
                int[] temporaryArr = new int[this.array.Length];

                for (int i = this.array.Length - 1; i > 0; i--)
                {
                    temporaryArr[i - 1] = this.array[i];
                }

                temporaryArr[temporaryArr.Length - 1] = this.array[0];
                this.array = temporaryArr;

                rotations++;
            }
        }


        public int[] FirstEven(int count)
        {
            List<int> evenNums = new List<int>();
            int addCount = 0;
            bool foundEven = false;

            for (int i = 0; i < Length; i++)
            {
                if (this.array[i] % 2 == 0)
                {
                    foundEven = true;

                    evenNums.Add(this.array[i]);
                    addCount++;
                }
            }

            if (foundEven)
            {
                int[] arr = new int[evenNums.Count];
                
                for (int i = 0; i < evenNums.Count; i++)
                {
                    arr[i] = evenNums[i];
                }

                return arr;
            }
            else
            {
                int[] arr = { -1 };
                return arr;
            }
        }

        public int[] FirstOdd(int count)
        {
            List<int> oddNums = new List<int>();
            int addCount = 0;
            bool foundOdd = false;

            for (int i = 0; i < Length; i++)
            {
                if (this.array[i] % 2 != 0)
                {
                    if (addCount < count)
                    {
                        foundOdd = true;

                        oddNums.Add(this.array[i]);
                        addCount++;
                    }
                }
            }

            if (foundOdd)
            {
                int[] arr = new int[oddNums.Count];
                
                for (int i = 0; i < oddNums.Count; i++)
                {
                    arr[i] = oddNums[i];
                }

                return arr;
            }
            else
            {
                int[] arr = { -1 };
                return arr;
            }
        }
    }
}