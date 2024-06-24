namespace _01.Ages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            string person;

            if (age <= 2)
                person = "baby";
            else if (age >= 3 && age <= 13)
                person = "child";
            else if (age >= 14 && age <= 19)
                person = "teenager";
            else if (age >= 20 && age <= 65)
                person = "adult";
            else
                person = "elder";

            Console.WriteLine(person);
        }       
    }
}