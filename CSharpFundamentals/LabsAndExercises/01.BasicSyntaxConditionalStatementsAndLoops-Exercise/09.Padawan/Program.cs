namespace _09.Padawan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int studentCount = int.Parse(Console.ReadLine());

            double saberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            // Add 10% to sabers
            double saberSum = saberPrice * Math.Ceiling(studentCount * 1.1);
            double robeSum = robePrice * studentCount;
            
            // Subtract free belts
            double freeBelts = studentCount / 6;
            double beltSum = (studentCount - freeBelts) * beltPrice;

            double total = saberSum + robeSum + beltSum;
            if (budget >= total)
            {
                double cost = total;
                Console.WriteLine("The money is enough - it would cost {0:f2}lv.", cost);
            }
            else
            {
                double neededMoney = total - budget;
                Console.WriteLine("John will need {0:f2}lv more.", neededMoney);
            }
        }
    }
}