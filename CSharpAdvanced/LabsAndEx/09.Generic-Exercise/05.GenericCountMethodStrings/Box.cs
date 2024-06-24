using System.Text;

namespace GenericBox
{
    public class Box<T> where T : IComparable
    {
        private List<T> list;

        public Box()
        {
            this.list = new List<T>();
        }

        public void Add(T item)
        {
            this.list.Add(item);
        }

        public int CountGreaterThan(T element)
        {
            int count = 0;

            foreach (var item in list)
            {
                if (item.CompareTo(element) > 0)
                    count++;
            }

            return count;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in list)
                sb.AppendLine($"{typeof(T)}: {item}");

            return sb.ToString().TrimEnd();
        }
    }
}
