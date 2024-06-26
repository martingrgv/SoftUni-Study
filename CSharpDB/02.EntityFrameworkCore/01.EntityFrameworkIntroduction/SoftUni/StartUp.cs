using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                Console.WriteLine(AddNewAddressToEmployee(context));
            }
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            return string.Join(Environment.NewLine, context.Employees
                .Select(e => $"{ e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}"));
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                { 
                    e.FirstName,
                    e.Salary
                })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName);

            return string.Join(Environment.NewLine, employees
                .Select(e => $"{e.FirstName} - {e.Salary:f2}"));
        }
        
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department,
                    e.Salary
                })
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName);
                
            return string.Join(Environment.NewLine, employees
                .Select(e => $"{e.FirstName} {e.LastName} from {e.Department.Name} - ${e.Salary:f2}"));
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var employee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            if (employee != null)
            {
                employee.Address = address;
                context.SaveChanges();
            }

            var employees = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText);

            return string.Join(Environment.NewLine, employees);
        }
    }
}
