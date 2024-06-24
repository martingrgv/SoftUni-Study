namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random rnd = new Random();
            int index = rnd.Next(0, Count - 1);

            string removedElement = this[index];
            RemoveAt(index);

            return removedElement;
        }
    }
}
