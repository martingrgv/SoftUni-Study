using System.Text;

namespace SharkTaxonomy
{
    public class Classifier
    {
        public Classifier(int capacity)
        {
            Capacity = capacity;
            Species = new List<Shark>();
        }

        public int Capacity { get; set; }
        public List<Shark> Species { get; set; }
        public int GetCount { get { return Species.Count; } }

        public void AddShark(Shark shark)
        {
            if (!Species.Contains(shark))
            {
                if (Capacity > 0)
                {
                    Species.Add(shark);
                    Capacity--;
                }
            }
        }

        public bool RemoveShark(string kind)
        {
            Shark foundShark = Species.FirstOrDefault(s => s.Kind == kind);

            if (foundShark != null)
            {
                Species.Remove(foundShark);
                Capacity++;

                return true;
            }

            return false;
        }

        public string GetLargestShark() => Species.MaxBy(s => s.Length).ToString();

        public double GetAverageLength()
        {
            int count = GetCount;
            int sum = 0;

            foreach (var shark in Species)
            {
                sum += shark.Length;
            }

            return (double) sum / count;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{GetCount} sharks classified:");

            foreach (var shark in Species)
            {
                sb.AppendLine(shark.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
