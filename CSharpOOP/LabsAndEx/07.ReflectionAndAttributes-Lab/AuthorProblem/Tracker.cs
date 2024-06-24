using System.Reflection;

namespace AuthorProblem;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        Type startType = typeof(StartUp);
        MethodInfo[] methods = startType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

        foreach (MethodInfo method in methods)
        {
            if (method.CustomAttributes.Any(a => a.AttributeType == typeof(AuthorAttribute)))
            {
                var attributes = method.GetCustomAttributes().Where(a => a.GetType() == typeof(AuthorAttribute));

                foreach (AuthorAttribute attribute in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                }
            }
        }
    }
}