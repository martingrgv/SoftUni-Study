using HighwayToPeak.Repositories.Contracts;
using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Repositories
{
	public class ClimberRepository : IRepository<IClimber>
	{
        private List<IClimber> climbers;

		public ClimberRepository()
		{
		}

        public IReadOnlyCollection<IClimber> All
        { 
            get { return climbers.AsReadOnly(); }
	    }

        public void Add(IClimber model)
        {
            climbers.Add(model);
        }

        public IClimber Get(string name)
        {
            return climbers.FirstOrDefault(c => c.Name == name);
        }
    }
}

