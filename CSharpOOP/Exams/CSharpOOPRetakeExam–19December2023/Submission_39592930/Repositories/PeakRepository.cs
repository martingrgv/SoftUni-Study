using HighwayToPeak.Repositories.Contracts;
using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Repositories
{
	public class PeakRepository : IRepository<IPeak>
	{
        private List<IPeak> peaks;

		public PeakRepository()
		{
		}

        public IReadOnlyCollection<IPeak> All
        { 
            get { return peaks.AsReadOnly(); }
	    }

        public void Add(IPeak model)
        {
            peaks.Add(model);
        }

        public IPeak Get(string name)
        {
            return peaks.FirstOrDefault(p => p.Name == name);
        }
    }
}

