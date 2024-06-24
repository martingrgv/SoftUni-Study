namespace HighwayToPeak.Models
{
	public class NaturalClimber : Climber
	{
		private const int INITIAL_STAMINA = 6;
		private const int REST_UNIT = 2;

		public NaturalClimber(string name) : base(name, INITIAL_STAMINA)
		{
		
		}

        public override void Rest(int daysCount)
        {
            for (int i = 0; i < daysCount; i++)
			    Stamina += REST_UNIT;           

            if (Stamina >= MAX_STAMINA_UNIT)
                Stamina = MAX_STAMINA_UNIT;
        }
    }
}

