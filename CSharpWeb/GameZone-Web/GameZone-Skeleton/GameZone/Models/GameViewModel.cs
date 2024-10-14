namespace GameZone.Models
{
	public class GameViewModel
	{
		public int Id { get; set; } 
		public string Title { get; set; } = null!;
		public string Description { get; set; } = null!;
		public string ImageUrl { get; set; } = null!;
		public DateTime ReleasedOn { get; set; }
		public string Genre { get; set; } = null!;
		public string Publisher { get; set; } = null!;
	}
}
