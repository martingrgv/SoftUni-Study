namespace _07.CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> data = GetInput();
            ReadData(data);
        }

        static Dictionary<string, List<string>> GetInput()
        {
            var data = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] arguments = input.Split("->", StringSplitOptions.TrimEntries);
                string companyName = arguments[0];
                string employeeId = arguments[1];

                if (data.ContainsKey(companyName))
                {
                    var employeesList = data[companyName];

                    if (!employeesList.Contains(employeeId))
                    {
                        data[companyName].Add(employeeId);
                    }
                }
                else 
                {
                    data.Add(companyName, new List<string> { employeeId});
                }
            }

            return data;
        }

        static void ReadData(Dictionary<string, List<string>> data)
        {
            foreach(var d in data)
            {
                Console.WriteLine(d.Key);

                foreach (var employee in d.Value)
                {
                    Console.WriteLine("-- " + employee);
                }
            }
        }
    }
}