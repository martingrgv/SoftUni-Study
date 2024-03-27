using System;
using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Models
{
    public class Peak : IPeak
	{
        private string name;
        private int elevation;
        private string difficultyLevel;
		public Peak()
		{
		}

        public string Name
        {
            get { return name; }
            set
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Peak name cannot be null or whitespace.");
		        }

                name = value;
	        }
	    }   

        public int Elevation
        { 
            get { return elevation; }
            set
            { 
                // Could be more than 0 only
                if (value < 0)
                {
                    throw new ArgumentException("Peak elevation must be a positive value.");
		        }

                elevation = value;
	        }
	    }

        public string DifficultyLevel
        { 
            get { return difficultyLevel; }
	    }

        public override string ToString()
        {
            return $"Peak: {Name} -> Elevation: {Elevation}, Difficulty: {DifficultyLevel}";
        }
    }
}

