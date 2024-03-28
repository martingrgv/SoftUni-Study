using System.Text;

namespace HighwayToPeak.Core
{
	using HighwayToPeak.Core.Contracts;
    using HighwayToPeak.Repositories;
    using HighwayToPeak.Models;
    using HighwayToPeak.Models.Contracts;

	public class Controller : IController
	{
        private PeakRepository peaks;
        private ClimberRepository climbers;
        private BaseCamp baseCamp;

        public Controller()
        {
            peaks = new PeakRepository();
            climbers = new ClimberRepository();
            baseCamp = new BaseCamp();
        }

        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            if (peaks.All.Any(p => p.Name == name))
            {
                return $"{name} is already added as a valid mountain destination.";
	        }
            if (!DifficultyLevelExists(difficultyLevel))
            {
                return $"{difficultyLevel} peaks are not allowed for international climbers.";
	        }

            IPeak peak = new Peak(name, elevation, difficultyLevel);
            peaks.Add(peak);

            return $"{name} is allowed for international climbing. See details in {peaks.GetType().Name}.";
        }

        private bool DifficultyLevelExists(string difficultyLevel)
        {
            switch (difficultyLevel)
            {
                case "Moderate":
                case "Hard":
                case "Extreme":
                    return true;
                default:
                    return false;
            }
	    }

        public string AttackPeak(string climberName, string peakName)
        {
            if (!climbers.All.Any(c => c.Name == climberName))
            { 
                return $"Climber - {climberName}, has not arrived at the BaseCamp yet.";
	        }
            if (!peaks.All.Any(p => p.Name == peakName))
            { 
                return $"{peakName} is not allowed for international climbing.";
	        }
            if (!baseCamp.Residents.Any(n => n == climberName))
            { 
                return $"{climberName} not found for gearing and instructions. The attack of {peakName} will be postponed.";
	        }

            IPeak peak = peaks.Get(peakName);
            IClimber climber = climbers.Get(climberName);

            if (peak.DifficultyLevel == "Extreme")
            { 
			    if (climber is NaturalClimber)
			    { 
					return $"{climberName} does not cover the requirements for climbing {peakName}.";
				}
		    }

            baseCamp.LeaveCamp(climberName);
            climber.Climb(peak);

            if (climber.Stamina <= 0)
            { 
                return $"{climberName} did not return to BaseCamp.";
	        }

            baseCamp.ArriveAtCamp(climberName);
            return $"{climberName} successfully conquered {peakName} and returned to BaseCamp.";
        }

        public string BaseCampReport()
        {
            if (baseCamp.Residents.Count == 0)
            {
                return $"BaseCamp is currently empty.";
	        }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("BaseCamp residents:");

            foreach (var climberName in baseCamp.Residents)
            {
                IClimber climber = climbers.Get(climberName);

                sb.AppendLine($"Name: {climberName}, Stamina: {climber.Stamina}, Count of Conquered Peaks: {climber.ConqueredPeaks.Count}");
	        }

            return sb.ToString().TrimEnd();
        }

        public string CampRecovery(string climberName, int daysToRecover)
        {
            if (!baseCamp.Residents.Any(n => n == climberName))
            { 
                return $"{climberName} not found at the BaseCamp.";
            }

            IClimber climber = climbers.Get(climberName);

            if (climber.Stamina >= Climber.MAX_STAMINA_UNIT)
            { 
                return $"{climberName} has no need of recovery.";
	        }

            climber.Rest(daysToRecover);
            return $"{climberName} has been recovering for {daysToRecover} days and is ready to attack the mountain.";
        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            if (climbers.All.Any(c => c.Name == name))
            { 
                return $"{name} is a participant in {climbers.GetType().Name} and cannot be duplicated.";
	        }

            IClimber climber;

            if (isOxygenUsed)
            {
                climber = new OxygenClimber(name);
	        }
            else
            {
                climber = new NaturalClimber(name);
	        }

            climbers.Add(climber);
            baseCamp.ArriveAtCamp(name);

            return $"{name} has arrived at the BaseCamp and will wait for the best conditions.";
        }

        public string OverallStatistics()
        {
            List<IClimber> orderedClimbers = climbers.All.OrderByDescending(c => c.ConqueredPeaks.Count) // Peak count
                .ThenBy(c => c.Name).ToList(); // Name

			StringBuilder sb = new StringBuilder();
			sb.AppendLine("***Highway-To-Peak***");

            foreach (var climber in orderedClimbers)
            {
                sb.AppendLine(climber.ToString());

                List<IPeak> orderedPeaks = GetClimberPeaksOrdered(climber);
                foreach (var peak in orderedPeaks)
                {
                    sb.AppendLine(peak.ToString());
                }
            }


            return sb.ToString().TrimEnd();
        }

        private List<IPeak> GetClimberPeaksOrdered(IClimber climber)
        {
			List<IPeak> orderedPeaks = new List<IPeak>();

            foreach (var peakName in climber.ConqueredPeaks)
            {
                IPeak currentPeak = peaks.Get(peakName);
                orderedPeaks.Add(currentPeak);
            }

            return orderedPeaks.OrderByDescending(p => p.Elevation).ToList();
	    }
    }
}

