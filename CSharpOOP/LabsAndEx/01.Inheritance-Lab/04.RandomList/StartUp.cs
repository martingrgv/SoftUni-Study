namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList rndList = new RandomList();

            rndList.Add("str1");
            rndList.Add("str2");
            rndList.Add("str3");

            Console.WriteLine(string.Join(' ', rndList));

            Console.WriteLine(rndList.RandomString());

            Console.WriteLine(string.Join(' ', rndList));
        }
    }
}
