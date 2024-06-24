using System.Collections;

namespace ImplementingForEach;

public class Program
{
    static void Main(string[] args)
    {
        StringEnumerable stringEnumerable = new StringEnumerable();
        stringEnumerable.AddString("Hello, ");
        stringEnumerable.AddString("World");

        ForEach(stringEnumerable);
    }

    // foreach under the hood
    private static void ForEach(IEnumerable<string> enumerable)
    {
        IEnumerator<string> enumerator = enumerable.GetEnumerator();

        while (enumerator.MoveNext())
            Console.WriteLine(enumerator.Current);
    }
}

// To use foreach we need to inherit IEnumerable<T> or the type we use with the interface's methods.
public class StringEnumerable : IEnumerable<string>
{
    private List<string> list;

    public StringEnumerable()
    {
        this.list = new List<string>();
    }

    public void AddString(string str)
    {
        this.list.Add(str);
    }

    // This method is generated from IEnumerable
    public IEnumerator<string> GetEnumerator()
    {
        return new StringEnumerator(list);
    }

    // This method is for backwards compatibility
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

// We need to implement Enumerator by inheriting it from IEnumerator<T> or any other type
public class StringEnumerator : IEnumerator<string>
{
    private List<string> list;
    private int index = -1;

    public StringEnumerator(List<string> list)
    {
        this.list = list;
    }

    public string Current => list[index];

    object IEnumerator.Current => Current;

    public void Dispose()
    {
        Reset();
    }

    public bool MoveNext() => ++index < list.Count;

    public void Reset()
    {
        index = -1;
    }
}
