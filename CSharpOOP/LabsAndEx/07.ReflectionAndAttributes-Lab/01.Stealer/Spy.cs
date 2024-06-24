using System.Reflection;

namespace Stealer;

public class Spy
{
    public void StealFieldInfo(string className, params string[] fields)
    {
        Type type = Type.GetType(className);
        FieldInfo[] fieldsInfo = type.GetFields(
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

        Object classInstance = Activator.CreateInstance(type, new object[] {});

        Console.WriteLine($"Class under investigation: {className}");

        foreach (FieldInfo field in fieldsInfo.Where(f => fields.Contains(f.Name)))
        {
            Console.WriteLine($"{field.Name} = {field.GetValue(classInstance)}");           
        }
    }
}