namespace HighwayToPeak.Models
{
	public class OxygenClimber : Climber
	{
        private const int INITAL_STAMINA = 10;
        private const int REST_UNIT = 1;

        public OxygenClimber(string name) : base(name, INITAL_STAMINA)
		{
		}

        public override void Rest(int daysCount)
        {
            for (int i = 0; i < daysCount; i++)
			    Stamina += REST_UNIT;           
        }
    }
}

