using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        private string name;
        private int stamina;
        private List<string> conqueredPeaks;

        public Climber(string name, int stamina)
        {
            Name = name;
            Stamina = stamina;
            conqueredPeaks = new List<string>();
        }

        public string Name
        { 
            get { return name; }
            private set
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);
		        }

                name = value;
	        }
	    } 

        public int Stamina 
	    {
            get { return stamina; }
            protected set { stamina = value; }
	    }

        public IReadOnlyCollection<string> ConqueredPeaks  
	    {
	        get { return conqueredPeaks.AsReadOnly(); } 
	    } 

        public void Climb(IPeak peak)
        {
            if (!conqueredPeaks.Any(s => s == peak.Name))
            {
                conqueredPeaks.Add(peak.Name);
	        }

            DecreaseStamina(peak.DifficultyLevel);
        }

        private void DecreaseStamina(string difficulty)
        { 
            switch (difficulty)
            {
                case "Moderate":
                    Stamina -= 2;
                    break;
                case "Hard":
                    Stamina -= 4;
                    break;
                case "Extreme":
                    Stamina -= 6;
                    break;
	        }
	    }

        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            return $"{GetType().Name} - Name: {Name}, Stamina: {Stamina}"
                + Environment.NewLine
                + $"Peaks conquered: no peaks conquered/{conqueredPeaks.Count}";
        }
    }
}

