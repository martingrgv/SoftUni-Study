using System.Text;

namespace GenericBoxOfInt
{
    public class Box<T>
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

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in list)
                sb.AppendLine($"{typeof(T)}: {item}");

            return sb.ToString().TrimEnd();
        }
    }
}
