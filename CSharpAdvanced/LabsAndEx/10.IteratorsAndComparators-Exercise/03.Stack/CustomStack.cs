using System.Collections;

namespace _03.Stack;
public class CustomStack<T> : IEnumerable<T>
{
	private List<T> list;

	public CustomStack()
	{
		this.list = new List<T>();
	}

	public void Push(params T[] values)
	{
		if (values.Length <= 0)
			throw new InvalidOperationException();

		foreach (var value in values)
		{
			this.list.Add(value);
		}
	}

	public T Pop()
	{
		if (this.list.Count <= 0)
			throw new InvalidOperationException();

		int lastElementIndex = this.list.Count - 1;

		T element = this.list[lastElementIndex];
		this.list.RemoveAt(lastElementIndex);

		return element;
	}

    public IEnumerator<T> GetEnumerator()
    {
		List<T> orderedStack = new List<T>(list);
		orderedStack.Reverse();

		foreach (var item in orderedStack)
		{
			yield return item;
		}
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}