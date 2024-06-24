using System.Reflection;

namespace Stealer;

public class Spy
{
    public void StealFieldInfo(string className, params string[] fields)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] fieldInfos = classType.GetFields(
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

        Object classInstance = Activator.CreateInstance(classType, new object[] {});

        Console.WriteLine($"Class under investigation: {className}");

        foreach (FieldInfo field in fieldInfos.Where(f => fields.Contains(f.Name)))
        {
            Console.WriteLine($"{field.Name} = {field.GetValue(classInstance)}");           
        }
    }

    public void AnalyzeAccessModifiers(string className)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] fieldInfos = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
        MethodInfo[] nonPublicMethods =
            classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
        MethodInfo[] publicMethods =
            classType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
        
        Object classInstance = Activator.CreateInstance(classType, new object[] {
        });

        foreach (FieldInfo field in fieldInfos.Where(f => f.IsPublic))
        {
            Console.WriteLine($"{field.Name} must be private!");
        }
        foreach (MethodInfo method in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            Console.WriteLine($"{method.Name} have to be public!");
        }
        foreach (MethodInfo method in publicMethods.Where(m => m.Name.StartsWith("set")))
        {
            Console.WriteLine($"{method.Name} have to be private!");
        }
    }
}