using System.Collections;

namespace YieldReturn
{
    public class Program
    {
        static void Main(string[] args)
        {
            StringEnumerable stringEnumerable = new StringEnumerable();
            stringEnumerable.AddString("Hello, ");
            stringEnumerable.AddString("World!");

            foreach (var str in stringEnumerable)
            {
                Console.Write(str);
            }
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
            foreach (var item in list)
            {
                // yield simplifies, even creates an IEnumerator withouth the need to implement it ourselves
                // yield keyword returns one element upon each loop cycle
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
