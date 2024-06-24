namespace CustomStack
{
    public class StackOfStrings : Stack<String>
    {
        public bool IsEmpty() => Count == 0;

        public void AddRange(IEnumerable<string> collection)
        {
            foreach (var element in collection)
                Push(element);
        }
    }
}
