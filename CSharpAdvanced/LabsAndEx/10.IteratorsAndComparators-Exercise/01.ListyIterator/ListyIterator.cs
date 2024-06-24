namespace _01.ListyIterator;

public class ListyIterator<T>
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
} 