using System.Collections;
using System.Runtime.CompilerServices;

namespace _02.Collection;

public class ListyIterator<T> : IEnumerable<T>
{
    private List<T> list;
    private int index = 0;

    public ListyIterator()
    {
        this.list = new List<T>();
    }

    public ListyIterator(List<T> list) : this()
    {
        this.list = list;
    }

    public T Current => this.list[index];

    public bool Move()
    {
        if (HasNext())
        {
            index++;
            return true;
        }

        return false;
    }

    public bool HasNext() => index < list.Count - 1;

    public void Print() 
    {
        try
        {
            Console.WriteLine(list[index]);
        }
        catch (Exception)
        {
            throw new InvalidOperationException();
        }
    }

    public void PrintAll()
    {
        if (this.list.Count <= 0)
        {
            throw new InvalidOperationException();
        }

        foreach (var item in this)
        {
            Console.Write($"{item} ");
        }

        Console.WriteLine();
    }

    public IEnumerator<T> GetEnumerator() 
    {
        foreach (var item in this.list)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
} 