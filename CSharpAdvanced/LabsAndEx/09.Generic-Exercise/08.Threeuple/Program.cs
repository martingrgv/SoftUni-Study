namespace CustomTuples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] inArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var nameAddressTown = new CustomTuple<string, string, string>();
            nameAddressTown.Item1 = inArgs[0] + ' ' + inArgs[1];
            nameAddressTown.Item2 = inArgs[2];
            nameAddressTown.Item3 = inArgs[3];

            if (inArgs.Length > 4)
                nameAddressTown.Item3 += ' ' + inArgs[4];


            input = Console.ReadLine();
            inArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var nameBeerDrunk = new CustomTuple<string, int, bool>();
            nameBeerDrunk.Item1 = inArgs[0];
            nameBeerDrunk.Item2 = int.Parse(inArgs[1]);
            nameBeerDrunk.Item3 = inArgs[2] == "drunk" ? true : false ;


            input = Console.ReadLine();
            inArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var bankAccount = new CustomTuple<string, double, string>();
            bankAccount.Item1 = inArgs[0];
            bankAccount.Item2 = double.Parse(inArgs[1]);
            bankAccount.Item3 = inArgs[2];

            Console.WriteLine($"{nameAddressTown.Item1} -> {nameAddressTown.Item2} -> {nameAddressTown.Item3}");
            Console.WriteLine($"{nameBeerDrunk.Item1} -> {nameBeerDrunk.Item2} -> {nameBeerDrunk.Item3}");
            Console.WriteLine($"{bankAccount.Item1} -> {bankAccount.Item2} -> {bankAccount.Item3}");
        }
    }
}
