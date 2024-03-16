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

    public void RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] methodInfos = classType.GetMethods(
            BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        Console.WriteLine($"All Private Methods of Class: {className}");
        Console.WriteLine($"Base Class: {classType.BaseType.Name}");
        
        foreach (MethodInfo method in methodInfos)
        {
            Console.WriteLine(method.Name);
        }
    }

    public void CollectGettersAndSetters(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] methodInfos =
            classType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
        
        foreach (MethodInfo method in methodInfos.Where(m => m.Name.StartsWith("get")))
        {
            Console.WriteLine($"{method.Name} will return {method.ReturnType}");
        }
        foreach (MethodInfo method in methodInfos.Where(m => m.Name.StartsWith("set")))
        {
            foreach (ParameterInfo param in method.GetParameters())
            {
                Console.WriteLine($"{method.Name} will set field of {param.ParameterType}");
            }
        }
    } 
}