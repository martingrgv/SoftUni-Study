using System.Collections;

namespace _04.Froggy;

public class Lake : IEnumerable<int>
{
    private List<int> list;

    public Lake(int[] stones)
    {
        this.list = new List<int>(stones);
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < this.list.Count; i++)
        {
            if (i % 2 == 0)
            {
                yield return this.list[i];
            }
        }

        for (int i = this.list.Count - 1; i >= 0; i--)
        {
            if (i % 2 != 0)
            {
                yield return this.list[i];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

