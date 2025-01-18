using Domain.Repositories;
using Domain.Services;
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
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connection)
    {
        ConnectionString += connection;

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
            .AddScoped<IUserRepository, UserRepositoryAdapter>()
            .AddScoped<IUserAdapterService, UserServiceAdapter>();
    }

    private static IServiceCollection AddClients(this IServiceCollection services)
    {
        return services.AddSingleton<IMongoClient>(s =>
            new MongoClient(ConnectionString));
    }

    //private static string GetConnectionString()
    //{
    //    //var connectionString = Environment.GetEnvironmentVariable("MongoDb");

    //    //if (!string.IsNullOrEmpty(connectionString))
    //    //{
    //    //	return connectionString;
    //    //}

    //    var config = new ConfigurationBuilder()
    //        .AddJsonFile("appsettings.json")
    //        .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    //        .Build();

    //    throw new Exception("Enviroment Variable ConnectionString not found ");
    //}

}