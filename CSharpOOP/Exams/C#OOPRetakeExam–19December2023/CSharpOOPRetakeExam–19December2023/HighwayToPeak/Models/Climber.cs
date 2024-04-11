using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        // might create error
        public const int MAX_STAMINA_UNIT = 10;

        private string name;
        private int stamina;
        private List<string> conqueredPeaks;

        private const int MODERATE_DIFFICULTY_LEVEL_UNIT = 2;
        private const int HARD_DIFFICULTY_LEVEL_UNIT = 4;
        private const int EXTREME_DIFFICULTY_LEVEL_UNIT = 6;

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
                    Stamina -= MODERATE_DIFFICULTY_LEVEL_UNIT;
                    break;
                case "Hard":
                    Stamina -= HARD_DIFFICULTY_LEVEL_UNIT;
                    break;
                case "Extreme":
                    Stamina -= EXTREME_DIFFICULTY_LEVEL_UNIT;
                    break;
	        }
	    }

        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            return $"{GetType().Name} - Name: {Name}, Stamina: {Stamina}"
                + Environment.NewLine
                + $"Peaks conquered: {(ConqueredPeaks.Count <= 0 ? "no peaks conquered" : conqueredPeaks.Count)}";
        }
    }
}

