using Domain.Repositories;
using Infrastructure.Adapters;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;
using MongoDB.Driver;

namespace WebApi.Extensions;

internal static class InfrastructureExtension
{
	private static string ConnectionString;

	static InfrastructureExtension()
	{
		ConnectionString = GetConnectionString();
	}
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{

		return services
			.AddSqlRepositories()
			.AddAdapters()
			.AddClients();
	}

	private static IServiceCollection AddSqlRepositories(this IServiceCollection services)
	{
		return services.AddScoped<IUserMongoRepository, UserMongoRepository>();
    }

	private static IServiceCollection AddAdapters(this IServiceCollection services)
	{
		return services
			.AddScoped<IUserRepository, UserRepositoryAdapter>();
	}

    private static IServiceCollection AddClients(this IServiceCollection services)
    {
		return services.AddSingleton<IMongoClient>(s =>
			new MongoClient(ConnectionString));
    }

	private static string GetConnectionString()
	{
		var connectionString = Environment.GetEnvironmentVariable("ConnectionString");

		if (!string.IsNullOrEmpty(connectionString))
		{
			return connectionString;
		}

		throw new Exception("Enviroment Variable ConnectionString not found ");
	}

}