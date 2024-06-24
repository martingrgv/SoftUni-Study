namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stringStack = new StackOfStrings();

            Console.WriteLine(stringStack.IsEmpty());

            stringStack.AddRange(new string[] { "element1", "element2"});
            Console.WriteLine(string.Join(' ', stringStack));
        }
    }
}
