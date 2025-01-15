using DeskMarket.Data;
using DeskMarket.Services;
using DeskMarket.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DeskMarket.Extensions
{
	public static class ServiceCollecitonExtension
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<IShopService, ShopService>();
			return services;
		}

		public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Could not fetch connection string!");
			services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
			services.AddDatabaseDeveloperPageExceptionFilter();

			return services;
		}

		public static IServiceCollection AddIdentity(this IServiceCollection services)
		{
			services.AddDefaultIdentity<IdentityUser>(options =>
			{
				options.SignIn.RequireConfirmedAccount = false;
				options.Password.RequireDigit = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
			})
				.AddEntityFrameworkStores<ApplicationDbContext>();

			return services;
		}
	}
}
