using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeskMarket.Data.Models
{
	[PrimaryKey(nameof(ProductId), nameof(ClientId))]
	public class ProductClient
	{
		public int ProductId { get; set; }

		[ForeignKey(nameof(ProductId))]
		public Product Product { get; set; } = null!;

		public string ClientId { get; set; } = null!;

		[ForeignKey(nameof(ClientId))]
		public IdentityUser Client { get; set; } = null!;
	}
}
