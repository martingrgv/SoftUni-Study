using GameZone.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Extensions
{
	public static class ServiceCollecitonExtension
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			return services;
		}

		public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("Defaultconnection") ?? throw new InvalidOperationException("Could not fetch connection string!");
			services.AddDbContext<GameZoneDbContext>(options => options.UseSqlServer(connectionString));
			services.AddDatabaseDeveloperPageExceptionFilter();

			return services;
		}

		public static IServiceCollection AddIdentity(this IServiceCollection services)
		{
			services.AddDefaultIdentity<IdentityUser>(options =>
			{
				options.SignIn.RequireConfirmedAccount = true;
			})
				.AddEntityFrameworkStores<GameZoneDbContext>();

			return services;
		}
	}
}
