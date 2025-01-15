using GameZone.Contracts;
using GameZone.Core;
using GameZone.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GameZone.Extensions
{
	public static class ServiceCollecitonExtension
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(Program).Assembly);
			services.AddScoped<IGameService, GameService>();

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
				options.SignIn.RequireConfirmedAccount = false;
				options.Password.RequireDigit = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
			})
				.AddEntityFrameworkStores<GameZoneDbContext>();

			return services;
		}
	}
}
