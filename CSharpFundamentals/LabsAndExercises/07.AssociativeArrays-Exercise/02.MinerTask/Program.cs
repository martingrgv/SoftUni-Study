namespace _02.MinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var resources = new Dictionary<string, int>();

            AddResources(resources);
            PrintResources(resources);
        }

        static void AddResources(Dictionary<string, int> resources)
        {
            string input;

            while ((input = Console.ReadLine()) != "stop")
            {
                string resource = input;
                int quality = int.Parse(Console.ReadLine());

                if (resources.ContainsKey(resource))
                {
                    resources[resource] += quality;
                }
                else
                {
                    resources.Add(resource, quality);
                }
            }
        }

        static void PrintResources(Dictionary<string, int> resources)
        {
            foreach (var resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}