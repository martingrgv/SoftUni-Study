using DeskMarket.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DeskMarket.Extensions
{
	public static class ServiceCollecitonExtension
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{

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
			//•	Require confirmed account: false
			//•	Require digits: false
			//•	Require non-alphanumeric characters: false
			//•	Required uppercase letters: false

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
