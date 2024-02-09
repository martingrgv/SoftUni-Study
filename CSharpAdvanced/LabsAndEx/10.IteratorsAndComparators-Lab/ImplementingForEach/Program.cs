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

    private static void ForEach(IEnumerable<string> enumerable)
    {
        IEnumerator<string> enumerator = enumerable.GetEnumerator();

        while (enumerator.MoveNext())
            Console.WriteLine(enumerator.Current);
    }
}

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

    public IEnumerator<string> GetEnumerator()
    {
        return new StringEnumerator(list);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

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
