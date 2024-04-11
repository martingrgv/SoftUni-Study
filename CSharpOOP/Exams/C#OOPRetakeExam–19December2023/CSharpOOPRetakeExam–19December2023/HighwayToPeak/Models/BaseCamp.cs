using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Models
{
	public class BaseCamp : IBaseCamp
	{
        private List<string> residents;

		public BaseCamp()
		{
            residents = new List<string>();
		}

        public IReadOnlyCollection<string> Residents 
	    { 
	        get { return (IReadOnlyCollection<string>) residents.AsReadOnly().OrderBy(r => r).ToList(); } 
	    }

        public void ArriveAtCamp(string climberName)
        {
            if (!residents.Contains(climberName))
            {
                residents.Add(climberName);
	        }
        }

        public void LeaveCamp(string climberName)
        {
            if (residents.Contains(climberName))
            {
                residents.Remove(climberName);
            }
        }
    }
}

